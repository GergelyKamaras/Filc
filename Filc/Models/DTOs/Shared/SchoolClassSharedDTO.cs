using System.ComponentModel.DataAnnotations;
using EFDataAccessLibrary.Models;

namespace Filc.Models.ViewModels.Shared
{
    public class SchoolClassSharedDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SchoolClassSharedDTO(EFDataAccessLibrary.Models.SchoolClass schoolClass)
        {
            Id = schoolClass.Id;
            Name = schoolClass.Name;
        }
    }
}
