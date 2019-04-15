using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using schoolPortal.Connect;
using schoolPortal.Interfaces;
using schoolPortal.Models;

namespace schoolPortal.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly SchoolDbContext _schoolDb;


        public DepartmentRepository(SchoolDbContext schoolDb)
        {
            _schoolDb = schoolDb;
        }
        public void Add(Department department)
        {
            _schoolDb.Set<Department>().Add(department);
            _schoolDb.SaveChanges();
        }

        public void Edit(Department department)
        {
            var query = _schoolDb.Set<Department>().Find(department.Id);
            query.DepartmentName = department.DepartmentName;
            query.Courses = department.Courses;
            _schoolDb.SaveChanges();
        }

        public List<Department> GetAll()
        {
            var query = _schoolDb.Set<Department>().ToList();
            return query;
        }

        public List<Courses> GetCoursesbyLevel(int level, int courseId)
        {
            var query = _schoolDb.Set<Courses>()
               .Where(x => x.Level == level && x.DepartmentId == courseId);
            return query.ToList();
        }

        //public List<Courses> GetCoursesbyLevel(int level, string course)
        //{
        //    var query = _schoolDb.Set<Courses>()
        //        .Where(x => x.Level == level &&  x.Department.DepartmentName == course);
        //    return query.ToList();
        //}

        public List<Courses> GetDepartmentCourses(int Id)
        {
            var query = _schoolDb.Set<Courses>()
                        .Where(x => x.Id == Id);
            return query.ToList();
        }

        //List<Courses> IDepartmentRepository.GetCoursesbyLevel(int level)
        //{
        //    var query = _schoolDb.Set<Courses>()
        //                .Where(x => x.Level == level);
        //    return query.ToList();
        //}
    
    }
}
