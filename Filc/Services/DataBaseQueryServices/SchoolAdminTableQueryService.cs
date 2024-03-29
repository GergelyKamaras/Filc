﻿using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.SchoolAdmin;
using Filc.Models.JWTAuthenticationModel;
using Filc.Services.Interfaces;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Filc.Services.ModelConverter;
using Microsoft.IdentityModel.JsonWebTokens;
using Filc.ViewModel;
using Filc.Models.EntityViewModels.School;

namespace Filc.Services.DataBaseQueryServices
{
    public class SchoolAdminTableQueryService : ISchoolAdminServiceFullAccess
    {
        private readonly ESContext _db;
        private readonly IUserServiceFullAccess _userService;
        public SchoolAdminTableQueryService(ESContext esContext, IUserServiceFullAccess userService)
        {
            _userService = userService;
            _db = esContext;
        }
        
        public List<SchoolAdminDTO> GetAllSchoolAdmins()
        {
            List<SchoolAdmin> schoolAdmins = _db.SchoolAdmin
                .Include(admin => admin.School)
                .Include(admin => admin.user)
                .ToList();
            return ModelConverter.ModelConverter.MapSchoolAdminToSchoolAdminViewModel(schoolAdmins);
        }

        public List<SchoolAdminDTO> GetAllSchoolAdminsBySchool(int schoolId)
        {
            List<SchoolAdmin> schoolAdmins =  _db.SchoolAdmin.Where(admin => admin.School.Id == schoolId)
                .Include(admin => admin.user)
                .Include(admin => admin.School)
                .ToList();

            return ModelConverter.ModelConverter.MapSchoolAdminToSchoolAdminViewModel(schoolAdmins);
        }

        public SchoolAdminDTO GetSchoolAdminById(int id)
        {
            SchoolAdmin schoolAdmin = _db.SchoolAdmin.Include(admin => admin.user)
                .Include(admin => admin.School)
                .First(x => x.Id == id);

            return new SchoolAdminDTO(schoolAdmin);
        }

        public JWTAuthenticationResponse AddSchoolAdmin(SchoolAdmin schoolAdmin)
        {
            ApplicationUser user = _userService.GetUserByEmail(schoolAdmin.user.Email);
            schoolAdmin.School = _db.School.First(school => school.Id == schoolAdmin.School.Id);
            if(user.Email != null)
            {
                schoolAdmin.user = user;
                _db.SchoolAdmin.Add(schoolAdmin);
                _db.SaveChanges();
            }

            return new JWTAuthenticationResponse()
            {
                Status = "Success",
                Message = "Registration Successful!",
                Id = schoolAdmin.Id
            };
        }  

        public void UpdateSchoolAdmin(SchoolAdmin schoolAdmin)
        {
            schoolAdmin.user = _userService.GetUserByEmail(schoolAdmin.user.Email);
            schoolAdmin.School = _db.SchoolAdmin.First(a => a.Id == schoolAdmin.Id).School;
            _db.SchoolAdmin.Update(schoolAdmin);
            _db.SaveChanges();
        }

        public void DeleteSchoolAdmin(int schoolAdminId)
        {
            SchoolAdmin admin = _db.SchoolAdmin.Include(a => a.user)
                .First(a => a.Id == schoolAdminId);
            _userService.DeleteUser(admin.user.Id);
            _db.SchoolAdmin.Remove(admin);
            _db.SaveChanges();
        }

    }
}
