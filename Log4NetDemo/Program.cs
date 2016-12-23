using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4NetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //从配置文件读取log4net配置 
            log4net.Config.XmlConfigurator.Configure();
            ILog logWritter = log4net.LogManager.GetLogger("DemoWritter");

            logWritter.Debug("debug级别的消息");
            logWritter.Error("error级别的消息");
            Console.ReadKey();
        }
    }
}
