using System;
using System.Collections.Generic;

namespace LR10
{
    internal class Product : IComparable<Product>
    {
        private readonly double _weightInKg;

        private double WeightInKg => _weightInKg;

        private string OriginalQuantity { get; }

        private string Name { get; }

        public Product(string quantity, string name)
        {
            if (!TryParseQuantity(quantity, out _weightInKg))
                throw new ArgumentException("Invalid value_and_quantity format.");

            OriginalQuantity = quantity;
            Name = name;
        }

        private static bool TryParseQuantity(string valueAndQuantity, out double result)
        {
            result = 0;

            if (string.IsNullOrEmpty(valueAndQuantity))
                return false;

            var index = 0;
            while (index < valueAndQuantity.Length && char.IsNumber(valueAndQuantity[index])) index++;

            var quantity = valueAndQuantity.Substring(index, valueAndQuantity.Length - index);
            var value = valueAndQuantity.Substring(0, index);

            if (!double.TryParse(value, out var numericValue)) return false;
            switch (quantity)
            {
                case "г":
                    result = numericValue / 1000.0; // Convert grams to kilograms
                    return true;
                case "кг":
                    result = numericValue;
                    return true;
                case "т":
                    result = numericValue * 1000.0; // Convert tons to kilograms
                    return true;
                case "л":
                    result = numericValue; // stupid assumption that the density
                    // will be approximately equal to the density of water
                    return true;
                default:
                    return false;
            }
        }

        public int CompareTo(Product other) => other == null ? 1 : WeightInKg.CompareTo(other.WeightInKg);

        public override string ToString() => $"{OriginalQuantity} {Name}";
    }
    
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product("3кг", "Апельсины"),
                new Product("10л", "Квас"),
                new Product("100л", "Вода"),
                new Product("3780г", "Шоколад"),
                new Product("10т", "Бананы"),
                new Product("13кг", "Мангал")
            };

            Console.WriteLine("Unsorted Products:");
            foreach (var product in products) Console.WriteLine(product);

            products.Sort();

            Console.WriteLine("\nSorted Products:");
            foreach (var product in products) Console.WriteLine(product);
        }
    }
}