using System;
using System.Threading;

namespace Singleton
{
    class Program
    {
        private static readonly string _fileName = "C:/temp/log.txt";

        static void Main(string[] args)
        {
            var key = new ConsoleKeyInfo();
            while (!(key.Key == ConsoleKey.D6 || key.Key == ConsoleKey.NumPad6))
            {
                key = ShowMenu();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        TestSingleton();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        TestSingletonThreadSafe();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        WriteLog();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        WriteLogSingleton();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        WriteLogSingleton2();
                        break;
                }
            }
        }

        private static void Wait()
        {
            Console.WriteLine("Press ESC to continue...");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }

        private static ConsoleKeyInfo ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Test Singleton");
            Console.WriteLine("2. Test Singleton Thread Safe");
            Console.WriteLine("3. Test Write Log");
            Console.WriteLine("4. Test Write LogSingleton");
            Console.WriteLine("5. Test Write LogSingleton Thread Safe");
            Console.WriteLine("6. Exit");
            return Console.ReadKey();
        }

        public static void TestSingleton()
        {
            Console.Clear();
            Console.WriteLine("TestSingleton");
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();
            if (s1 == s2)
            {
                Console.WriteLine("Singleton works, both variables contain the same instance.");
                s1.SomeBusinessLogic();
                s2.SomeBusinessLogic();
            }
            else
            {
                Console.WriteLine("Singleton failed, variables contain different instances.");
            }

            Wait();
        }

        public static void TestSingletonThreadSafe()
        {
            Console.Clear();
            Console.WriteLine("TestSingletonThreadSafe");
            Thread process1 = new Thread(() =>
            {
                SingletonThreadSafe s1 = SingletonThreadSafe.GetInstance("Foo");
                Console.WriteLine(s1.Value);
                //Singleton s1 = Singleton.GetInstance();
                //s1.SomeBusinessLogic();
            });
            Thread process2 = new Thread(() =>
            {
                SingletonThreadSafe s2 = SingletonThreadSafe.GetInstance("bar");
                Console.WriteLine(s2.Value);
                //Singleton s2 = Singleton.GetInstance();
                //s2.SomeBusinessLogic();
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
            Wait();
        }

        public static void WriteLog()
        {
            Console.Clear();
            Console.WriteLine("WriteLog");
            LogFile log1 = new LogFile(_fileName);
            LogFile log2 = new LogFile(_fileName);
            
            log1.SaveMessage(LogType.Error, "Error 1");
            log1.SaveMessage(LogType.System, "System 1");
            log1.SaveMessage(LogType.Warning, "Warning 1");
            
            log2.SaveMessage(LogType.Error, "Error 2");
            log2.SaveMessage(LogType.System, "System 2");
            log2.SaveMessage(LogType.Warning, "Warning 2");

            Wait();
        }

        public static void WriteLogSingleton()
        {
            Console.Clear();
            Console.WriteLine("WriteLogSingleton");
            LogfileSingleton log1 = LogfileSingleton.GetInstance(_fileName);
            LogfileSingleton log2 = LogfileSingleton.GetInstance(_fileName);

            log1.SaveMessage(LogType.Error, "Error 1");
            log1.SaveMessage(LogType.System, "System 1");
            log1.SaveMessage(LogType.Warning, "Warning 1");
            log2.SaveMessage(LogType.Error, "Error 2");
            log2.SaveMessage(LogType.System, "System 2");
            log2.SaveMessage(LogType.Warning, "Warning 2");
            Wait();
        }

        public static void WriteLogSingleton2()
        {
            Console.Clear();
            Console.WriteLine("WriteLogSingleton2");
            Thread process1 = new Thread(() =>
            {
                LogFile log1 = new LogFile(_fileName);
                log1.SaveMessage(LogType.Error, "Error 1");
                log1.SaveMessage(LogType.System, "System 1");
                log1.SaveMessage(LogType.Warning, "Warning 1");
            });
            Thread process2 = new Thread(() =>
            {
                LogFile log2 = new LogFile(_fileName);

                log2.SaveMessage(LogType.Error, "Error 2");
                log2.SaveMessage(LogType.System, "System 2");
                log2.SaveMessage(LogType.Warning, "Warning 2");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
            Wait();
        }
    }
}