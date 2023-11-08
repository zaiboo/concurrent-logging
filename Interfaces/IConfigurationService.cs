internal interface IConfigurationService
{
    int ThreadCount { get; }
    int WritesPerThread { get; }
    string LogFilePath { get; }
    int Counter { get; set; }
}