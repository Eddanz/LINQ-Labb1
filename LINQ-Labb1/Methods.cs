using LINQ_Labb1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LINQ_Labb1
{
    internal class Methods
    {
        // Hämtar alla mattelärare från databasen
        public static void GetMathTeachers()
        {
            SchoolContext context = new SchoolContext();

            Console.Clear();

            // Skriver ut antal lärare, ämnen och lärare-ämnen kopplingar
            Console.WriteLine($"\nAntal lärare: {context.Teachers.Count()}");
            Console.WriteLine($"Antal ämnen: {context.Subjects.Count()}");
            Console.WriteLine($"Antal TeacherSubjects: {context.teacherSubjects.Count()}");

            // Sök efter mattelärare
            var mathTeachers = context.teacherSubjects
                .Include(ts => ts.Teacher)
                .Include(ts => ts.Subject)
                .Where(ts => ts.Subject.SubjectName == "Matematik")
                .Select(ts => ts.Teacher.TeacherName)
                .Distinct()
                .ToList();

            // Skriv ut hittade mattelärare eller ett meddelande om inga hittades
            Console.WriteLine($"\nMattelärare som hittades: {mathTeachers.Count}\n");
            if (mathTeachers.Count == 0)
            {
                Console.WriteLine("\nInga mattelärare hittades");
            }
            else
            {
                foreach (var teacherName in mathTeachers)
                {
                    Console.WriteLine(teacherName);
                }
            }

            Console.ReadLine();
        }

        // Hämtar elever och deras tilldelade lärare
        public static void GetStudentsWithTeachers()
        {
            SchoolContext context = new SchoolContext();

            Console.Clear();

            // Sök efter elever och deras lärare
            var studentsWithTeachers = context.Students
                .Include(s => s.Teacher)
                .Select(s => new
                {
                    studentName = s.StudentName,
                    teacherName = s.Teacher.TeacherName
                })
                .ToList();

            // Skriv ut information om elever och deras lärare, eller ett meddelande om inga hittades
            if (studentsWithTeachers.Count == 0)
            {
                Console.WriteLine("\nInga elever hittades.");
            }
            else
            {
                foreach (var item in studentsWithTeachers)
                {
                    Console.WriteLine($"\nStudent: {item.studentName}, Lärare: {item.teacherName}");
                }
            }

            Console.ReadLine();
        }

        // Kontrollerar om ämnet "Programmering 1" finns i databasen
        public static void CheckSubject()
        {
            SchoolContext context = new SchoolContext();

            Console.Clear();

            // Kontroll av existens
            bool exists = context.Subjects.Any(s => s.SubjectName == "Programmering 1");

            // Skriv ut resultatet av kontrollen
            if (!exists)
            {
                Console.WriteLine("Programmering 1 existerar inte..");
            }
            else
            {
                Console.WriteLine("Programmering 1 existerar!");
            }

            Console.ReadLine();
        }

        // Uppdaterar namnet på ämnet "Programmering 2" till "OOP"
        public static void ChangeSubject()
        {
            SchoolContext context = new SchoolContext();

            Console.Clear();

            // Hitta ämnet för att uppdatera
            var subjectToUpdate = context.Subjects
                .FirstOrDefault(s => s.SubjectName == "Programmering 2");

            // Kontrollera om ämnet finns och uppdatera det
            if (subjectToUpdate != null)
            {
                subjectToUpdate.SubjectName = "OOP";
                context.SaveChanges();
                Console.WriteLine("Ämnet har uppdaterats!");
            }
            else
            {
                Console.WriteLine("Programmering 2 hittades inte och kan därför inte uppdateras..");
            }

            Console.ReadLine();
        }

        // Byter klassföreståndare för elever från Anas till Reidar
        public static void ChangeTeacher()
        {
            SchoolContext context = new SchoolContext();

            Console.Clear();

            // Hitta elever som ska byta klassföreståndare
            var changeTeacher = context.Students
                .Where(s => s.TeacherId == 1)
                .ToList();

            // Byt klassföreståndare och spara ändringar
            if (changeTeacher.Count > 0)
            {
                foreach (var student in changeTeacher)
                {
                    student.TeacherId = 2;
                }

                context.SaveChanges();
                Console.WriteLine("Klassföreståndare har ändrats för elever med Anas till Reidar");
            }
            else
            {
                Console.WriteLine("Inga elever med Anas som klassföreståndare hittades..");
            }

            Console.ReadLine();
        }
    }

}
