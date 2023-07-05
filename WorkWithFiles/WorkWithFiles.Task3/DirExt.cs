using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithFiles.Task3
{
    public static class DirExt
    {
        public static long FolderSize(this DirectoryInfo folder)
        {
            long size = 0;
            try
            {
                FileInfo[] files = folder.GetFiles();

                foreach (FileInfo file in files)
                {
                    size += file.Length;
                }

                foreach (DirectoryInfo directory in folder.GetDirectories())
                {
                    Console.WriteLine($"Размер : {directory} = {size} байт");
                    size += FolderSize(directory);
                }
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            return size;
        }
    }
}

