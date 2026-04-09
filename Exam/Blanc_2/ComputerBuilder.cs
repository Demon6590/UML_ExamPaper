namespace Exam.Blanc_2;

public class Computer
{
    public string Cpu { get; }
    public int Ram { get; }
    public string Storage { get; }
    public string GraphicsCard { get; }

    internal Computer(string cpu, int ram, string storage, string graphicsCard)
    {
        Cpu = cpu;
        Ram = ram;
        Storage = storage;
        GraphicsCard = graphicsCard;
    }

    public override string ToString() =>
        $"Computer Configuration:\n - CPU: {Cpu}\n - RAM: {Ram}GB\n - Storage: {Storage}\n - GPU: {GraphicsCard}\n";
}

public interface IComputerBuilder
{
    IComputerBuilder SetCpu(string cpu);
    IComputerBuilder SetRam(int ram);
    IComputerBuilder SetGraphicsCard(string storage);
    Computer Build();
}

public class ComputerBuilder : IComputerBuilder
{
    private string _cpu = "Default CPU";
    private int _ram = 8;
    private string _storage = "Default SSD";
    private string _graphicsCard = "Integrated Graphics";


    public IComputerBuilder SetCpu(string cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IComputerBuilder SetRam(int ram)
    {
        _ram = ram;
        return this;
    }

    public IComputerBuilder SetGraphicsCard(string storage)
    {
        _storage = storage;
        return this;
    }

    public Computer Build()
    {
        return new Computer(_cpu, _ram, _storage, _graphicsCard);
    }
}