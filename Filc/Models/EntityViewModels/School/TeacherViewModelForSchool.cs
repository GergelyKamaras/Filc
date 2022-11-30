using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Filc.Models.EntityViewModels.School
{
    public class TeacherViewModelForSchool
    {
        public int Id { get; set; }
        public IdentityUser user { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

        public TeacherViewModelForSchool(Teacher teacher)
        {
            Id = teacher.Id;
            user = teacher.user;
            FirstName = teacher.FirstName;
            LastName = teacher.LastName;
            BirthDate = teacher.BirthDate;
            Address = teacher.Address;
        }
    }
}
