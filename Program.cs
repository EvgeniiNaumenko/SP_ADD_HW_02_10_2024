using System;
using Microsoft.Win32;

namespace UserLastAccessApp
{
    class Program
    {
        private const string RegistryKeyPath = @"HKEY_CURRENT_USER\Software\UserLastAccessApp";
        private const string LastAccessKey = "LastAccessTime";
        static void Main(string[] args)
        {

            string lastAccessTime = (string)Registry.GetValue(RegistryKeyPath, LastAccessKey, null);

            if (lastAccessTime == null)
            {
                Console.WriteLine("Нет данных о последнем входе.");
            }
            else
            {
                Console.WriteLine($"Последний вход в программу был: {lastAccessTime}");
            }
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Registry.SetValue(RegistryKeyPath, LastAccessKey, currentTime);

            Console.WriteLine($"Текущее время {currentTime} было записано в реестр как время последнего входа.");

            // Завершение программы
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
