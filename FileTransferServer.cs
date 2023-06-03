using sn0x.lib.SocketDataTransferHandler;
namespace FileTransferServer;

public class FileTransferServer
{
    public void Start()
    {
        var sfm = new SocketDataTransferHandler(3000);
        sfm.FileReceived += WriteFile;
    }

    private void WriteFile(string fileContent, string senderIp)
    {
        string tempFolder = "temp2";

        if (!Directory.Exists(tempFolder))
            Directory.CreateDirectory(tempFolder);

        long unixTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
        string receivedFileName = $"{unixTimestamp}_{senderIp}_receivedfile.txt";

        File.WriteAllText(Path.Combine(tempFolder, receivedFileName), fileContent);
        Console.WriteLine("File received and saved: " + receivedFileName);
    }
}
