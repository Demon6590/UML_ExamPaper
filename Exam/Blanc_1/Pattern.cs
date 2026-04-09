namespace Exam.Blanc_1;

public record Computer(
    string CPU,
    int RAM,
    string Storage,
    string? GraphicsCard = null)
{
    public override string ToString() =>
        $"Computer: CPU={CPU}, RAM={RAM}GB, Storage={Storage}, Graphics={GraphicsCard ?? "Integrated"}";
}


public class ComputerBuilder
{
    private string _cpu = "";
    private int _ram = 0;
    private string _storage = "";
    private string? _graphicsCard;

    public ComputerBuilder WithCpu(string cpu)
    {
        _cpu = cpu;
        return this;
    }

    public ComputerBuilder WithRam(int ramGb)
    {
        _ram = ramGb;
        return this;
    }

    public ComputerBuilder WithStorage(string storage)
    {
        _storage = storage;
        return this;
    }

    public ComputerBuilder WithGraphicsCard(string graphicsCard)
    {
        _graphicsCard = graphicsCard;
        return this;
    }

    public Computer Build() =>
        new(_cpu, _ram, _storage, _graphicsCard);
}

class Program
{
    static void Main()
    {

        var officePc = new ComputerBuilder()
            .WithCpu("Intel i5-12400")
            .WithRam(16)
            .WithStorage("SSD 512GB")
            .Build();

        Console.WriteLine(officePc);

        var gamingPc = new ComputerBuilder()
            .WithCpu("AMD Ryzen 7 7800X3D")
            .WithRam(32)
            .WithStorage("SSD 2TB")
            .WithGraphicsCard("RTX 4080")
            .Build();

        Console.WriteLine(gamingPc);
    }
}