using System;

// Паттерн Proxy
public interface IDatabase
{
    void Query(string sql);
}

public class RealDatabase : IDatabase
{
    public void Query(string sql)
    {
        Console.WriteLine($"Executing query: {sql}");
    }
}

public class DatabaseProxy : IDatabase
{
    private RealDatabase realDatabase;
    private bool hasAccess;

    public DatabaseProxy(bool access)
    {
        realDatabase = new RealDatabase();
        hasAccess = access;
    }

    public void Query(string sql)
    {
        if (hasAccess)
            realDatabase.Query(sql);
        else
            Console.WriteLine("Access denied.");
    }
}

// Паттерн Adapter
public class ExternalLogger
{
    public void LogMessage(string message)
    {
        Console.WriteLine($"External log: {message}");
    }
}

public interface ILogger
{
    void Log(string message);
}

public class LoggerAdapter : ILogger
{
    private ExternalLogger externalLogger;

    public LoggerAdapter(ExternalLogger logger)
    {
        externalLogger = logger;
    }

    public void Log(string message)
    {
        externalLogger.LogMessage(message);
    }
}

// Паттерн Bridge
public interface IDevice
{
    void Print(string data);
}

public class Monitor : IDevice
{
    public void Print(string data)
    {
        Console.WriteLine($"Displaying on monitor: {data}");
    }
}

public class Printer : IDevice
{
    public void Print(string data)
    {
        Console.WriteLine($"Printing: {data}");
    }
}

public abstract class Output
{
    protected IDevice device;

    public Output(IDevice device)
    {
        this.device = device;
    }

    public abstract void Render(string data);
}

public class TextOutput : Output
{
    public TextOutput(IDevice device) : base(device) { }

    public override void Render(string data)
    {
        device.Print($"Text: {data}");
    }
}

public class ImageOutput : Output
{
    public ImageOutput(IDevice device) : base(device) { }

    public override void Render(string data)
    {
        device.Print($"Image: {data}");
    }
}

// Главный класс программы
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Паттерн Proxy ===");
        IDatabase userDb = new DatabaseProxy(false);
        IDatabase adminDb = new DatabaseProxy(true);

        userDb.Query("SELECT * FROM Users");
        adminDb.Query("SELECT * FROM Admins");

        Console.WriteLine("\n=== Паттерн Adapter ===");
        ExternalLogger extLogger = new ExternalLogger();
        ILogger logger = new LoggerAdapter(extLogger);

        logger.Log("This is a test log message.");

        Console.WriteLine("\n=== Паттерн Bridge ===");
        IDevice monitor = new Monitor();
        IDevice printer = new Printer();

        Output textMonitor = new TextOutput(monitor);
        Output textPrinter = new TextOutput(printer);

        textMonitor.Render("Hello, World!");
        textPrinter.Render("Hello, Printer!");

        Output imageMonitor = new ImageOutput(monitor);
        imageMonitor.Render("01010101");
    }
}
