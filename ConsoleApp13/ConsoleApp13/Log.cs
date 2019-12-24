using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
namespace ConsoleApp13
{
    /////////////////// ЗАДАНИЕ 1  -  КЛАСС ДЛЯ ЗАПИСИ В ФАЙЛ
    public static class VANLog
    {
        public static List<string> changesList = new List<string>();
        private static string address = @"D:\bstu\II\1 sem\Лабораторные ООП\2 часть\13\logfile.txt";
        public static void WriteInfo()
        {
            try
            {
                FileInfo file = new FileInfo(address);
                file.Refresh();
                if (file.Exists)
                    using (StreamWriter sw = new StreamWriter(address, false, Encoding.UTF8))
                    {
                        sw.WriteLine($"Имя файла: {file.Name}");
                        sw.WriteLine($"Путь к файлу: {file.FullName}");
                        sw.WriteLine($"Размер файла: {file.Length}");
                        sw.WriteLine($"Время создания: {file.CreationTime}");
                        sw.WriteLine($"Последнeе изменение {file.LastWriteTime}");

                        FileChanges("Пользователь записал данные в файл");
                    }
                else throw new Exception("File is not Exists");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception! {ex.Message}");
            }
        }

        public static void ReadInfo()
        {
            try
            {
                using (StreamReader sr = new StreamReader(address, System.Text.Encoding.Default))
                {
                    Console.WriteLine("ЧТЕНИЕ ИЗ ФАЙЛА: \n");
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                    FileChanges("Пользователь прочел данные из файла");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception! {ex.Message}");
            }
        }

        public static void FileChanges(string message)
        {
            try
            {
                FileInfo file = new FileInfo(address);
                file.Refresh();
                if (file.Exists)
                    using (StreamWriter sw = new StreamWriter(address, true, Encoding.UTF8))
                    {
                        string result = "";
                        sw.WriteLine("===================================");
                        sw.WriteLine("Пользователь произвел новое действие!");
                        sw.WriteLine($"Действие: {message} ");
                        result += message; result += "\n";
                        sw.WriteLine($"Время: {DateTime.Now.ToString()} ");
                        result += DateTime.Now.ToString();
                        changesList.Add(result);
                    }
                else throw new Exception("File is not Exists");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception! {ex.Message}");
            }
        }
    }
}
