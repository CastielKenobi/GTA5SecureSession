using System;
using System.IO;
using SecureSessionGaming.Config;
using System.Runtime.CompilerServices;

namespace SecureSessionGaming.Support.Log
{
    public class LogSupport
    {
        public static LogLevel LOG_LEVEL = ApplicationConfig.DEFAULT_LOG_LEVEL;

        public const string LOG_FILE = "ssg.log";
        
        public enum LogLevel : int
        {
            DEBUG = 0,
            INFO = 1,
            ERROR = 2
        }

        public static void Debug(
            string message,
            [CallerFilePath] string fileName = "",
            [CallerMemberName] string methodName = null,
            [CallerLineNumber] int lineNumber = 0
        )
        {
            Log(LogLevel.DEBUG, message, fileName, methodName, lineNumber);
        }

        public static void Info(
            string message,
            [CallerFilePath] string fileName = "",
            [CallerMemberName] string methodName = null,
            [CallerLineNumber] int lineNumber = 0
        )
        {
            Log(LogLevel.INFO, message, fileName, methodName, lineNumber);
        }

        public static void Error(
            string message,
            [CallerFilePath] string fileName = "",
            [CallerMemberName] string methodName = null,
            [CallerLineNumber] int lineNumber = 0
        )
        {
            Log(LogLevel.ERROR, message, fileName, methodName, lineNumber);
        }

        public static LogLevel GetLogLevel(string level)
        {
            LogLevel logLevel;
            switch (level.ToLower())
            {
                case "error":
                    logLevel = LogLevel.ERROR;
                    break;
                case "debug":
                    logLevel = LogLevel.DEBUG;
                    break;
                default:
                    logLevel = ApplicationConfig.DEFAULT_LOG_LEVEL;
                    break;
            }
            return logLevel;
        }

        //
        // private

        public static void Log(
            LogLevel level,
            string message,
            string fileName,
            string methodName,
            int lineNumber
        )
        {
            if (level >= LOG_LEVEL)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + LOG_FILE;

                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("-------- Log --------");
                    }
                }

                using (StreamWriter sw = File.AppendText(path))
                {
                    // <Filename.cs:method:lineNumber> DATE [LEVEL] MESSAGE
                    sw.WriteLine(
                        "<" + fileName + ":" + methodName + ":" + lineNumber + "> "
                        + DateTime.Now.ToString()
                        + " ["
                        + level.ToString()
                        + "] "
                        + message
                    );
                }
            }
        }
    }
}
