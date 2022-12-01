using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Shared;

namespace Filc.Models.ViewModels.Parent
{
    public class ParentrentViewModel
    {
        public int Id { get; set; }
        public ApplicationUser user { get; set; }
        public List<StudentViewModelShared> Children { get; set; }
    }
}
