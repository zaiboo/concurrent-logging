Log Management Application
(Developer Technical Notes)

Application Overview
This console application, built in .NET 6 and C#, demonstrates a log management system that allows multiple threads to write log entries concurrently to a shared log file. The application ensures synchronized access to the log file in a thread-safe manner, handles exceptions, and provides a clean, well-constructed code structure. It also incorporates Docker containerization for easy deployment.
The log file is created at the specified location (/log/out.txt) and maintains a counter value that increments with each write operation.
Concurrent Loggin

Functionality
The application performs the following tasks:
•	If the log file does not exist at the specified location, the application will create it.
•	The application starts writing data to the log file with a counter value of 0, and the counter increments with each write.
•	The log file will have a timestamp associated with each entry, showing when the data was written.
•	Read Last Counter Value: It reads the last counter value from the log file (if it exists). The counter represents a unique identifier for log entries.
•	Concurrency and Threaded Log Entry Writing: The application launches multiple threads to write log entries to a shared log file. Each thread increments the counter and appends a new log entry containing the incremented counter, the thread's ID, and a timestamp to the log file. The lock statement is employed to ensure that only one thread at a time accesses the shared counter and writes to the log file, preventing race conditions.
•	Error Handling: The application includes error handling to catch and display any exceptions that may occur during file writing or reading.
•	Logging Configuration: The application supports configuration settings for the number of threads, writes per thread, and the log file path. These settings can be easily adjusted for different scenarios.
•	Press ENTER to Exit: At the end of the application execution, it waits for user input before exiting. This provides an opportunity to review any error messages in the console.
•	Docker Containerization: The application can be containerized using Docker for easy deployment. A Dockerfile is provided to package the application into a container.
•	Maintainability and Extensibility: The application is designed with maintainability and extensibility in mind. The separation of concerns and adherence to SOLID principles make it easy to modify or extend the functionality in the future.



Key Components
Main Program (Program.cs):
•	The main entry point of the application.
•	Initializes the ConfigurationService and LogService.
•	Creates a set of parallel tasks to write log entries.
Configuration Service (ConfigurationService.cs):
•	Manages application configuration settings.
•	Reads and stores the last counter value from the log file.
•	Implements the IConfigurationService interface.
Log Service (LogService.cs):
•	Manages the writing of log entries to the log file.
•	Ensures thread safety using a lock.
•	Implements the ILogService interface.

Special Considerations
•	The application uses file I/O operations to read the last counter value and write log entries. It assumes that the log file path is accessible, and no security checks are in place. In a complex environment, access control and file path validation may be implemented for security. Ensure that the log file path is accessible and writable.
•	Configuration Flexibility: The application allows easy configuration adjustments by changing the values in the ConfigurationService class. This flexibility makes it suitable for different scenarios. Potential Improvement is implementing a more robust configuration management system, such as using configuration files or environment variables.
•	Logging Flexibility: The LogService class encapsulates the log writing logic, making it easy to extend and customize the logging behavior.
•	Before deploying this application to a production environment, comprehensive testing should be performed to ensure it meets performance, concurrency, and error-handling requirements.
•	When deploying the application in a Docker container, ensure that the paths specified in the Dockerfile align with your system's file structure.

NOTES:
•	DockerHub repo: https://hub.docker.com/r/ezohaib/quiz
•	Docker Pull: docker pull ezohaib/quiz
•	Run: docker run -i -v C:\junk:/log quiz
(after execution, you should see a file out.txt in my folder c:\junk)
