﻿using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Models.JWTAuthenticationModel;
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

        public JWTAuthenticationResponse AddParent(Parent parent)
        {
            ApplicationUser user = _userService.GetUserByEmail(parent.user.Email);
            parent.user = user;
            parent.Children = new List<Student>();
            for (int i = 0; i < parent.Children.Count; i++)
            {
                parent.Children[i] = _db.Student.First(s => s.Id == parent.Children[i].Id);
            }
            _db.Parent.Add(parent);
            _db.SaveChanges();
            return new JWTAuthenticationResponse()
            {
                Status = "Success",
                Message = "Registration successful!",
                Id = parent.Id
            };
        }

        public void UpdateParent(Parent parent)
        {
            for (int i = 0; i < parent.Children.Count; i++)
            {
                parent.Children[i] = _db.Student.First(s => s.Id == parent.Children[i].Id);
            }
            _db.Parent.Update(parent);
            _db.SaveChanges();
        }

        public void DeleteParent(int id)
        {
            Parent parent = _db.Parent.Include(p => p.user)
                .First(p => p.Id == id);
            _userService.DeleteUser(parent.user.Id);
            _db.Parent.Remove(parent);
            _db.SaveChanges();
        }
    }
}
