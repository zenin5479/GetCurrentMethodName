using System;
using System.Diagnostics;
using System.Reflection;

// Получить имя текущего метода в C#

namespace GetCurrentMethodName
{
    internal class Program
    {
        private static void Main()
        {
            // Использование StackTrace Учебный класс (System.Diagnostics)
            Console.WriteLine("Метод {0}: Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
            // или
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

            // Использование метода MethodBase.GetCurrentMethod()
            string currentMethod = MethodBase.GetCurrentMethod()?.Name;
            Console.WriteLine("Текущий метод " + currentMethod);
            // или
            MethodBase m = MethodBase.GetCurrentMethod();
            if (m != null)
                if (m.ReflectedType != null)
                    Console.WriteLine("Класс {0}. Текущий метод {1}", m.ReflectedType.Name, m.Name);

            // Использование оператора nameof
            Unique();

            // Использование метода Type.GetMethod
            MethodInfo mInfo;
            // Получить MethodA(int i, int j)
            mInfo = typeof(Program)
                .GetMethod("MethodA",
                BindingFlags.Public | BindingFlags.Instance,
                null,
                CallingConventions.Any,
                new[] { typeof(int), typeof(int) },
                null);
            Console.WriteLine("Найденный метод: {0}", mInfo);

            // Получить MethodA(int[] i)
            mInfo = typeof(Program)
                .GetMethod("MethodA",
                BindingFlags.Public | BindingFlags.Instance,
                null,
                CallingConventions.Any,
                new[] { typeof(int[]) },
                null);
            Console.WriteLine("Найденный метод: {0}", mInfo);

            // Получить MethodA(int* i)
            mInfo = typeof(Program)
                .GetMethod("MethodA",
                BindingFlags.Public | BindingFlags.Instance,
                null,
                CallingConventions.Any,
                new[] { typeof(int).MakePointerType() },
                null);
            Console.WriteLine("Найденный метод: {0}", mInfo);

            // Получить MethodA(ref int r)
            mInfo = typeof(Program)
                .GetMethod("MethodA",
                BindingFlags.Public | BindingFlags.Instance,
                null,
                CallingConventions.Any,
                new[] { typeof(int).MakeByRefType() },
                null);
            Console.WriteLine("Найденный метод: {0}", mInfo);

            // Получить MethodA(int i, out int o)
            mInfo = typeof(Program)
                .GetMethod("MethodA",
                BindingFlags.Public | BindingFlags.Instance,
                null,
                CallingConventions.Any,
                new[] { typeof(int), typeof(int).MakeByRefType() },
                null);
            Console.WriteLine("Найденный метод: {0}", mInfo);

            Console.WriteLine("Метод {0}: End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Нажмите любую клавишу");
            Console.Read();
        }

        // Методы получения:

        public void MethodA(int i, int j) { }

        public void MethodA(int[] i) { }

        public unsafe void MethodA(int* i) { }

        public void MethodA(ref int r) { }

        // Метод, который принимает параметр out:
        public void MethodA(int i, out int o) { o = 100; }

        private static string GetCurrentMethodName()
        {
            StackTrace stackTrace3 = new StackTrace();
            StackFrame stackFrame3 = stackTrace3.GetFrame(1);
            return stackFrame3.GetMethod().Name;
        }

        private static void Unique()
        {
            string name = nameof(Unique);

            Console.WriteLine("Текущий метод " + name);
        }
    }
}