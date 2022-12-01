using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;
using Filc.Models.ViewModels.Shared;

namespace Filc.Models.ViewModels.SchoolClass
{
    public class SchoolClassViewModel
    {
        public class SchoolClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<StudentViewModelShared>? Students { get; set; }
            public SchoolViewModelShared? School { get; set; }
        }
    }
}
