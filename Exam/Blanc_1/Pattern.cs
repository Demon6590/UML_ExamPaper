namespace Exam.Blanc_1;

public interface IObserver
{
    void Update(string news);
}

public interface IObservable
{
    void Subscribe(IObserver observer);
    void Unsubscribe(IObserver observer);
    void Notify();
}

public class NewsAgency : IObservable
{
    private List<IObserver> _observers = new List<IObserver>();
    private string _latestNews;

    public void SetNews(string news)
    {
        _latestNews = news;
        Notify();
    }

    public void Subscribe(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
            observer.Update(_latestNews);
    }
}

public class Subscriber : IObserver
{
    private string _name;

    public Subscriber(string name)
    {
        _name = name;
    }

    public void Update(string news)
    {
        Console.WriteLine($"{_name} получил новость: {news}");
    }
}

class Program
{
    static void Main()
    {
        NewsAgency agency = new NewsAgency();
        Subscriber sub1 = new Subscriber("Иван");
        Subscriber sub2 = new Subscriber("Мария");

        agency.Subscribe(sub1);
        agency.Subscribe(sub2);

        agency.SetNews("Первая новость!");

        agency.Unsubscribe(sub1);
        agency.SetNews("Вторая новость (только для Марии).");

        Console.ReadKey();
    }
}