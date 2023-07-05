namespace WorkWithFiles.Task2
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
                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($"Размер : {directory} = {size} ");
                    FolderSize(directory);
                }
            }
            catch(Exception ex) 
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
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
            //Console.WriteLine("Укажите директорию: ");
            //string? DirPath = Console.ReadLine();
            string DirPath = @"D:\Oracle";
            if (Directory.Exists(DirPath))
            {
                //Console.ForegroundColor = ConsoleColor.Cyan;
                //Console.WriteLine($"Директория {DirPath}");
                DirectoryInfo dir = new DirectoryInfo(DirPath);
                //dir.FolderSize();
                //Console.ForegroundColor = ConsoleColor.Cyan;
                //Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine($"Размер директории {DirPath} = {dir.FolderSize()} байт");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Директории {DirPath} не найдено!");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();

        }
    }
}