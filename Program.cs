using System;
using System.Diagnostics;
using System.Reflection;

// Получить имя текущего метода в C#

namespace GetCurrentMethodName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Использование MethodBase.GetCurrentMethod()
            string currentMethod = MethodBase.GetCurrentMethod()?.Name;
            Console.WriteLine("Текущий метод " + currentMethod);

            // Использование StackTrace Учебный класс (System.Diagnostics)
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(0);
            string currentMethod2 = stackFrame.GetMethod().Name;
            Console.WriteLine("Текущий метод " + currentMethod2);
            // или
            StackFrame stackFrame2 = new StackFrame(0);
            string currentMethod3 = stackFrame2.GetMethod().Name;
            Console.WriteLine("Текущий метод " + currentMethod3);
            // или
            string currentMethod4 = GetCurrentMethodName();
            Console.WriteLine("Текущий метод " + currentMethod4);

            // Использование оператора nameof
            Unique();

        }

        public static string GetCurrentMethodName()
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            return stackFrame.GetMethod().Name;
        }

        private static void Unique()
        {
            string name = nameof(Unique);

            Console.WriteLine("Текущий метод " + name);
        }
    }
}