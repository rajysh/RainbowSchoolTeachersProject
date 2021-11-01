using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RainbowSchoolTeachersProject
{
    [Serializable]
    internal class Teacher
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Class { get; set; }

        public string Section { get; set; }

        private static string fileName = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\Teachers_Data.txt";
        
        public Teacher()
        {

        }

        #region Methods

        public static void Serialize(List<Teacher> teacher)
        {
            string jsonString = JsonSerializer.Serialize(teacher);
            //File.Open(fileName, FileMode.Append);
            File.WriteAllText(fileName,jsonString);
        }


        public static List<Teacher> Deserialize()
        {
            List<Teacher> Teacher = new List<Teacher>();
            try
            {
                string jsonString = File.ReadAllText(fileName);
                Teacher = JsonSerializer.Deserialize<List<Teacher>>(jsonString);
                
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Teacher Records text file does not exist.");

            }            
            return Teacher;
        }

        static List<Teacher> TeacherList = new();

        public static void Insert()
        {
            TeacherList = Deserialize();
            Teacher teacher = new();
            Console.WriteLine("Enter the Teacher Details: ");
            Console.Write("ID : ");
            teacher.ID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name : ");
            teacher.Name = Console.ReadLine();
            Console.Write("Class : ");
            teacher.Class = Console.ReadLine();
            Console.Write("Section : ");
            teacher.Section = Console.ReadLine();

            TeacherList.Add(teacher);
            Teacher.Serialize(TeacherList);
            Console.WriteLine("Insert operation successful.");

        }

        public static void Update()
        {
            try
            {
                Console.WriteLine("Enter the Teacher ID which you want to update:");
                Console.Write("Teacher ID: ");
                int ID = Convert.ToInt32(Console.ReadLine());
                Teacher t = GetTeacherById(ID);
                bool isExist = DisplayTeacher(t);
                if (isExist)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Enter the Teacher details to update:");

                    Console.Write("Teacher Name : ");
                    string Name = Console.ReadLine();
                    Console.Write("Class : ");
                    string Class = Console.ReadLine();
                    Console.Write("Section : ");
                    string Section = Console.ReadLine();

                    foreach (Teacher teacher in TeacherList)
                    {
                        if (teacher.ID == ID)
                        {
                            teacher.Name = Name;
                            teacher.Class = Class;
                            teacher.Section = Section;
                            break;
                        }
                    }
                    Teacher.Serialize(TeacherList);
                    Console.WriteLine("Update operation successful.");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                //else
                //{
                //    Console.WriteLine("Teacher ID entered not found in the records.");

                //}
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ID entered not in Number format, " + ex.Message );
            }
        }

        public static void GetAllTeachers()
        {
            List<Teacher> Teacher = Deserialize();

            if (Teacher.Count> 0)
            {

                Console.WriteLine("The following are the list of all teachers.");

                foreach (Teacher teacher in Teacher)
                {
                    Console.WriteLine("Teacher ID : " + teacher.ID.ToString());
                    Console.WriteLine("Teacher Name : " + teacher.Name);
                    Console.WriteLine("Teacher Class : " + teacher.Class);
                    Console.WriteLine("Teacher Section : " + teacher.Section);
                    Console.WriteLine("-------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No teachers found.");
            }

        }

        public static Teacher GetTeacherById(int TeacherID)
        {
            List<Teacher> Teacher = Deserialize();
            Teacher teacher = Teacher.FirstOrDefault(x => x.ID == TeacherID);
            return teacher;
            
        }

        public static bool DisplayTeacher(Teacher teacher)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            if (teacher != null)
            {
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("Teacher Details for Teacher ID: " + teacher.ID.ToString());
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("Teacher ID: " + teacher.ID.ToString());

                Console.WriteLine("Teacher Name : " + teacher.Name);
                Console.WriteLine("Teacher Class : " + teacher.Class);
                Console.WriteLine("Teacher Section : " + teacher.Section);
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else
            {
                Console.WriteLine("Teacher ID entered is not found in the records.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }
        #endregion Methods
    }
}
