using System;

namespace LR6
{
    delegate TResult MyDelegate<T1, T2, TResult>(T1 arg1, T2 arg2);

    internal class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }

        static void PerformOperation<T1, T2, TResult>(
            MyDelegate<T1, T2, TResult> operation, T1 arg1, T2 arg2)
        {
            TResult result = operation(arg1, arg2);
            Console.WriteLine($"Результат операции: {result}");
        }

        static void PerformOperationWithFunc<T1, T2, TResult>(
            Func<T1, T2, TResult> operation, T1 arg1, T2 arg2)
        {
            TResult result = operation(arg1, arg2);
            Console.WriteLine($"func({arg1}, {arg2}) = {result}");
        }

        static void Main(string[] args)
        {
            // Используем наш собственный делегат MyDelegate<>
            MyDelegate<int, int, int> customDelegate = Add;
            PerformOperation(customDelegate, 5, 3);
            PerformOperation((a, b) => a * b, 5, 3);

            // Используем обобщенный делегат Func<>
            PerformOperationWithFunc(Add, 4, 2);
            Func<int, int, int> funcDelegate = (a, b) => a * b;
            PerformOperationWithFunc(funcDelegate, 4, 6);
        }
    }
}