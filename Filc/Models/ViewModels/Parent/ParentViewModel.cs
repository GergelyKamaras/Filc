using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Shared;

namespace Filc.Models.ViewModels.Parent
{
    public class ParentViewModel
    {
        public int Id { get; set; }
        public ApplicationUser user { get; set; }
        public List<StudentViewModelShared> Children { get; set; }

        public ParentViewModel(EFDataAccessLibrary.Models.Parent parent)
        {
            Id = parent.Id;
            user = parent.user;
            Children = new List<StudentViewModelShared>();
            parent.Children.ForEach(child => Children.Add(new StudentViewModelShared(child)));
        }
    }
}
