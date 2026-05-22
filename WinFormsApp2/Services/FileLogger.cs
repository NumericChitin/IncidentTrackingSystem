using System;
using System.IO;

namespace WinFormsApp2
{
    public class FileLogger
    {
        private readonly string _filePath = "incidents_log.txt";

        public void LogEvent(object? sender, IncidentEventArgs e)
        {
            try
            {
                string logEntry = $"[{e.Timestamp:yyyy-MM-dd HH:mm:ss}] {e.Message}";
                File.AppendAllText(_filePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Заглушаваме грешката, за да не срине UI-а, ако файлът е заключен
                System.Diagnostics.Debug.WriteLine($"Грешка при запис в лог файла: {ex.Message}");
            }
        }
    }
}