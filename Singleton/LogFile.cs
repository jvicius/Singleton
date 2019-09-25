using System.Collections.Concurrent;
using System.IO;

namespace Singleton
{
    public enum LogType
    {
        Error,
        Warning,
        System
    }

    public class LogFile
    {
        private StreamWriter _sw;
        private readonly string _fileName;

        public LogFile(string fileName)
        {
            _fileName = fileName;
        }
        
        public void SaveMessage(LogType logType, string message)
        {
            if (_sw == null)
            {
                _sw = new StreamWriter(_fileName, true);
            }
            _sw.WriteLine($"{logType}|{message}|{System.DateTime.Now}");
            _sw.Flush();
        }
    }
}
