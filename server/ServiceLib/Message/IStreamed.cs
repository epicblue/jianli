using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.IO;

namespace WCF.ServiceLib.Message
{
    /// <summary>
    /// 消息契约（定义与 SOAP 消息相对应的强类型类）
    /// </summary>
    [MessageContract]
    public class FileWrapper
    {
        /// <summary>
        /// 指定数据成员为 SOAP 消息头
        /// </summary>
        [MessageHeader]
        public string FilePath;

        /// <summary>
        /// 指定将成员序列化为 SOAP 正文中的元素
        /// </summary>
        [MessageBodyMember]
        public Stream FileData;
    }

    /// <summary>
    /// IStreamed接口
    /// </summary>
    [ServiceContract]
    public interface IStreamed
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <remarks>
        /// 1、支持数据流传输的绑定有：BasicHttpBinding、NetTcpBinding 和 NetNamedPipeBinding
        /// 2、流数据类型必须是可序列化的 Stream 或 MemoryStream
        /// 3、传递时消息体(Message Body)中不能包含其他数据，即参数中只能有一个System.ServiceModel.MessageBodyMember
        /// </remarks>
        /// <param name="fileWrapper">WCF.ServiceLib.Message.FileWrapper</param>
        [OperationContract]
        void UploadFile(FileWrapper fileWrapper);

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="subpath">相对于lib目录的子目录</param>
        /// <returns></returns>
        [OperationContract]
        Stream DownloadFile(string subpath);

        /// <summary>
        /// 将文件从临时文件夹中转移出来.
        /// </summary>
        /// <param name="filename">文件名,不包括文件路径.</param>
        /// <returns></returns>
        [OperationContract]
        string MoveIncontrolFolder(string filename, string subpath);

        /// <summary>
        /// 在incontrol目录中移动文件.
        /// </summary>
        /// <param name="sourcepath">相对路径,相对于incontrol目录</param>
        /// <param name="descpath">相对路径,相对于incontrol目录</param>
        /// <returns></returns>
        [OperationContract]
        string MoveFileInLib(string sourcesubpath, string descsubpath);

        [OperationContract]
        string CreateSubfolderInLib(string subpath);
    }
}
