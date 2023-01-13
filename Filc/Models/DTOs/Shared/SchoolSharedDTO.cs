using EFDataAccessLibrary.Models;

namespace Filc.Models.DTOs.Shared
{
    public class SchoolSharedDTO
    {
        public SchoolSharedDTO(School school)
        {
            Id = school.Id;
            Name = school.Name;
            Address = school.Address;
            SchoolType = school.SchoolType;
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? SchoolType { get; set; }
    }
}
