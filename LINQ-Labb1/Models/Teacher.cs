using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Labb1.Models
{
    internal class Teacher
    {
        public int TeacherId { get; set; }
        public string? TeacherName { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Subject>? Subjects { get; set; }
    }
}
