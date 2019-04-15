using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolPortal.Models
{
    public class Student        
    {
        //public Student()
        //{
        //    this.Courses = new HashSet<Courses>();
        //}

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MatricNumber { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        //public virtual ICollection<Courses> Courses { get; set; }

        public List<StudentCourses> Courses { get; set; }
    }
}
