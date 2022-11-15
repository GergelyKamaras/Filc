using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces
{
    public interface ITeacherService
    {
        public void AddMark(Mark mark);
        public void RegisterAbsence();
    }
}
