﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYS.OA.Common
{
    public class Log4NetWritter : ILogWriter
    {
        public void WriteLogInfo(string txt)
        {
            ILog logWrite = log4net.LogManager.GetLogger("Demo");
            logWrite.Error(txt);
        }
    }
}
