using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using schoolPortal.Models;

namespace schoolPortal.Interfaces
{
    public interface IcoursesRepository
    {
        void AddCourse(Courses courses);
        void RemoveCourse(int Id);
        void Edit(Courses courses);
        Courses[] GetCoursesByMatric(string matric);
        
    }
}
