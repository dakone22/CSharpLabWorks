namespace LR2;


internal static class Program
{
    /// <summary>
    /// Задание 1: даны два массива a и b размерностью n и m соответственно,
    /// сформировать массив c таким образом, что первая часть — отсортированный
    /// по возрастанию массив а, а вторая часть — отсортированный по убыванию массив b.
    /// </summary>
    private static int[] Task1(int[] a, int[] b)
    {
        var n = a.Length;
        var m = b.Length;
        
        var c = new int[n + m];
        
        Array.Sort(a);
        
        Array.Sort(b);
        Array.Reverse(b);

        var cIndex = 0;
        
        foreach (var v in a)
            c[cIndex++] = v;

        foreach (var v in b)
            c[cIndex++] = v;

        return c;
    }

    private static void PrintMatrix(int[,] arr)
    {
        
        for (var i = 0; i < arr.GetLength(0); ++i) {
            for (var j = 0; j < arr.GetLength(1); ++j) {
                Console.Write(arr[i, j] + " ");
            }
            Console.WriteLine();
        }
    }


    /// <summary>
    /// Задание 2: создать двумерный массив, размерность задается пользователем,
    ///  заполнить его случайными числами в диапазоне от 0 до 9.
    /// Отсортировать элементы массива по возрастанию вначале по строкам, а затем по столбцам.
    /// Вывести на экран исходный массив, массив отсортированный построчно, массив отсортированный по столбцам. 
    /// </summary>
    /// <param name="n"></param>
    /// <param name="m"></param>
    /// <returns></returns>
    private static void Task2(int n, int m)
    {
        var random = new Random();
        
        var arr = new int[n, m];
        
        Console.WriteLine("Initial matrix:");
        for (var i = 0; i < n; ++i) {
            for (var j = 0; j < m; ++j) {
                arr[i, j] = random.Next(0, 10);
            }
        }
        PrintMatrix(arr);

        Console.WriteLine("Sorted by rows:");
        for (var rowIndex = 0; rowIndex < n; ++rowIndex) {
            for (var i = 0; i < m; ++i)
            for (var j = 0; j < i; ++j)
                if (arr[rowIndex, i] < arr[rowIndex, j]) 
                    (arr[rowIndex, i], arr[rowIndex, j]) = (arr[rowIndex, j], arr[rowIndex, i]);
        }        
        PrintMatrix(arr);
        
        Console.WriteLine("Sorted by cols:");
        for (var colIndex = 0; colIndex < n; ++colIndex) {
            for (var i = 0; i < m; ++i)
            for (var j = 0; j < i; ++j)
                if (arr[i, colIndex] < arr[j, colIndex]) 
                    (arr[i, colIndex], arr[j, colIndex]) = (arr[j, colIndex], arr[i, colIndex]);
        }        
        PrintMatrix(arr);
    }


    private static void Main(string[] args)
    {
        {
            //var a = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);
            //var b = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);
            var a = new[] {1, 5, 4, 6, 2, 7};
            var b = new[] {11, 66, 22, 44, 88};

            var c = Task1(a, b);

            Console.WriteLine(string.Join(" ", c));
        }

        {
            var n = Convert.ToInt32(Console.ReadLine());
            var m = Convert.ToInt32(Console.ReadLine());

            Task2(n, m);
        }
        
    }
}