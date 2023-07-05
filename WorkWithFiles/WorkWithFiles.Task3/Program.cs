namespace WorkWithFiles.Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Укажите директорию: ");
            //string DirPath = Console.ReadLine();
            string DirPath = @"D:\Temp";
            if (Directory.Exists(DirPath))
            {
                DirectoryInfo dir = new DirectoryInfo(DirPath);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine($"Исходный размер папки: {dir.FolderSize()} байт");
                Console.WriteLine($"Освобождено: {dir.DeleteOldFiles()} байт");
                DeleteFolders(DirPath);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine($"Текущий размер папки: {dir.FolderSize()} байт");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Директории {DirPath} не найдено!");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
        /// <summary>
        /// Рекурсивное удаление каталогов
        /// </summary>
        /// <param name="folder"></param>
        public static void DeleteFolders(string folder)
        {
            if (!Directory.Exists(folder))
            {
                return;
            }
            try
            {
                foreach (string directory in Directory.GetDirectories(folder))
                {
                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.BackgroundColor = ConsoleColor.Black;
                    //Console.WriteLine($"Директория: {directory} дата использования: {Directory.GetLastAccessTime(directory)} ");
                    if ((DateTime.Now - Directory.GetLastAccessTime(directory)) >= TimeSpan.FromMinutes(30)
                        && Directory.GetDirectories(directory).Length == 0
                        && Directory.GetFiles(directory).Length == 0
                       )
                    {
                        Directory.Delete(directory);
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Директория {directory} удалена!");
                    }
                    DeleteFolders(directory);
                }
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(e.Message);
            }
        }

    }
}