using EFDataAccessLibrary.Models;

namespace Filc.Models.InputDTOs
{
    public class SchoolClassInputDTO
    {
        public int Id { get; set; }
        public ApplicationUser user { get; set; }
        public int SchoolId { get; set; }
    }
}
