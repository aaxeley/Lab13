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

    ///////////////////// ЗАДАНИЕ 5  -  КЛАСС FileManager
    public static class VANFileManager
    {
        public static void a()
        {
            try
            {
                string catalogAddress = @"D:\bstu\II\1 sem\Лабораторные ООП\2 часть\13\VANInspect";
                DirectoryInfo catalog = new DirectoryInfo(catalogAddress);
                if (!catalog.Exists)
                {
                    catalog.Create();
                }
                string fileAddress = @"D:\bstu\II\1 sem\Лабораторные ООП\2 часть\13\VANInspect\info.txt";
                FileInfo file = new FileInfo(fileAddress);
                if (!file.Exists)
                {
                    file.Create();
                }
                file.Refresh();
                if (file.Exists)
                    using (StreamWriter sw = new StreamWriter(fileAddress, false, Encoding.UTF8))
                    {
                        string address = @"D:\";
                        DirectoryInfo directory = new DirectoryInfo(address);
                        sw.WriteLine($"папки диска D: ");
                        DirectoryInfo[] subdirectories = directory.GetDirectories();
                        foreach (var item in subdirectories)
                            sw.WriteLine(item.Name);
                        sw.WriteLine($"\nфайлы диска D: ");
                        FileInfo[] files = directory.GetFiles();
                        foreach (var item in files)
                            sw.WriteLine(item.Name);
                    }
                else throw new Exception("File is not Exists");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception! {ex.Message}");
            }
        }

        public static void b()
        {
            try
            {
                string catalogAddress = @"D:\bstu\II\1 sem\Лабораторные ООП\2 часть\13\VANFiles";
                DirectoryInfo catalog = new DirectoryInfo(catalogAddress);
                if (!catalog.Exists)
                {
                    catalog.Create();
                }
                string fileAddress = @"D:\bstu\II\1 sem\Лабораторные ООП\2 часть\13\VANFiles\info.txt";
                FileInfo file = new FileInfo(fileAddress);
                if (!file.Exists)
                {
                    file.Create();
                }
                file.Refresh();
                if (catalog.Exists)
                    using (StreamWriter sw = new StreamWriter(fileAddress, false, Encoding.UTF8))
                    {
                        string address = @"D:\bstu\II\1 sem\Лабораторные ООП\2 часть\13\forCopy";
                        DirectoryInfo directory = new DirectoryInfo(address);
                        FileInfo[] files = directory.GetFiles();
                        foreach (var item in files)
                        {
                            int n = 0;
                            if (item.Extension == ".html")
                                item.CopyTo($@"D:\bstu\II\1 sem\Лабораторные ООП\2 часть\13\VANFiles\{item.Name}.html");
                            n++;
                        }
                    }
                else throw new Exception("File is not Exists");

                catalog.MoveTo($@"D:\bstu\II\1 sem\Лабораторные ООП\2 часть\13\VANInspect\{catalog.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception! {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void c()
        {
            string sourceFolder = @"D:\bstu\II\1 sem\Лабораторные ООП\2 часть\13\VANInspect";
            string zipFile = @"D:\bstu\II\1 sem\Лабораторные ООП\2 часть\13\Archive\inspect.zip";
            string targetFolder = @"D:\bstu\II\1 sem\Лабораторные ООП\2 часть\13\Archive";

            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
            Console.WriteLine($"Папка {sourceFolder} архивирована в файл {zipFile}");
            ZipFile.ExtractToDirectory(zipFile, targetFolder);

            Console.WriteLine($"Файл {zipFile} распакован в папку {targetFolder}");

            VANLog.FileChanges($"Пользователь Анастасия Витальевна проверила выполнение последнего задания");
        }
    }
}
