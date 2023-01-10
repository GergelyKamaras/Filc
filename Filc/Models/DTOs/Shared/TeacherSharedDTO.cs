using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Filc.Models.ViewModels.Shared
{
    public class TeacherSharedDTO
    {
        public int Id { get; set; }
        public ApplicationUser user { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

        public TeacherSharedDTO(EFDataAccessLibrary.Models.Teacher teacher)
        {
            Id = teacher.Id;
            user = teacher.User;
            FirstName = teacher.FirstName;
            LastName = teacher.LastName;
            BirthDate = teacher.BirthDate;
            Address = teacher.Address;
        }
    }
}
