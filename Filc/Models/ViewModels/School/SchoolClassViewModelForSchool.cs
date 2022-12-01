using System.ComponentModel.DataAnnotations;
using EFDataAccessLibrary.Models;

namespace Filc.Models.EntityViewModels.School
{
    public class SchoolClassViewModelForSchool
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SchoolClassViewModelForSchool(SchoolClass schoolClass)
        {
            Id = schoolClass.Id;
            Name = schoolClass.Name;
        }
    }
}
