using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;
using Filc.Models.EntityViewModels.SchoolAdmin;
using Filc.Models.ViewModels.Lesson;
using Filc.Models.ViewModels.Mark;
using Filc.Models.ViewModels.Parent;
using Filc.Models.ViewModels.Student;
using Filc.Models.ViewModels.Teacher;

namespace Filc.Services.ModelConverter
{
    public static class ModelConverter
    {
        public static List<Models.EntityViewModels.SchoolAdmin.SchoolAdminDTO> MapSchoolAdminToSchoolAdminViewModel(List<SchoolAdmin> schoolAdmins)
        {
            List<Models.EntityViewModels.SchoolAdmin.SchoolAdminDTO> schoolAdminList = new List<Models.EntityViewModels.SchoolAdmin.SchoolAdminDTO>();
            schoolAdmins.ForEach(admin => schoolAdminList.Add(new Models.EntityViewModels.SchoolAdmin.SchoolAdminDTO(admin)));

            return schoolAdminList;
        }

        public static List<Models.EntityViewModels.School.SchoolDTO> MapSchoolToSchoolViewModel(List<School> schools)
        {
            List<Models.EntityViewModels.School.SchoolDTO> schoolList = new List<Models.EntityViewModels.School.SchoolDTO>();
            schools.ForEach(school => schoolList.Add(new Models.EntityViewModels.School.SchoolDTO(school)));
            return schoolList;
        }

        public static List<MarkDTO> MapMarksToMarkViewModels(List<Mark> marks)
        {
            List<MarkDTO> markViewModels = new List<MarkDTO>();
            marks.ForEach(mark => markViewModels.Add(new MarkDTO(mark)));
            return markViewModels;
        }

        public static List<LessonDTO> MapLessonsToLessonViewModels(List<Lesson> lessons)
        {
            List<LessonDTO> lessonModels = new List<LessonDTO>();
            lessons.ForEach(lesson => lessonModels.Add(new LessonDTO(lesson)));
            return lessonModels;
        }

        public static List<ParentDTO> MapParentsToParentViewModel(List<Parent> parents)
        {
            List<ParentDTO> parentModels = new List<ParentDTO>();
            parents.ForEach(parent => parentModels.Add(new ParentDTO(parent)));
            return parentModels;
        }

        // Convert student, teacher
        public static List<StudentDTO> MapStudentsToStudentViewModels(List<Student> students)
        {
            List<StudentDTO> studentModels = new List<StudentDTO>();
            students.ForEach(student => studentModels.Add(new StudentDTO(student)));
            return studentModels;
        }

        public static List<TeacherDTO> MapTeachersToTeacherViewModels(List<Teacher> teachers)
        {
            List<TeacherDTO> teacherModels = new List<TeacherDTO>();
            teachers.ForEach(teacher => teacherModels.Add(new TeacherDTO(teacher)));
            return teacherModels;
        }



    }
}
