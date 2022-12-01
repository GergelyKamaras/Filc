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
        public static List<SchoolAdminViewModel> MapSchoolAdminToSchoolAdminViewModel(List<SchoolAdmin> schoolAdmins)
        {
            List<SchoolAdminViewModel> schoolAdminList = new List<SchoolAdminViewModel>();
            schoolAdmins.ForEach(admin => schoolAdminList.Add(new SchoolAdminViewModel(admin)));

            return schoolAdminList;
        }

        public static List<SchoolViewModel> MapSchoolToSchoolViewModel(List<School> schools)
        {
            List<SchoolViewModel> schoolList = new List<SchoolViewModel>();
            schools.ForEach(school => schoolList.Add(new SchoolViewModel(school)));
            return schoolList;
        }

        public static List<MarkViewModel> MapMarksToMarkViewModels(List<Mark> marks)
        {
            List<MarkViewModel> markViewModels = new List<MarkViewModel>();
            marks.ForEach(mark => markViewModels.Add(new MarkViewModel(mark)));
            return markViewModels;
        }

        public static List<LessonViewModel> MapLessonsToLessonViewModels(List<Lesson> lessons)
        {
            List<LessonViewModel> lessonModels = new List<LessonViewModel>();
            lessons.ForEach(lesson => lessonModels.Add(new LessonViewModel(lesson)));
            return lessonModels;
        }

        public static List<ParentrentViewModel> MapParentsToParentViewModel(List<Parent> parents)
        {
            List<ParentrentViewModel> parentModels = new List<ParentrentViewModel>();
            parents.ForEach(parent => parentModels.Add(new ParentrentViewModel(parent)));
            return parentModels;
        }

        // Convert student, teacher
        public static List<StudentViewModel> MapStudentsToStudentViewModels(List<Student> students)
        {
            List<StudentViewModel> studentModels = new List<StudentViewModel>();
            students.ForEach(student => studentModels.Add(new StudentViewModel(student)));
            return studentModels;
        }

        public static List<TeacherViewModel> MapTeachersToTeacherViewModels(List<Teacher> teachers)
        {
            List<TeacherViewModel> teacherModels = new List<TeacherViewModel>();
            teachers.ForEach(teacher => teacherModels.Add(new TeacherViewModel(teacher)));
            return teacherModels;
        }



    }
}
