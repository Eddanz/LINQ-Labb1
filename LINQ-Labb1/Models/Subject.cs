using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Labb1.Models
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public ICollection<Teacher>? Teachers { get; set; }
        public ICollection<Student>? Students { get; set; }
    }
}
