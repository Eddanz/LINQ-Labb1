using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Labb1
{
    internal class Menu
    {
        public static void Run()
        {
            while (true)
            {
                Console.Clear();

                Console.Write("\n[1] Visa mattelärare" +
                "\n[2] Visa elever med deras respektive klassföreståndare" +
                "\n[3] Kolla om ämnet programmering 1 existerar eller inte" +
                "\n[4] Uppdatera ämnet programmering 2 till OOP" +
                "\n[5] Uppdatera elever med klassföreståndaren Anas till Reidar" +
                "\n[6] Avsluta" +
                "\n\nVÄLJ: ");
                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Methods.GetMathTeachers();
                        break;
                    case "2":
                        Methods.GetStudentsWithTeachers();
                        break;
                    case "3":
                        Methods.CheckSubject();
                        break;
                    case "4":
                        Methods.ChangeSubject();
                        break;
                    case "5":
                        Methods.ChangeTeacher();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nDu måste välja 1-6!");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }
    }
}
