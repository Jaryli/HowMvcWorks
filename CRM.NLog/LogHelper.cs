using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.NLog
{
    public class LogHelper
    {
        static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
        static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");
        static readonly log4net.ILog logmonitor = log4net.LogManager.GetLogger("logdebug");

        public static void Error(string ErrorMsg, Exception ex = null)
        {
            if (ex != null)
            {
                logerror.Error(ErrorMsg, ex);
            }
            else
            {
                logerror.Error(ErrorMsg);
            }
        }

        public static void Info(string Msg)
        {
            loginfo.Info(Msg);
        }

        public static void Monitor(string Msg)
        {
            logmonitor.Info(Msg);
        }

    }
}
