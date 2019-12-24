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
    class Program
    {
        static void Main(string[] args)
        {
            VANLog.WriteInfo();
            VANLog.ReadInfo();

            VANDiskInfo.PrintInfo();

            VANDirInfo.GetDirInfo(@"D:\music");

            VANFileInfo.GetFileInfo(@"D:\music\Flume - High Beams.flac");

            VANFileManager.a();
            VANFileManager.b();
            VANFileManager.c();

            Console.WriteLine("\n\n\nДЕЙСТВИЯ:");
            Console.WriteLine($"Количесво действий пользователя: {VANLog.changesList.Count}");
            Console.WriteLine("Действия пользователя за сегодня: ");
            string date = DateTime.Now.ToString();
            foreach (var item in VANLog.changesList)
            {
                if (item.Contains(date))
                    Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}