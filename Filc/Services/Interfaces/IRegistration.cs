using Filc.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Services.Interfaces
{
    public interface IRegistration
    {
        public Task<bool> Register(RegistrationModel model);
    }
}
