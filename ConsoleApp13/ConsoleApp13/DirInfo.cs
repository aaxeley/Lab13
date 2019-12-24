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
    ///////////////// ЗАДАНИЕ 4  -  ИНФОРМАЦИЯ О ДИРЕКТОРИИ

    public static class VANDirInfo
    {
        public static void GetDirInfo(string address)
        {
            Console.WriteLine("\n==================================\n");
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(address);
                if (dirInfo.Exists)
                {
                    Console.WriteLine($"ИНФОРМАЦИЯ О ПАПКЕ {dirInfo.Name}\n");
                    Console.WriteLine($"Количество файлов: {dirInfo.GetFiles().Length}");
                    Console.WriteLine($"Время создания: {dirInfo.CreationTime}");
                    Console.WriteLine($"Количество поддиректориев: {dirInfo.GetDirectories().Length}");
                    Console.WriteLine("Список поддиректориев:");
                    DirectoryInfo[] list = dirInfo.GetDirectories();
                    foreach (var item in list)
                        Console.WriteLine(item.Name);

                    VANLog.FileChanges($"Пользователь узнал информацию о директории {dirInfo.Name}");
                }
                else throw new Exception("Catalog is not Exists");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception! " + ex.Message);
            }

        }
    }
}
