internal class LogService: ILogService
{
    private readonly IConfigurationService configurationService;
    private object FileLock { get; } = new object();

    public LogService(IConfigurationService configurationService)
    {
        this.configurationService = configurationService;
    }

    public void WriteToLogFile()
    {
        for (int i = 0; i < configurationService.WritesPerThread; i++)
        {
            try
            {
                int currentThreadId = Environment.CurrentManagedThreadId;
                int incrementedCounter;

                // Synchronize access to the shared counter and file writing
                lock (FileLock)
                {
                    incrementedCounter = configurationService.Counter;
                    configurationService.Counter = incrementedCounter + 1;

                    // Create a new log entry with the incremented counter, thread ID, and timestamp
                    string newLine = $"{incrementedCounter}, {currentThreadId}, {DateTime.Now:HH:mm:ss.fff}";

                    // Append the new entry to the log file
                    using (var file = File.AppendText(configurationService.LogFilePath))
                    {
                        file.WriteLine(newLine);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle and display any exceptions that may occur during file writing
                Console.WriteLine($"An error occurred while writing to the log file: {ex.Message}");
            }
        }
    }
}