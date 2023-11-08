namespace Quiz
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // Initialize configuration service and log service
                var configurationService = new ConfigurationService();
                var logService = new LogService(configurationService);

                // Create an array of tasks to run concurrently
                var tasks = new Task[configurationService.ThreadCount];
                for (int i = 0; i < configurationService.ThreadCount; i++)
                {
                    // To execute the WriteToLogFile method in parallel
                    tasks[i] = Task.Run(() => logService.WriteToLogFile());
                }

                // Wait for all tasks to complete
                await Task.WhenAll(tasks);

                Console.WriteLine("Data has been written successfully.");
            }
            catch (Exception ex)
            {
                // Handle and display any exceptions that may occur in the Main method
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("Press ENTER to exit.");
            Console.Read();
        }
    }
}
