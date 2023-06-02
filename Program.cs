using sn0x.lib.SocketFileManager;

internal class Program
{
    private static void WriteFile(string senderIp, string fileContent)
    {
        string tempFolder = "temp2";
        if (!Directory.Exists(tempFolder))
            Directory.CreateDirectory(tempFolder);

        long unixTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
        string receivedFileName = $"{unixTimestamp}_{senderIp}_receivedfile.txt";

        File.WriteAllText(Path.Combine(tempFolder, receivedFileName), fileContent);
        Console.WriteLine("File received and saved: " + receivedFileName);
    }

    private static void Main(string[] args)
    {
        var sfm = new SocketFileManager(3000);
        sfm.FileReceived += WriteFile;
        Console.ReadKey();
    }
}