using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WohooDigitalProject.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LogServices
    {
        protected static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void AddLog(string message)
        {
            logger.Info(message);
        }
    }
}
