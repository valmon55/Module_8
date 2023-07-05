namespace WorkWithFiles.Task4
{
    [Serializable]
    public class Student
    { 
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string StudentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Students";
            if (!Directory.Exists(StudentsPath))
            {
                Directory.CreateDirectory(StudentsPath);
            }
            Console.WriteLine("Hello, World!");
        }
    }
}