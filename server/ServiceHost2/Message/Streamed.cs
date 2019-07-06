using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;

namespace WCF.ServiceHost2.Message
{
    /// <summary>
    /// host WCF.ServiceLib.Message.Streamed的类
    /// </summary>
    public class Streamed
    {
        /// <summary>
        /// 启动WCF.ServiceLib.Message.Streamed服务
        /// </summary>
        public void Launch()
        {
            ServiceHost host = new ServiceHost(typeof(WCF.ServiceLib.Message.Streamed));
            host.Open();
            Console.WriteLine("服务已启动。(JianLi3 File Service)");
#if HOME
            Console.WriteLine("位置：家中");
#endif
#if OFFICE
            Console.WriteLine("位置：办公室");
#endif
            Console.WriteLine("临时文件夹：" + WCF.ServiceLib.Message.Streamed.incomingfolder);
            Console.WriteLine("文件库文件夹：" + WCF.ServiceLib.Message.Streamed.libfolder);
            Console.WriteLine();
        }
    }
}
