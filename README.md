<p class="has-line-data" data-line-start="0" data-line-end="2">Log Management Application<br>
(Developer Technical Notes)</p>
<p class="has-line-data" data-line-start="3" data-line-end="7">Application Overview<br>
This console application, built in .NET 6 and C#, demonstrates a log management system that allows multiple threads to write log entries concurrently to a shared log file. The application ensures synchronized access to the log file in a thread-safe manner, handles exceptions, and provides a clean, well-constructed code structure. It also incorporates Docker containerization for easy deployment.<br>
The log file is created at the specified location (/log/out.txt) and maintains a counter value that increments with each write operation.<br>
Concurrent Loggin</p>
<p class="has-line-data" data-line-start="8" data-line-end="20">Functionality<br>
The application performs the following tasks:<br>
•   If the log file does not exist at the specified location, the application will create it.<br>
•   The application starts writing data to the log file with a counter value of 0, and the counter increments with each write.<br>
•   The log file will have a timestamp associated with each entry, showing when the data was written.<br>
•   Read Last Counter Value: It reads the last counter value from the log file (if it exists). The counter represents a unique identifier for log entries.<br>
•   Concurrency and Threaded Log Entry Writing: The application launches multiple threads to write log entries to a shared log file. Each thread increments the counter and appends a new log entry containing the incremented counter, the thread’s ID, and a timestamp to the log file. The lock statement is employed to ensure that only one thread at a time accesses the shared counter and writes to the log file, preventing race conditions.<br>
•   Error Handling: The application includes error handling to catch and display any exceptions that may occur during file writing or reading.<br>
•   Logging Configuration: The application supports configuration settings for the number of threads, writes per thread, and the log file path. These settings can be easily adjusted for different scenarios.<br>
•   Press ENTER to Exit: At the end of the application execution, it waits for user input before exiting. This provides an opportunity to review any error messages in the console.<br>
•   Docker Containerization: The application can be containerized using Docker for easy deployment. A Dockerfile is provided to package the application into a container.<br>
•   Maintainability and Extensibility: The application is designed with maintainability and extensibility in mind. The separation of concerns and adherence to SOLID principles make it easy to modify or extend the functionality in the future.</p>
<p class="has-line-data" data-line-start="23" data-line-end="36">Key Components<br>
Main Program (Program.cs):<br>
•   The main entry point of the application.<br>
•   Initializes the ConfigurationService and LogService.<br>
•   Creates a set of parallel tasks to write log entries.<br>
Configuration Service (ConfigurationService.cs):<br>
•   Manages application configuration settings.<br>
•   Reads and stores the last counter value from the log file.<br>
•   Implements the IConfigurationService interface.<br>
Log Service (LogService.cs):<br>
•   Manages the writing of log entries to the log file.<br>
•   Ensures thread safety using a lock.<br>
•   Implements the ILogService interface.</p>
<p class="has-line-data" data-line-start="37" data-line-end="43">Special Considerations<br>
•   The application uses file I/O operations to read the last counter value and write log entries. It assumes that the log file path is accessible, and no security checks are in place. In a complex environment, access control and file path validation may be implemented for security. Ensure that the log file path is accessible and writable.<br>
•   Configuration Flexibility: The application allows easy configuration adjustments by changing the values in the ConfigurationService class. This flexibility makes it suitable for different scenarios. Potential Improvement is implementing a more robust configuration management system, such as using configuration files or environment variables.<br>
•   Logging Flexibility: The LogService class encapsulates the log writing logic, making it easy to extend and customize the logging behavior.<br>
•   Before deploying this application to a production environment, comprehensive testing should be performed to ensure it meets performance, concurrency, and error-handling requirements.<br>
•   When deploying the application in a Docker container, ensure that the paths specified in the Dockerfile align with your system’s file structure.</p>
<p class="has-line-data" data-line-start="44" data-line-end="49">NOTES:<br>
•   DockerHub repo: <a href="https://hub.docker.com/r/ezohaib/quiz">https://hub.docker.com/r/ezohaib/quiz</a><br>
•   Docker Pull: docker pull ezohaib/quiz<br>
•   Run: docker run -i -v C:\junk:/log quiz<br>
(after execution, you should see a file out.txt in my folder c:\junk)</p>
