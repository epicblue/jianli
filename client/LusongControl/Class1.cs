using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;

namespace LusongControl
{
    //实现思想是使用windows api CreatePipe 创建一个匿名管道
    //接收控制台命令的输出，并产生委托事件。
    //具体实现见以下代码：

    /// <summary>
    /// 重定向的类
    /// </summary>
    public class Redirect : IDisposable
    {
        /// <summary>
        /// 重定向类的代码
        /// </summary>
        public enum RdEventType
        {
            //错误事件
            ErrorEvent,
            //输出事件
            DataEvent,
            //stop事件
            StopEvent
        }
        /// <summary>
        /// 事件参数
        /// </summary>
        public struct RdEventArgs
        {
            //code
            public RdEventType eventtype;
            //字符串(错误时代表错误信息，数据时代表数据字符串,stop时代表停止信息）
            public string info;
        };
        /// <summary>
        /// 错误处理事件类型
        /// </summary>
        /// <param name="code"></param>
        public delegate void RdEvent(RdEventArgs args);
        /// <summary>
        /// 构造函数1
        /// </summary>
        /// <param name="szCommand">命令行</param>
        /// <param name="szCurrentDirectory">当前目录</param>
        public Redirect(string szCommand, string szCurrentDirectory)
        {
            m_szCommand = szCommand;
            m_szCurrentDirectory = szCurrentDirectory;
            m_running = false;
            //默认100毫秒
            m_dwMilliseconds = 100;
            m_processInfo = new PROCESS_INFORMATION();
            m_PipeData = new byte[BUF_SIZE];
            m_readtimer = new System.Windows.Forms.Timer();
            m_readtimer.Enabled = false;
            m_readtimer.Interval = (int)m_dwMilliseconds;
            m_readtimer.Tick += new EventHandler(timertick);
        }
        /// <summary>
        /// 构造函数2
        /// </summary>
        /// <param name="szCommand"></param>
        public Redirect(string szCommand)
            : this(szCommand, null)
        {
        }
        /// <summary>
        /// 构造函数3
        /// </summary>
        public Redirect()
            : this(null, null)
        {
        }
        #region windows api
        [StructLayout(LayoutKind.Sequential)]
        class PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public int dwProcessId;
            public int dwThreadId;
        }
        [StructLayout(LayoutKind.Sequential)]
        class SECURITY_ATTRIBUTES
        {
            public int nLength;
            public IntPtr lpSecurityDescriptor;
            public int bInheritHandle;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        class STARTUPINFO
        {
            public int cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public int dwX;
            public int dwY;
            public int dwXSize;
            public int dwYSize;
            public int dwXCountChars;
            public int dwYCountChars;
            public int dwFillAttribute;
            public int dwFlags;
            public short wShowWindow;
            public short cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool CreateProcess(string lpApplicationName, string lpCommandLine, SECURITY_ATTRIBUTES lpProcessAttributes,
            SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandles, int dwCreationFlags, IntPtr lpEnvironment,
            string lpCurrentDirectory, STARTUPINFO lpStartupInfo, PROCESS_INFORMATION lpProcessInformation);
        [DllImport("kernel32.dll")]
        static extern bool CreatePipe(out IntPtr hReadPipe, out IntPtr hWritePipe,
           SECURITY_ATTRIBUTES lpPipeAttributes, uint nSize);
        [DllImport("kernel32.dll", EntryPoint = "PeekNamedPipe", SetLastError = true)]
        static extern bool PeekNamedPipe(IntPtr handle, byte[] buffer, uint nBufferSize, ref uint bytesRead,
                    ref uint bytesAvail, ref uint BytesLeftThisMessage);
        [DllImport("kernel32.dll")]
        static extern bool ReadFile(IntPtr hFile, byte[] lpBuffer,
           uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);
        [DllImport("kernel32", SetLastError = true, ExactSpelling = true)]
        static extern Int32 WaitForSingleObject(IntPtr handle, Int32 milliseconds);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);
        const int STARTF_USESHOWWINDOW = 0x00000001;
        const int STARTF_USESTDHANDLES = 0x00000100;
        const short SW_HIDE = 0;
        const int WAIT_OBJECT_0 = 0;
        #endregion
        /// <summary>
        /// 错误报告事件
        /// </summary>
        public event RdEvent RdEventHandler;
        private IntPtr m_PipeReadHandle;
        private IntPtr m_PipeWriteHandle;
        private PROCESS_INFORMATION m_processInfo;
        byte[] m_PipeData;
        /// <summary>
        /// buffer的大小
        /// </summary>
        private const int BUF_SIZE = 8192;
        /// <summary>
        /// 启动
        /// </summary>
        public void Run()
        {
            //如果已经运行
            if (m_running) return;
            SECURITY_ATTRIBUTES SecurityAttributes = new SECURITY_ATTRIBUTES();
            STARTUPINFO StartupInfo = new STARTUPINFO();
            bool Success;
            //创建pipe
            SecurityAttributes.nLength = Marshal.SizeOf(SecurityAttributes);
            SecurityAttributes.bInheritHandle = 1;
            SecurityAttributes.lpSecurityDescriptor = IntPtr.Zero;
            Success = CreatePipe(out m_PipeReadHandle, out m_PipeWriteHandle, SecurityAttributes, 0);
            if (!Success)
            {
                RaiseRdEvent(RdEventType.ErrorEvent, "CreatePipe failed.");
                return;
            }
            //创建进程
            StartupInfo.cb = Marshal.SizeOf(StartupInfo);
            StartupInfo.dwFlags = STARTF_USESHOWWINDOW | STARTF_USESTDHANDLES;
            StartupInfo.wShowWindow = SW_HIDE;
            StartupInfo.hStdOutput = m_PipeWriteHandle;
            StartupInfo.hStdError = m_PipeWriteHandle;
            Success = CreateProcess(null, m_szCommand, null, null, true, 0, IntPtr.Zero,
                m_szCurrentDirectory, StartupInfo, m_processInfo);
            if (!Success)
            {
                RaiseRdEvent(RdEventType.ErrorEvent, "CreateProcess failed.");
                return;
            }
            //成功，启动时钟周期性的读取管道
            m_running = true;
            m_readtimer.Start();
        }
        //触发事件
        private void RaiseRdEvent(RdEventType eventtype, string info)
        {
            RdEventArgs args = new RdEventArgs();
            args.eventtype = eventtype;
            args.info = info;
            if (RdEventHandler != null)
                RdEventHandler(args);
        }
        /// <summary>
        /// 时钟触发
        /// </summary>
        /// <param name="state"></param>
        private void timertick(object sender, EventArgs e)
        {
            uint NumBytesRead = 0;
            uint TotalBytesAvailable = 0;
            uint BytesLeftThisMessage = 0;
            //查看数据
            bool Success = PeekNamedPipe(m_PipeReadHandle, m_PipeData, 1, ref NumBytesRead,
                ref TotalBytesAvailable, ref BytesLeftThisMessage);
            if (!Success)
            {
                RaiseRdEvent(RdEventType.ErrorEvent, "PeekNamedPipe failed.");
                return;
            }
            //如果读到数据
            if (NumBytesRead > 0)
            {
                Success = ReadFile(m_PipeReadHandle, m_PipeData, BUF_SIZE, out NumBytesRead, IntPtr.Zero);
                if (!Success)
                {
                    RaiseRdEvent(RdEventType.ErrorEvent, "ReadFileError failed.");
                    return;
                }
                //处理得到的数据
                dealReadData(m_PipeData, NumBytesRead);
                return;
            }
            //如果没有读到数据，查看进程是否结束了
            if (WaitForSingleObject(m_processInfo.hProcess, 0) == WAIT_OBJECT_0)//结束了
            {
                m_running = false;
                RaiseRdEvent(RdEventType.StopEvent, "terminated normal.");
                m_readtimer.Stop();
                FreeHandle();
            }
            //没有结束,do nothing
        }
        /// <summary>
        /// 处理得到的数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="num"></param>
        private void dealReadData(byte[] data, uint num)
        {
            Array.Resize(ref data, (int)num);
            //转换为string byte[]中是dbcs,控制台输出的为dbcs字符
            Encoding ec = Encoding.Default;//使用当前系统默认的ansi代码页
            string str = ec.GetString(data);
            //替换'\b' backspace 为空格
            str.Replace('\b', ' ');
            //产生事件
            RaiseRdEvent(RdEventType.DataEvent, str);
        }
        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            if (!m_running) return;
            //置标志
            m_running = false;
            m_readtimer.Stop();
            //结束进程
            TerminateProcess(m_processInfo.hProcess, 0);
            RaiseRdEvent(RdEventType.StopEvent, "terminated by user.");
            //释放
            FreeHandle();
        }
        //释放handle
        private void FreeHandle()
        {
            CloseHandle(m_processInfo.hThread);
            m_processInfo.hThread = IntPtr.Zero;
            CloseHandle(m_processInfo.hProcess);
            m_processInfo.hProcess = IntPtr.Zero;
            CloseHandle(m_PipeReadHandle);
            m_PipeReadHandle = IntPtr.Zero;
            CloseHandle(m_PipeWriteHandle);
            m_PipeWriteHandle = IntPtr.Zero;
        }
        /// <summary>
        /// 命令行
        /// </summary>
        private string m_szCommand;
        /// <summary>
        /// 当前目录
        /// </summary>
        private string m_szCurrentDirectory;
        /// <summary>
        /// 是否工作中
        /// </summary>
        private bool m_running;
        /// <summary>
        /// 是否工作中
        /// </summary>
        public bool Running
        {
            get { return m_running; }
        }
        /// <summary>
        /// command属性
        /// </summary>
        public string Command
        {
            set
            {
                if (m_running) return;
                m_szCommand = value;
            }
            get { return m_szCommand; }
        }
        /// <summary>
        /// 当前目录
        /// </summary>
        public string CurrentDirectory
        {
            set
            {
                if (m_running) return;
                m_szCurrentDirectory = value;
            }
            get { return m_szCurrentDirectory; }
        }
        /// <summary>
        /// 读取管道数据的毫秒数
        /// </summary>
        private uint m_dwMilliseconds;
        /// <summary>
        /// 读取时钟,使用windows时钟,避免事件产生在线程中
        /// </summary>
        private System.Windows.Forms.Timer m_readtimer;
        /// <summary>
        /// 读取管道数据的毫秒数
        /// </summary>
        public uint ReadMilliseconds
        {
            set
            {
                if (m_running) return;
                m_dwMilliseconds = value;
            }
            get { return m_dwMilliseconds; }
        }
        #region Dispose实现
        private bool disposed = false;
        public bool IsDisposed
        {
            get { return disposed; }
        }
        /// <summary>
        /// 重载dispose,释放非托管资源
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            //do something
            if (!IsDisposed)
            {
                if (disposing) { /*free managed resource*/}
                //free unmanaged resource
                Stop();
                m_readtimer.Dispose();
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // Use C# destructor syntax for finalization code.
        // This destructor will run only if the Dispose method
        // does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide destructors in types derived from this class.
        ~Redirect()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }
        #endregion
    }
}