using System.Diagnostics;

namespace SimpleGameDemo.Helpers;
public static class LogHelper
{
    private const string logFilePath = @"SimpleGameDemo\bin\Debug\net9.0\game_log.txt";

    public static void OpenLogFile()
    {
        string solutionRoot = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..");
        string fullPath = Path.Combine(solutionRoot, logFilePath);

        try
        {
            Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while opening the log file: {ex.Message}");
        }
    }
}
