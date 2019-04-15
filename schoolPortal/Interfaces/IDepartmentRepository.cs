using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using schoolPortal.Models;

namespace schoolPortal.Interfaces
{
    public interface IDepartmentRepository
    {
        void Add(Department department);
        void Edit(Department department);
        List<Department> GetAll();
        List<Courses> GetDepartmentCourses(int Id);
        List<Courses> GetCoursesbyLevel(int level, int courseId);
    }
}
