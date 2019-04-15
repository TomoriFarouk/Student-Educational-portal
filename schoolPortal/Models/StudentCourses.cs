using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace schoolPortal.Models
{
    public class StudentCourses
    {
        
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CoursesId { get; set; }        
        public Courses Courses { get; set; }
        
    }


}
