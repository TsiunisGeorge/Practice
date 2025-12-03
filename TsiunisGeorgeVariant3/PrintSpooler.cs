// Разработайте класс PrintSpooler, который имитирует очередь заданий на печать с помощью Queue<string>.
// Реализуйте методы для добавления задания в очередь и "печати" (извлечения и возврата) следующего задания.
// Соблюдайте принципы SOLID.
public interface IJobConsumer
{
    void AddJob(string documentPath);
}

public interface IJobProducer
{
    string ProcessNextJob();
}

// S -- реализует только работу с очередью
// O -- закрываем модификацию базовых интерфейсов, расширяем через наследование от новых интерфейсов наследников базовых
// L -- за счёт реализации имеем общий интерфейс который будет общим для всех наследников
// I -- Разделили интерфейс на два, для пользователя и исполнителя
// D -- тоже за счёт интерфейса выполнен
public class PrintSpooler : IJobConsumer, IJobProducer
{
    private readonly Queue<string> _jobQueue;

    public PrintSpooler(Queue<String>? jobQueue = null)
    {
        _jobQueue = jobQueue ?? new Queue<string>();
    }

    public void AddJob(string documentPath)
    {
        if (string.IsNullOrEmpty(documentPath)) throw new ArgumentException("Path cannot be null or empty");
        _jobQueue.Enqueue(documentPath);
    }

    public string ProcessNextJob()
    {
        if (_jobQueue.Count == 0) throw new InvalidOperationException("Job queue is empty");
        return _jobQueue.Dequeue();
    }
}