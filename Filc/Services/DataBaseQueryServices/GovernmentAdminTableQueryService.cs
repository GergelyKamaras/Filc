﻿using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Models.JWTAuthenticationModel;
using Filc.Services.Interfaces;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Filc.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filc.Services.DataBaseQueryServices
{
    public class GovernmentAdminTableQueryService : IGovernmentAdminServiceFullAccess
    {
        private ESContext _db;
        private IUserServiceFullAccess _userService;
        public GovernmentAdminTableQueryService(ESContext esContext, IUserServiceFullAccess usrService)
        {
            _db = esContext;
            _userService = usrService;
        }

        public List<GovernmentAdmin> GetAllGovernmentAdmins()
        {
            return _db.GovernmentAdmin.Include(admin => admin.user)
                .ToList();
        }
        public GovernmentAdmin GetGovernmentAdmin(int id)
        {
            return _db.GovernmentAdmin.Include(admin => admin.user)
                .FirstOrDefault(x => x.Id == id);
        }
        public JWTAuthenticationResponse AddGovernmentAdmin(GovernmentAdmin governmentAdmin)
        {
            ApplicationUser user = _userService.GetUserByEmail(governmentAdmin.user.Email);
            governmentAdmin.user = user;
            _db.GovernmentAdmin.Add(governmentAdmin);
            _db.SaveChanges();

            return new JWTAuthenticationResponse()
            {
                Status = "Success",
                Message = "Registration successful!",
                Id = governmentAdmin.Id
            };
        }
        public void RemoveGovernmentAdmin(int id)
        {
            GovernmentAdmin admin = _db.GovernmentAdmin.Include(a => a.user)
                .FirstOrDefault(a => a.Id == id);
            if (admin != null)
            {
                _userService.DeleteUser(admin.user.Id);
                _db.GovernmentAdmin.Remove(admin);
                _db.SaveChanges();
            }
        }
        public void UpdateGovernmentAdmin(GovernmentAdmin governmentAdmin)
        {
            var dbAdmin = _db.GovernmentAdmin.FirstOrDefault(a => a.Id == governmentAdmin.Id);
            if (dbAdmin != null)
            {
                governmentAdmin.user = dbAdmin.user;
                _db.GovernmentAdmin.Update(governmentAdmin);
                _db.SaveChanges();
            }
        }
    }
}
