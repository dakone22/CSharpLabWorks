using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace LR9
{
    [DataContract]
    internal class Customer
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public double Discount { get; set; }
    }

    [DataContract]
    internal class Product
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal Price { get; set; }
    }

    [DataContract]
    internal class OrderLine
    {
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public Product Product { get; set; }
    }

    [DataContract]
    internal class Order
    {
        [DataMember]
        public int OrderNumber { get; set; }
        [DataMember]
        public Customer Customer { get; set; }
        [DataMember]
        public decimal Discount { get; set; }
        [DataMember]
        public decimal TotalCost { get; set; }
        [DataMember]
        public List<OrderLine> OrderLines { get; set; }
    }

    internal class ProductDatabase
    {
        private readonly Dictionary<string, Product> _products = new Dictionary<string, Product>();

        public void AddProduct(string name, decimal price)
        {
            _products[name] = new Product { Name = name, Price = price };
        }

        public Product GetProduct(string name)
        {
            if (_products.TryGetValue(name, out var product))
                return product;

            Console.WriteLine("Товар не найден");
            return null;
        }
    }

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var productDatabase = new ProductDatabase();
            // Заполнение базы данных товаров
            productDatabase.AddProduct("Товар1", 10.0m);
            productDatabase.AddProduct("Товар2", 20.0m);
            productDatabase.AddProduct("Товар3", 30.0m);

            // Ввод данных о покупателе
            Console.WriteLine("Введите имя покупателя:");
            var customerName = Console.ReadLine();
            Console.WriteLine("Введите адрес покупателя:");
            var customerAddress = Console.ReadLine();
            Console.WriteLine("Введите скидку покупателя (в процентах):");
            var customerDiscount = double.Parse(Console.ReadLine());

            var customer = new Customer
            {
                Name = customerName,
                Address = customerAddress,
                Discount = customerDiscount
            };

            // Создание заказа
            var order = new Order
            {
                OrderNumber = GenerateOrderNumber(),
                Customer = customer,
                Discount = (decimal)(customer.Discount / 100.0),
                OrderLines = new List<OrderLine>()
            };
            
            // Формирование строк заказа
            while (true)
            {
                Console.WriteLine("Введите код товара (или 'конец' для завершения):");
                var productCode = Console.ReadLine();
                if (productCode.ToLower() == "конец")
                    break;

                var product = productDatabase.GetProduct(productCode);
                if (product == null) continue;
                
                Console.WriteLine("Введите количество:");
                var quantity = int.Parse(Console.ReadLine());
                var orderLine = new OrderLine
                {
                    Quantity = quantity,
                    Product = product
                };
                order.OrderLines.Add(orderLine);
            }

            // Вычисление общей стоимости заказа
            var totalCost = CalculateTotalCost(order);
            order.TotalCost = totalCost;

            // Сохранение информации о заказе в файле
            var fileName = $"Order_{order.OrderNumber}.json";
            SerializeOrder(order, fileName);
            Console.WriteLine($"Заказ сохранен в файле {fileName}");
        }

        private static int _orderCounter = 1;

        private static int GenerateOrderNumber() => _orderCounter++;

        private static decimal CalculateTotalCost(Order order)
        {
            var totalCost = order.OrderLines.Sum(orderLine => orderLine.Quantity * orderLine.Product.Price);
            return totalCost * (1 - order.Discount);
        }

        private static void SerializeOrder(Order order, string fileName)
        {
            var serializer = new DataContractJsonSerializer(typeof(Order));
            using (var fs = new FileStream(fileName, FileMode.Create)) serializer.WriteObject(fs, order);
        }
    }
}
