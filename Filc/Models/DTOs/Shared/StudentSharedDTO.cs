using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Filc.Models.ViewModels.Shared
{
    public class StudentSharedDTO
    {
        public int Id { get; set; }
        public ApplicationUser user { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

        public StudentSharedDTO(EFDataAccessLibrary.Models.Student student)
        {
            Id = student.Id;
            user = student.user;
            FirstName = student.FirstName;
            LastName = student.LastName;
            BirthDate = student.BirthDate;
            Address = student.Address;
        }
    }
}
