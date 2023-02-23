namespace BackgroundThread;
class Program
{
    // Puprose of snippet: Understand Foreground and Background threads

    // In this snippet we are creating a new thread, apart from the
    // default main thread on which .net excutes the code.
    // The newly created thread can be set as background thread by setting the
    // Thread.IsBackground property as true.
    // If we dont set it as true, be default Foreground thread is created.
    // What is the difference?
    // We can terminate a process or app or exe even if background thread is executing
    // But its not the same for foreground thread, in order to exit the app we willl have to
    // stop the debugger or close the command window.
    // For a background thread, we the framework gives lower priority and hence we allows to termintate the
    // main process.

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

        bgThread.IsBackground = true;
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

