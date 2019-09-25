using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    //class LogfileSingleton
    public class LogfileSingleton
    {
        private StreamWriter _sw;
        private readonly string _fileName;

        //Constructor Privado
        private LogfileSingleton(string fileName)
        {
            _fileName = fileName;
        }

        //Propiedad privada estatica
        private static LogfileSingleton _instance;

        //Metodo de acceso publico para obtener la instancia
        public static LogfileSingleton GetInstance(string fileName)
        {
            if (_instance == null)
            {
                _instance = new LogfileSingleton(fileName);
            }
            return _instance;
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
