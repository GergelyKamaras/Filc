namespace Filc.Filc.Filc.Services.Interfaces
{
    public interface ITeacherService
    {
        public Mark AddMark(int studentId);
        public void RegisterAbsence();
    }
}
