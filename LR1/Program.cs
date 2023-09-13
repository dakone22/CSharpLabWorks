using System;
using System.Diagnostics;

namespace LR1;

public interface IOperation
{
    public double? Execute(double[] arguments);
}

public abstract class Operation2 : IOperation
{
    protected abstract double? Calculate(double x, double y);

    public double? Execute(double[] arguments)
    {
        return arguments.Length != 2 ? null : Calculate(arguments[0], arguments[1]);
    }
}

public class SumOperation : Operation2
{
    protected override double? Calculate(double x, double y)
    {
        return x + y;
    }
}

public class SubOperation : Operation2
{
    protected override double? Calculate(double x, double y)
    {
        return x - y;
    }
}

public class MulOperation : Operation2
{
    protected override double? Calculate(double x, double y)
    {
        return x * y;
    }
}

public class DivOperation : Operation2
{
    private const double Precision = 1e-6;

    protected override double? Calculate(double x, double y)
    {
        if (Math.Abs(y) < Precision) {
            Console.WriteLine("Division by zero!");
            return null;
        }

        return x / y;
    }
}

public interface IReaderWriter
{
    void Write(string s);
    uint ReadUInt();
    double ReadDouble();
}

public class ConsoleReaderWriter : IReaderWriter
{
    public void Write(string s)
    {
        Console.Write(s);
    }

    public uint ReadUInt()
    {
        while (true) {
            var line = Console.ReadLine();
            try {
                return Convert.ToUInt32(line);
            } catch (FormatException) {
                Write($"The input string '{line}' was not in a correct format of uint32!\n");
            }
        }
    }

    public double ReadDouble()
    {
        while (true) {
            var line = Console.ReadLine();
            try {
                return Convert.ToDouble(line);
            } catch (FormatException) {
                Write($"The input string '{line}' was not in a correct format of double!\n");
            }
        }
    }
}

public interface ICalculator
{
    /// <summary>
    /// Предоставляет возможность пользователю выбрать операцию
    /// </summary>
    public void SelectOperation();

    /// <summary>
    /// Предоставляет возможность пользователю ввода аргументов для выбранной операции
    /// </summary>
    public void InputArguments();

    /// <summary>
    /// Выполняет выбранную операциию с введёнными аргументами
    /// </summary>
    public void Calculate();
}

public class ConsoleCalculator : ICalculator
{
    private readonly IReaderWriter _readerWriter;
    private readonly IOperation[] _operations;
    private IOperation? _selectedOperation;
    private double[]? _arguments;

    public ConsoleCalculator(IReaderWriter readerWriter, IOperation[] operations)
    {
        _readerWriter = readerWriter;
        _operations = operations;
    }

    public void SelectOperation()
    {
        _selectedOperation = null;

        _readerWriter.Write("Select operation:\n");
        do {
            for (uint i = 0; i < _operations.Length; ++i) {
                _readerWriter.Write($"{i}. {_operations[i]}\n");
            }

            _readerWriter.Write("> ");
            var operationIndex = _readerWriter.ReadUInt();

            if (operationIndex < _operations.Length) {
                _selectedOperation = _operations[operationIndex];
            }
        } while (_selectedOperation == null);
    }

    public void InputArguments()
    {
        _readerWriter.Write("Arg1> ");
        var arg1 = _readerWriter.ReadDouble();

        _readerWriter.Write("Arg2> ");
        var arg2 = _readerWriter.ReadDouble();

        _arguments = new[] { arg1, arg2 };
    }

    public void Calculate()
    {
        Debug.Assert(_selectedOperation != null, nameof(_selectedOperation) + " != null");
        Debug.Assert(_arguments != null, nameof(_arguments) + " != null");

        var result = _selectedOperation.Execute(_arguments);

        _readerWriter.Write($"Result: {result}\n");
    }
}

internal static class Program
{
    public static void Main()
    {
        ICalculator calculator = new ConsoleCalculator(
            new ConsoleReaderWriter(),
            new IOperation[] {
                new SumOperation(),
                new SubOperation(),
                new MulOperation(),
                new DivOperation()
            });

        while (true) {
            calculator.SelectOperation();
            calculator.InputArguments();
            calculator.Calculate();
        }
    }
}