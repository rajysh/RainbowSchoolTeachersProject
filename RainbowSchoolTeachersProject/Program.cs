using System;

namespace RainbowSchoolTeachersProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 1;
            string answer = "n";
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine("Welcome to Teacher Database!!");
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine("1. Insert");
                    Console.WriteLine("2. Update");
                    Console.WriteLine("3. Retrieve by Teacher Id");
                    Console.WriteLine("4. Retrieve All Teachers");
                    Console.WriteLine("5. Exit");
                    Console.WriteLine("*******************************************************");
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.Write("Enter Option: ");

                    input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:

                            Console.WriteLine("Insert Operation");

                            do
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Teacher.Insert();
                                Console.Write("Do you want to Insert more records? (y/n): ");
                                answer = Console.ReadLine().ToLower();
                            } while (answer == "y");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("-------------------------------------------------------");
                            break;
                        case 2:
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Update Operation");
                                Teacher.Update();
                                Console.Write("Do you want to Update more records? (y/n): ");
                                answer = Console.ReadLine().ToLower();
                            } while (answer == "y");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("-------------------------------------------------------");
                            break;
                        case 3:
                            do
                            {
                                Console.Write("Enter Teacher ID:");
                                int Id = Convert.ToInt32(Console.ReadLine());
                                Teacher t =  Teacher.GetTeacherById(Id);
                                bool isExist = Teacher.DisplayTeacher(t);
                                Console.Write("Do you want view other teacher record? (y/n): ");
                                answer = Console.ReadLine().ToLower();
                            } while (answer == "y");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("-------------------------------------------------------");
                            break;
                        case 4:
                            Teacher.GetAllTeachers();
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Exit Operation");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Choose an valid option(1 to 5)");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Enter only number for Teacher ID.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            } while (input != 5);
        }        
    }
}
