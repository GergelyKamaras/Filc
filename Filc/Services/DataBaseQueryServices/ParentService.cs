using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Filc.Services.DataBaseQueryServices
{
    public class ParentService : IParentService
    {
        private ESContext _db;
        private IUserService _userService;
        public ParentService(ESContext esContext, IUserService userService)
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

        public void AddParent(Parent parent, string email)
        {
            IdentityUser user = _userService.GetUserByEmail(email);
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
