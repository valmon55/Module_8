namespace WorkWithFiles.Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите директорию: ");
            string DirPath = Console.ReadLine();
            //string DirPath = @"D:\Temp";
            if (Directory.Exists(DirPath))
            {
                DirectoryInfo dir = new DirectoryInfo(DirPath);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine($"Исходный размер папки: {dir.FolderSize()} байт");
                SearchFolders(DirPath);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine("    Удаляем директории    ");
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
        /// Рекурсивный просмотр каталогов
        /// </summary>
        /// <param name="forder"></param>
        public static void SearchFolders(string folder)
        {
            if (!Directory.Exists(folder))
            {
                return;
            }
            try
            {
                foreach (string directory in Directory.GetDirectories(folder))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($"Директория: {directory} дата использования: {Directory.GetLastAccessTime(directory)} ");
                    SearchFiles(directory);
                    SearchFolders(directory);
                }
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Поиск файлов в каталоге
        /// </summary>
        /// <param name="folder"></param>
        public static void SearchFiles(string folder)
        {
            try
            {
                foreach (string file in Directory.GetFiles(folder))
                {
                    if (!File.Exists(file))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Файл {file} не найден!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine($"Файл: {file} дата использования: {File.GetLastAccessTime(file)} ");
                        DeleteFile(file);
                    }
                }
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Удаление файла
        /// </summary>
        /// <param name="file"></param>
        public static void DeleteFile(string file)
        {
            try
            {
                if ((DateTime.Now - File.GetLastAccessTime(file)) <= TimeSpan.FromMinutes(30))
                {
                    File.Delete(file);
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Удалён файл: {file}");
                }
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(e.Message);
            }
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
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($"Директория: {directory} дата использования: {Directory.GetLastAccessTime(directory)} ");
                    if ((DateTime.Now - Directory.GetLastAccessTime(directory)) <= TimeSpan.FromMinutes(30)
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