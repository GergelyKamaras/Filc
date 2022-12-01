using System.ComponentModel.DataAnnotations;
using EFDataAccessLibrary.Models;

namespace Filc.Models.ViewModels.Shared
{
    public class SchoolClassViewModelShared
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SchoolClassViewModelShared(EFDataAccessLibrary.Models.SchoolClass schoolClass)
        {
            Id = schoolClass.Id;
            Name = schoolClass.Name;
        }
    }
}
