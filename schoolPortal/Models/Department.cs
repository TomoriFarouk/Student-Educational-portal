using System.Collections.Generic;

namespace schoolPortal.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Student> Student { get; set; } = new HashSet<Student>();
        public ICollection<Courses> Courses { get; set; } = new HashSet<Courses>();
    }
}