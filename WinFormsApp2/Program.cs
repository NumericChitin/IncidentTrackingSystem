using System;
using WinFormsApp2.Data.Models;
using WinFormsApp2.Logic;
using WinFormsApp2.Services;

namespace WinFormsApp2
{
    //internal static class Program
    //{
    //    /// <summary>
    //    ///  The main entry point for the application.
    //    /// </summary>
    //    [STAThread]
    //    static void Main()
    //    {
    //        // To customize application configuration such as set high DPI settings or default font,
    //        // see https://aka.ms/applicationconfiguration.
    //        ApplicationConfiguration.Initialize();
    //        Application.Run(new Form1());
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // За правилно извеждане на кирилица

            // 1. Инициализиране на източника на събития
            IncidentManager manager = new IncidentManager();

            // 2. Инициализиране на първия слушател (Logger)
            FileLogger logger = new FileLogger();

            // 3. АБОНИРАНЕ: Закачаме няколко реакции към едно събитие

            // Реакция 1: Логване във файл (чрез метода на класа)
            manager.IncidentCreated += logger.LogEvent;

            // Реакция 2: Моментално известие на конзолата (чрез ламбда израз/анонимен слушател)
            manager.IncidentCreated += (sender, e) =>
            {
                Console.WriteLine($"[Notification]: Спешно известие до системния администратор за: {e.Incident.Name}");
            };

            // Реакция 3: При критичен инцидент (специализиран слушател)
            manager.CriticalIncidentDetected += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[CRITICAL ALERT]: СИСТЕМАТА Е ПОД РИСК! Инцидент: {e.Incident.Description}");
                Console.ResetColor();
            };

            // --- ДЕМОНСТРАЦИЯ ---

            Console.WriteLine("--- Симулиране на нормален инцидент ---");
            Incident lowPriority = new Incident
            {
                ID = 101,
                Name = "Проблем с мишката",
                Description = "Мишката на бюро 5 не работи.",
                Type = 5
            };
            manager.CreateIncident(lowPriority);

            Console.WriteLine("\n--- Симулиране на КРИТИЧЕН инцидент ---");
            Incident critical = new Incident
            {
                ID = 999,
                Name = "Сървърен срив",
                Description = "CRITICAL: Базата данни не отговаря!",
                Type = 1
            };
            manager.CreateIncident(critical);

            Console.WriteLine("\nНатиснете клавиш за край...");
            Console.ReadKey();
        }
    }
}
