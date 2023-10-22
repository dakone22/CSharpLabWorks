using System;
using System.Reflection;

namespace LR7
{
    // 4. Создаем класс атрибута
    [AttributeUsage(AttributeTargets.Property)]
    public class MyAttribute : Attribute
    {
        public string Description { get; }

        public MyAttribute(string description)
        {
            Description = description;
        }
    }

    // 2. Создаем класс с конструкторами, свойствами и методами
    public class MyClass
    {
        public MyClass()
        {
        }

        [MyAttribute("Это свойство с атрибутом")]
        public string PropertyWithAttribute { get; set; }

        public int PropertyWithoutAttribute { get; set; }

        public MyAttribute MyAttribute
        {
            get => default;
            set
            {
            }
        }

        public void Method1()
        {
            Console.WriteLine("Вызван Method1");
        }

        public void Method2()
        {
            Console.WriteLine("Вызван Method2");
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 3. Выводим информацию о конструкторах, свойствах и методах класса с использованием рефлексии
            Type myClassType = typeof(MyClass);

            Console.WriteLine("Конструкторы:");
            ConstructorInfo[] constructors = myClassType.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor);
            }

            Console.WriteLine("\nСвойства:");
            PropertyInfo[] properties = myClassType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property);
            }

            Console.WriteLine("\nМетоды:");
            MethodInfo[] methods = myClassType.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method);
            }

            // 5. Выводим только те свойства, которым назначен атрибут
            Console.WriteLine("\nСвойства с атрибутом:");
            foreach (PropertyInfo property in properties)
            {
                if (Attribute.IsDefined(property, typeof(MyAttribute)))
                {
                    Console.WriteLine(property);
                }
            }

            // 6. Вызываем один из методов с использованием рефлексии
            Console.WriteLine("\nВызываем метод Method1:");
            MyClass myInstance = new MyClass();
            MethodInfo methodToInvoke = myClassType.GetMethod("Method1");
            methodToInvoke.Invoke(myInstance, null);
        }
    }
}