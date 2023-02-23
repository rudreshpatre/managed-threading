namespace BackgroundThread;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        int count = 0;
        var bgThread = new Thread(() =>
        {
            while (true)
            {
                count++;
                bool isNetworkUp = System.Net.NetworkInformation.NetworkInterface
                .GetIsNetworkAvailable();
                Console.WriteLine($"Count: {count}; Is network available? Answer: {isNetworkUp}");
                Thread.Sleep(100);
            }
        });

        bgThread.IsBackground = false;
        bgThread.Start();

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Do work on main thread");
            Task.Delay(500);
        }
        Console.WriteLine("Done");
        Console.ReadKey();
    }
}

