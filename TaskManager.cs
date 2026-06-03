using System;

public interface IPrinter
{
    void Print(int jobId);
}

public interface IScanner
{
    void Scan(int jobId);
}

public class Printer : IPrinter
{
    public void Print(int jobId)
    {
        Console.WriteLine("Printing document...");
    }
}

public class Scanner : IScanner
{
    public void Scan(int jobId)
    {
        Console.WriteLine("Scanning document...");
    }
}

public class PrintScanner : IPrinter, IScanner
{
    private readonly Printer _printer;
    private readonly Scanner _scanner;

    public PrintScanner()
    {
        _printer = new Printer();
        _scanner = new Scanner();
    }

    public void Print(int jobId)
    {
        _printer.Print(jobId);
    }

    public void Scan(int jobId)
    {
        _scanner.Scan(jobId);
    }
}

public class TaskManager
{
    public void PrintTask(int jobId, IPrinter printer)
    {
        if (printer == null)
            throw new ArgumentNullException(nameof(printer));

        Console.WriteLine($"Executing Print Task: {jobId}");
        printer.Print(jobId);
    }

    public void ScanTask(int jobId, IScanner scanner)
    {
        if (scanner == null)
            throw new ArgumentNullException(nameof(scanner));

        Console.WriteLine($"Executing Scan Task: {jobId}");
        scanner.Scan(jobId);
    }
}

public class Program
{
    public static void Main()
    {
        var printer = new Printer();
        var scanner = new Scanner();
        var printScanner = new PrintScanner();

        var scheduler = new TaskManager();

        scheduler.PrintTask(101, printer);
        scheduler.ScanTask(102, scanner);
        scheduler.PrintTask(103, printScanner);
        scheduler.ScanTask(104, printScanner);
    }
}
