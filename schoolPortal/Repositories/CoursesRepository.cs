using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using schoolPortal.Connect;
using schoolPortal.Interfaces;
using schoolPortal.Models;

namespace schoolPortal.Repositories
{
    public class CoursesRepository : IcoursesRepository
    {
        private readonly SchoolDbContext _schoolDb;
        public CoursesRepository(SchoolDbContext schoolDb)
        {
            _schoolDb = schoolDb;
        }
        public void AddCourse(Courses courses)
        {
            _schoolDb.Set<Courses>().Add(courses);
            _schoolDb.SaveChanges();
        }

        public void Edit(Courses courses)
        {
            var query = _schoolDb.Set<Courses>().Find(courses.Id);
            query.CourseName = courses.CourseName;
            //query.StudentCourses = courses.StudentCourses;
            _schoolDb.SaveChanges();
        }

        public Courses[] GetCoursesByMatric(string matric)
        {
            var query = _schoolDb.Set<Student>().Find(matric).Department.Courses.ToArray();
            return query;
        }

        public void RemoveCourse(int Id)
        {
            var query = _schoolDb.Set<Courses>().Find(Id);
            if(query != null)
            {
                _schoolDb.Set<Courses>().Remove(query);
            }
            
        }
    }
}
