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
    //////////////////////////////// ЗАДАНИЕ 2  -  КЛАСС ОБ ИНФОРМАЦИИ О ДИСКАХ

    public static class VANDiskInfo
    {
        public static void PrintInfo()
        {
            Console.WriteLine("\n==================================\n");
            Console.WriteLine("ИНФОРМАЦИЯ О ДИСКАХ\n");
            try
            {
                DriveInfo[] disks = DriveInfo.GetDrives();
                foreach (var disk in disks)
                {
                    Console.WriteLine($"Название: {disk.Name}");
                    Console.WriteLine($"Тип: {disk.DriveType}");
                    if (disk.IsReady)
                    {
                        Console.WriteLine($"Объем диска: {disk.TotalSize}");
                        Console.WriteLine($"Свободное пространство: {disk.TotalFreeSpace}");
                    }
                    Console.WriteLine();
                }
                VANLog.FileChanges("Пользователь узнал информацию о дисках");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception! {ex.Message}");
            }
        }
    }

}
