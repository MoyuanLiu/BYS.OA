using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BYS.OA.Common
{
    //public delegate void WriteLogDel(string str);
    public class LogHelper
    {
        public static Queue<string> ExceptionStringQueue = new Queue<string>();
        public static List<ILogWriter> LogWriterList = new List<ILogWriter>();

        //public static WriteLogDel WriteLogDelFunc;
        static LogHelper()
        {
            //WriteLogDelFunc = new WriteLogDel(WriteLogToFile);
            //WriteLogDelFunc += WriteLogToDb;
            //把从队列中获取错误消息写写到 日志文件里面去
            //LogWriterList.Add(new TextFileWriter());
            //LogWriterList.Add(new SqlServerWriter());
            LogWriterList.Add(new Log4NetWritter());
            ThreadPool.QueueUserWorkItem(o=> 
            {
                lock (ExceptionStringQueue)
                {
                    if (ExceptionStringQueue.Count > 0)
                    {
                        string str = ExceptionStringQueue.Dequeue();
                        //变化点：有可能写到日志文件，有可能写到数据库里面去。有可能多个地方去
                        //执行委托方法,把异常信息写到委托里面去。
                        //WriteLogDelFunc(str);
                        //ILogWriter writer = new TextFileWriter();
                        //writer.WriteLogInfo(str);
                        foreach (var logWriter in LogWriterList)
                        {
                            logWriter.WriteLogInfo(str);
                        }
                    }
                    else
                    {
                        Thread.Sleep(30);
                    }
                    
                }
            });
        }
        //public static void WriteLogToFile(string txt)
        //{

        //}

        //public static void WriteLogToDb(string txt)
        //{

        //}
        public static void WriteLog(string exceptionText)
        {
            lock (ExceptionStringQueue)
            {
                ExceptionStringQueue.Enqueue(exceptionText);
                //if (ExceptionStringQueue.Count>100)
                //{
                //    //...
                //}
            }
        }
    }
}
