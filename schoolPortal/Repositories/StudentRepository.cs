using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using schoolPortal.Connect;
using schoolPortal.Interfaces;
using schoolPortal.Models;

namespace schoolPortal.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _schoolDb;

        public StudentRepository(SchoolDbContext schoolDb)
        {
            _schoolDb = schoolDb;
        }
        public void Add(Student student)
        {
            _schoolDb.Set<Student>().Add(student);
            _schoolDb.SaveChanges();

        }

        public void AddStudentCourse(int studentId, int courseId)
        {
            var entity = new StudentCourses
            {
                StudentId = studentId,
                CoursesId = courseId
            };

            _schoolDb.Set<StudentCourses>().Add(entity);
        }

        public void AddStudentCourses(int studentId, int[] courseId)
        {

            var studentCourses = courseId.Select(x => new StudentCourses { StudentId = studentId, CoursesId = x });

            
                _schoolDb.Set<StudentCourses>().AddRange(studentCourses);
                
                _schoolDb.SaveChanges();
               

            
        }
        public void Edit(Student student)
        {
            var query = _schoolDb.Set<Student>().Find(student.Id);
            query.LastName = student.LastName;
            query.FirstName = student.FirstName;
            _schoolDb.SaveChanges();

        }

        public List<Courses> GetAllStudentCoursesById(int studentId)
        {
            var query = _schoolDb.Set<StudentCourses>()
                .Where(x => x.StudentId == studentId)
                .Include(x=> x.Courses)
                .Select(x => new Courses
                {
                    Id = x.Courses.Id,
                    Level = x.Courses.Level,
                    CourseCode = x.Courses.CourseCode,
                    CourseName = x.Courses.CourseName,
                    CourseUnit = x.Courses.CourseUnit,
                    DepartmentId = x.Courses.DepartmentId
                }).ToList();
            return query;
            
        }

        public Student[] GetStudentByCourseCode(string code)
        {
            var query = from student in _schoolDb.Set<Student>()
                        join studentcourse in _schoolDb.Set<StudentCourses>()
                        on student.Id equals studentcourse.StudentId
                        join course in _schoolDb.Set<Courses>()
                        on studentcourse.CoursesId equals course.Id
                        where course.CourseCode == code
                        select student;

            return query.ToArray();
            //            .Include(x => x.Courses)
            //            .Where(x => x.Courses.CourseCode == code)

        }

        public Student GetStudentByID(int Id)
        {
            var query = _schoolDb.Set<Student>().Find(Id);
            return query;
        }
        public Student GetStudentByMatric(string matric)
        {
            var query = _schoolDb.Set<Student>()
                        .Where(x => x.MatricNumber == matric)
                        .Include(x => x.Department)
                        .FirstOrDefault();
            return query;
        }

        public StudentCourses GetStudentCourseById(int studentId)
        {

            var query = _schoolDb.Set<StudentCourses>()
                .Where(x => x.StudentId == studentId)
                //.Select(x => x.CoursesId)
                .FirstOrDefault();
            return query;
        }

       
    }
}
