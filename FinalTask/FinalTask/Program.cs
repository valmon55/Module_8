using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
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

            Student[] students;
            Student parseStudent;

            BinaryFormatter bf = new BinaryFormatter();

            string StudentFile = "D:\\SkillBox\\Students.dat";
            if (!File.Exists(StudentFile))
                Console.WriteLine("Файл Students.dat не найден");
            else
                using (FileStream fs = new FileStream(StudentFile, FileMode.OpenOrCreate))
                {
                    try
                    {
                        students = (Student[])bf.Deserialize(fs);
                        foreach (Student student in students)
                        {
                            Console.WriteLine($"{student.Name} {student.DateOfBirth} {student.Group}");                            
                        }
                        Console.WriteLine("========================================================");
                        SortStudentsByGroops(ref students);
                        foreach (Student student in students)
                        {
                            Console.WriteLine($"{student.Name} {student.DateOfBirth} {student.Group}");
                        }

                        string group_name = students[0].Group;
                        string file_group = StudentsPath + @"\Group_" + group_name + ".txt";
                        StreamWriter sw = File.CreateText(file_group); 
                        for (int i = 0; i < students.Length; i++)
                        {
                            
                            if (group_name == students[i].Group)
                            {
                                sw.WriteLine($"\"{students[i].Name}, {students[i].DateOfBirth.ToString()}\"");                                
                            }
                            else
                            {
                                sw.Close();
                                group_name = students[i].Group;
                                file_group = StudentsPath + @"\Group_" + group_name + ".txt";
                                sw = File.CreateText(file_group);
                                sw.WriteLine($"\"{students[i].Name}, {students[i].DateOfBirth.ToString()}\"");
                            }                            
                        }
                        sw.Close();                        

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }

                }
        }
        public static void SortStudentsByGroops(ref Student[] _students)
        {
            Student student;
            student= _students[0];
            //for (int i = 1; i < _students.Length; i++)
                for (int k = 0; k < _students.Length; k++)
                    for (int i = k + 1; i < _students.Length; i++)
                        if (string.Compare(_students[i].Group, _students[k].Group) < 0)
                        {
                            student = _students[k];
                            _students[k] = _students[i];
                            _students[i] = student;
                        }
        }
    }
}