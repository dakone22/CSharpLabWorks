using System;

namespace LR8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите первое вещественное число: ");
                string input1 = Console.ReadLine();

                if (!double.TryParse(input1, out double number1))
                {
                    throw new FormatException("Ошибка преобразования");
                }

                Console.Write("Введите второе вещественное число: ");
                string input2 = Console.ReadLine();

                if (!double.TryParse(input2, out double number2))
                {
                    throw new FormatException("Ошибка преобразования");
                }

                if (input1.Length > 15 || input2.Length > 15)
                {
                    throw new Exception("Введено слишком длинное число");
                }

                if (number2 == 0)
                {
                    throw new DivideByZeroException("Деление на ноль");
                }

                double result = number1 / number2;
                Console.WriteLine($"Результат деления: {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}