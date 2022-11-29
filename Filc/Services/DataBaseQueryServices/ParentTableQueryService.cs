using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;
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
        public Parent GetParent(int id)
        {
            return _db.Parent.Include(parent => parent.user)
                .Include(parent => parent.Children)
                .First(parent => parent.Id == id);
        }

        public void AddParent(Parent parent)
        {
            IdentityUser user = _userService.GetUserByEmail(parent.user.Email);
            parent.user = user;
            _db.Parent.Add(parent);
            _db.SaveChanges();
        }

        public void UpdateParent(Parent parent)
        {
            _db.Parent.Update(parent);
            _db.SaveChanges();
        }

        public void DeleteParent(int id)
        {
            _db.Parent.Remove(_db.Parent.First(parent => parent.Id == id));
        }
    }
}
