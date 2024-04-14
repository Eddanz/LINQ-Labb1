using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Labb1.Models
{
    internal class TeacherSubject
    {
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }
}
