using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using EFDataAccessLibrary.Models;


namespace Filc.Models.EntityViewModels.School
{
    public class SchoolAdminViewModelForSchool
    {
        public int Id { get; set; }
        public ApplicationUser user { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

        public SchoolAdminViewModelForSchool(EFDataAccessLibrary.Models.SchoolAdmin schoolAdmin)
        {
            Id = schoolAdmin.Id;
            user = schoolAdmin.user;
            FirstName = schoolAdmin.FirstName;
            LastName = schoolAdmin.LastName;
            BirthDate = schoolAdmin.BirthDate;
            Address = schoolAdmin.Address;
        }
    }
}
