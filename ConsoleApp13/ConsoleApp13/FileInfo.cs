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
    //////////////////////// ЗАДАНИЕ 3  -  ВЫВОД ИНФОРМАЦИИ О КОНКРЕТНОМ ФАЙЛЕ

    public static class VANFileInfo
    {
        public static void GetFileInfo(string address)
        {
            Console.WriteLine("\n==================================\n");
            try
            {
                FileInfo fileInfo = new FileInfo(address);
                if (fileInfo.Exists)
                {
                    Console.WriteLine($"ИНФОРМАЦИЯ О ФАЙЛЕ {fileInfo.Name}\n");
                    Console.WriteLine($"Расположение файла: {fileInfo.FullName}");
                    Console.WriteLine($"Расширение файла: {fileInfo.Extension}");
                    Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
                    Console.WriteLine($"Размер файла: {fileInfo.Length}");

                    VANLog.FileChanges($"Пользователь узнал информацию о файле {fileInfo.Name}");
                }
                else throw new Exception("File is not Exists");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception! " + ex.Message);
            }
        }
    }

}
