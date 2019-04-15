using System.Collections.Generic;

namespace schoolPortal.Models
{
    public class Courses
    {
        //public Courses()
        //{
        //    this.Students = new HashSet<Student>();
        //}

        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int Level { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string CourseUnit { get; set; }
        public virtual Department Department { get; set; }
        //public virtual ICollection<Student> Students { get; set; }

        public List<StudentCourses> Students { get; set; }
    }
}