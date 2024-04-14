using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ_Labb1.Models;
using Microsoft.EntityFrameworkCore;

namespace LINQ_Labb1.Data
{
    internal class SchoolContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherSubject> teacherSubjects { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-HTI6DCF;Initial Catalog = AdvancedLINQSchool;Integrated security = True; TrustServerCertificate = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Konfigurerar sammansatt nyckel för StudentSubject
            modelBuilder.Entity<StudentSubject>()
                .HasKey(ss => new { ss.StudentId, ss.SubjectId });

            //Konfigurerar sammansatt nyckel för TeacherSubject
            modelBuilder.Entity<TeacherSubject>()
                .HasKey(ts => new { ts.TeacherId, ts.SubjectId });

            //Seedar kurser
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, CourseName = "SUT23" },
                new Course { CourseId = 2, CourseName = "SUT22" },
                new Course { CourseId = 3, CourseName = "SUT21" }
                );

            //Seedar ämnen
            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, SubjectName = "Programmering 1" },
                new Subject { SubjectId = 2, SubjectName = "Programmering 2" },
                new Subject { SubjectId = 3, SubjectName = "OOP" },
                new Subject { SubjectId = 4, SubjectName = "SQL" },
                new Subject { SubjectId = 5, SubjectName = "C#" },
                new Subject { SubjectId = 6, SubjectName = "Matematik" }
                );

            //Seedar lärare
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherId = 1, TeacherName = "Anas"},
                new Teacher { TeacherId = 2, TeacherName = "Reidar" },
                new Teacher { TeacherId = 3, TeacherName = "Tobias"}
                );

            //Seedar studenter
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, CourseId = 1, StudentName = "Adam", TeacherId = 1 },
                new Student { StudentId = 2, CourseId = 1, StudentName = "Bianca", TeacherId = 2 },
                new Student { StudentId = 3, CourseId = 1, StudentName = "Charles", TeacherId = 3 },
                new Student { StudentId = 4, CourseId = 3, StudentName = "David", TeacherId = 1 },
                new Student { StudentId = 5, CourseId = 3, StudentName = "Eddie", TeacherId = 2 },
                new Student { StudentId = 6, CourseId = 3, StudentName = "Felicia", TeacherId = 3 },
                new Student { StudentId = 7, CourseId = 2, StudentName = "Gabriel", TeacherId = 1 },
                new Student { StudentId = 8, CourseId = 2, StudentName = "Hanna", TeacherId = 2 }
                );

            //Seedar studenter med ämnen
            modelBuilder.Entity<StudentSubject>().HasData(
                new StudentSubject { StudentId = 1, SubjectId = 1 },
                new StudentSubject { StudentId = 1, SubjectId = 2 },
                new StudentSubject { StudentId = 2, SubjectId = 1 },
                new StudentSubject { StudentId = 2, SubjectId = 3 },
                new StudentSubject { StudentId = 3, SubjectId = 2 },
                new StudentSubject { StudentId = 4, SubjectId = 4 },
                new StudentSubject { StudentId = 5, SubjectId = 5 },
                new StudentSubject { StudentId = 6, SubjectId = 6 }
                );

            // Seedar lärare med ämnen
            modelBuilder.Entity<TeacherSubject>().HasData(
                new TeacherSubject { TeacherId = 1, SubjectId = 1 },
                new TeacherSubject { TeacherId = 1, SubjectId = 2 },
                new TeacherSubject { TeacherId = 1, SubjectId = 6 },
                new TeacherSubject { TeacherId = 2, SubjectId = 3 },
                new TeacherSubject { TeacherId = 2, SubjectId = 4 },
                new TeacherSubject { TeacherId = 3, SubjectId = 5 },
                new TeacherSubject { TeacherId = 3, SubjectId = 6 }
                );
        }
    }
}
