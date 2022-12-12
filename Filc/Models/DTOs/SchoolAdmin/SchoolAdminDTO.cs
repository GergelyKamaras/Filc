using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Shared;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Filc.Models.EntityViewModels.SchoolAdmin
{
    public class SchoolAdminDTO
    {
        public SchoolAdminDTO(EFDataAccessLibrary.Models.SchoolAdmin admin)
        {
            Id = admin.Id;
            user = admin.user;
            FirstName = admin.FirstName;
            LastName = admin.LastName;
            BirthDate = admin.BirthDate;
            Address = admin.Address;
            School = new SchoolSharedDTO(admin.School);
        }
        public int Id { get; set; }
        public ApplicationUser user { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public virtual SchoolSharedDTO School { get; set; }
    }
}
