using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoStructurizationUtility.Kernel.Logging.Enums;

namespace PhotoStructurizationUtility.Kernel.Logging
{
    public class LoggerSingleton
    {
        public Action<LogNote> Logged { get; set; }
        
        private static LoggerSingleton _instance;

        public static LoggerSingleton GetLogger()
        {
            return _instance ?? (_instance = new LoggerSingleton());
        }

        public void Log(string message, LogNoteType type = LogNoteType.Message, string origin = "")
        {
            Logged(new LogNote(String.IsNullOrWhiteSpace(origin) ? message : $"{origin}> {message}", type));
        }
    }
}
