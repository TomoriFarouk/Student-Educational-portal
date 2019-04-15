using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using schoolPortal.Models;

namespace schoolPortal.Interfaces
{
    public interface IStudentRepository
    {
        void Add(Student student);
        void Edit(Student student);
        Student GetStudentByID(int Id);
        Student GetStudentByMatric(string matric);
        Student[] GetStudentByCourseCode(string code);
        void AddStudentCourses(int studentId, int [] courseId);
        void AddStudentCourse(int studentId, int courseId);
        StudentCourses GetStudentCourseById(int studentId);
        List<Courses> GetAllStudentCoursesById(int studentId);

    }
}
