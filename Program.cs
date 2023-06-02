namespace FileTransferServer;
public class Program
{
    private static void Main(string[] args)
    {
        var fts = new FileTransferServer();
        fts.Start();
        Console.ReadKey();
    }
}