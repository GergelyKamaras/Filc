using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;
using Filc.Models.ViewModels.Shared;

namespace Filc.Models.ViewModels.SchoolClass
{
    public class SchoolClassDTO
    {
        public class SchoolClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<StudentSharedDTO>? Students { get; set; }
            public SchoolSharedDTO? School { get; set; }
        }
    }
}
