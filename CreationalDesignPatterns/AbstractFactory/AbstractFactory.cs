using System;


interface IProcessor
{
    string GetProcessorType();
}

class IntelProcessor : IProcessor
{
    public string GetProcessorType()
    {
        return "Intel Processor";
    }
}
class AMDFXProcessor : IProcessor
{
    public string GetProcessorType()
    {
        return "AMD FX Processor";
    }
}

interface IMemory
{
    string GetMemoryType();
}

class CorsairMemory : IMemory
{
    public string GetMemoryType()
    {
        return "Corsair Memory";
    }
}
class KingstonMemory : IMemory
{
    public string GetMemoryType()
    {
        return "Kingston Memory";
    }
}
interface IComputerFactory
{
    IProcessor CreateProcessor();
    IMemory CreateMemory();
}
class HighPerformanceComputerFactory : IComputerFactory
{
    public IProcessor CreateProcessor()
    {
        return new IntelProcessor();
    }

    public IMemory CreateMemory()
    {
        return new CorsairMemory();
    }
}
class BudgetComputerFactory : IComputerFactory
{
    public IProcessor CreateProcessor()
    {
        return new AMDFXProcessor();
    }

    public IMemory CreateMemory()
    {
        return new KingstonMemory();
    }
}

class Computer
{
    private IProcessor _processor;
    private IMemory _memory;

    public Computer(IComputerFactory factory)
    {
        _processor = factory.CreateProcessor();
        _memory = factory.CreateMemory();
    }

    public void DisplayConfiguration()
    {
        Console.WriteLine($"Processor: {_processor.GetProcessorType()}");
        Console.WriteLine($"Memory: {_memory.GetMemoryType()}");
    }
}

class Program
{
    static void Main()
    {
        IComputerFactory highPerformanceFactory = new HighPerformanceComputerFactory();
        Computer highPerformanceComputer = new Computer(highPerformanceFactory);
        highPerformanceComputer.DisplayConfiguration();

        Console.WriteLine();

        IComputerFactory budgetFactory = new BudgetComputerFactory();
        Computer budgetComputer = new Computer(budgetFactory);
        budgetComputer.DisplayConfiguration();
    }
}
