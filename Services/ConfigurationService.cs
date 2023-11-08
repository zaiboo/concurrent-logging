internal class ConfigurationService: IConfigurationService
{
    public int ThreadCount { get; } = 10;
    public int WritesPerThread { get; } = 10;
    public string LogFilePath { get; } = "/log/out.txt";
    public int Counter { get; set; } = 0;

    public ConfigurationService()
    {
        ReadLastCounterValue();
    }

    // Read the last counter value from the log file
    private void ReadLastCounterValue()
    {
        try
        {
            if (File.Exists(LogFilePath))
            {
                string[] lines = File.ReadAllLines(LogFilePath);
                if (lines.Length > 0)
                {
                    string lastLine = lines.Last();
                    string[] parts = lastLine.Split(',');
                    int lastCounter = int.Parse(parts[0]);
                    Counter = lastCounter;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle and display any exceptions that may occur during file reading
            Console.WriteLine($"An error occurred while reading the last counter value: {ex.Message}");
        }
    }
}