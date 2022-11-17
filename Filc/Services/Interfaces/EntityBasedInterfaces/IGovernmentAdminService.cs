using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface IGovernmentAdminService
    {
        public GovernmentAdmin GetGovernmentAdmin(int id);
        public List<GovernmentAdmin> GetAllGovernmentAdmins();
        public void AddGovernmentAdmin(GovernmentAdmin governmentAdmin, string email);
        public void RemoveGovernmentAdmin(int id);
        public void UpdateGovernmentAdmin(GovernmentAdmin governmentAdmin);
    }
}
