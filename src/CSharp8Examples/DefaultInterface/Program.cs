using System;
using System.Diagnostics;

//doc: https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/default-interface-methods.md

namespace DefaultInterfaceImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();

            logger.LogError("error");
            logger.LogInfo("info");

            ((ILogger)logger).LogDebug("debug");

            Console.ReadLine();
        }
    }

    interface ILogger
    {
        void LogDebug<T>(T input) => Debug.Write(input?.ToString());

        void LogInfo<T>(T input);

        void LogError<T>(T input) => LogDebug(input);
    }

    class ConsoleLogger : ILogger
    {
        public void LogInfo<T>(T input)
        {
            Console.WriteLine(input?.ToString());
        }

        public void LogError<T>(T input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(input?.ToString());
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
