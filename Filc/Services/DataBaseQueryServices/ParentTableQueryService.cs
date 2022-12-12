using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Parent;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Filc.Services.DataBaseQueryServices
{
    public class ParentTableQueryService : IParentServiceFullAccess
    {
        private ESContext _db;
        private IUserServiceFullAccess _userService;
        public ParentTableQueryService(ESContext esContext, IUserServiceFullAccess userService)
        {
            _db = esContext;
            _userService = userService;
        }
        public ParentDTO GetParent(int id)
        {
            Parent parent = _db.Parent.Include(parent => parent.user)
                .Include(parent => parent.Children)
                .First(parent => parent.Id == id);
            return new ParentDTO(parent);
        }

        public void AddParent(Parent parent)
        {
            ApplicationUser user = _userService.GetUserByEmail(parent.user.Email);
            parent.user = user;
            for (int i = 0; i < parent.Children.Count; i++)
            {
                parent.Children[i] = _db.Student.First(s => s.Id == parent.Children[i].Id);
            }
            _db.Parent.Add(parent);
            _db.SaveChanges();
        }

        public void UpdateParent(Parent parent)
        {
            parent.user = _userService.GetUserByEmail(parent.user.Email);
            for (int i = 0; i < parent.Children.Count; i++)
            {
                parent.Children[i] = _db.Student.First(s => s.Id == parent.Children[i].Id);
            }
            _db.Parent.Update(parent);
            _db.SaveChanges();
        }

        public void DeleteParent(int id)
        {
            _db.Parent.Remove(_db.Parent.First(parent => parent.Id == id));
        }
    }
}
