using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.SchoolAdmin;
using Filc.Models.EntityViewModels.Student;
using Filc.Models.EntityViewModels.Subject;
using Filc.Models.EntityViewModels.Teacher;
using Filc.Models.ViewModels.Lesson;
using Filc.Models.ViewModels.Mark;
using Filc.Models.ViewModels.Parent;

namespace Filc.Services.ModelConverter
{
    public static class ModelConverter
    {
        public static List<SchoolAdminDTO> MapSchoolAdminToSchoolAdminViewModel(List<SchoolAdmin> schoolAdmins)
        {
            List<SchoolAdminDTO> schoolAdminList = new List<SchoolAdminDTO>();
            schoolAdmins.ForEach(admin => schoolAdminList.Add(new SchoolAdminDTO(admin)));

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
            return lessonModels.ToList();
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

        public static List<SubjectDTO> MapSubjectsToSubjectViewModels(List<Subject> subjects)
        {
            List<SubjectDTO> subjectModels = new List<SubjectDTO>();
            subjects.ForEach(s => subjectModels.Add(new SubjectDTO(s)));
            return subjectModels;
;
        }


    }
}
