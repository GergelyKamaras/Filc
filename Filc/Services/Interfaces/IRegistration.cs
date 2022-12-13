using Filc.ViewModel;

namespace Filc.Services.Interfaces
{
    public interface IRegistration
    {
        public Task<bool> Register(RegistrationModel model);
    }
}
