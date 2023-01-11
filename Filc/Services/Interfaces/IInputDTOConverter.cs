using EFDataAccessLibrary.Models;
using Filc.Models.InputDTOs;
using Filc.Models.ViewModels.Parent;
using Filc.Models.ViewModels.Shared;

namespace Filc.Services.ModelConverter;

public interface IInputDTOConverter
{
    public Mark ConvertDtoToMark(MarkInputDTO markInputDto);

    public Lesson ConvertDtoToLesson(LessonInputDTO lessonInputDto);
    public GovernmentAdmin ConvertDtoToGovernmentAdmin(GovernmentAdminInputDTO adminInputDto);
    public School ConvertDtoToSchool(SchoolInputDTO schoolInputDto);
    public Teacher ConvertDtoToTeacher(TeacherInputDTO teacherInputDto);
    public Student ConvertDtoToStudent(StudentInputDTO studentInputDto);
    public Parent ConvertDtoToParent(ParentInputDTO parentInputDto);
    public SchoolAdmin ConvertDtoToSchoolAdmin(SchoolAdminInputDTO schoolAdminInputDto);
}