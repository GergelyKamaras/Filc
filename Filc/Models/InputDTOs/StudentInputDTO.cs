using EFDataAccessLibrary.Models;

namespace Filc.Models.InputDTOs
{
    public class StudentInputDTO
    {
        public int? Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public int SchoolId { get; set; }

    }
}