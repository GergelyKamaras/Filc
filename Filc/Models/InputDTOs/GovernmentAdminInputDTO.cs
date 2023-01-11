using EFDataAccessLibrary.Models;

namespace Filc.Models.InputDTOs
{
    public class GovernmentAdminInputDTO
    {
        public int? Id { get; set; }
        public ApplicationUser user { get; set; }
    }
}
