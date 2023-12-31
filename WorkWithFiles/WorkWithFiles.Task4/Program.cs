﻿using System.Runtime.Serialization.Formatters.Binary;

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

            List<Student> students = new List<Student>();
            Student parseStudent;
            
            BinaryFormatter bf = new BinaryFormatter();

            string StudentFile = "D:\\SkillBox\\Students.dat";
            if (!File.Exists(StudentFile))
                Console.WriteLine("Файл Students.dat не найден");
            else
                using(FileStream fs = new FileStream(StudentFile, FileMode.OpenOrCreate))
                {
                    try
                    {
                        parseStudent = (Student)bf.Deserialize(fs);
                    }
                    catch(Exception e) 
                    { 
                        Console.WriteLine(e.ToString());
                    }

                }
        }
    }
}