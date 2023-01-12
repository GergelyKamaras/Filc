using EFDataAccessLibrary.Models;
using Filc.Models.DTOs.Shared;
using Filc.Models.ViewModels.Shared;

namespace Filc.Models.ViewModels.Parent
{
    public class ParentDTO
    {
        public int Id { get; set; }
        public ApplicationUser user { get; set; }
        public List<StudentSharedDTO> Children { get; set; }

        public ParentDTO(EFDataAccessLibrary.Models.Parent parent)
        {
            Id = parent.Id;
            user = parent.user;
            Children = new List<StudentSharedDTO>();
            parent.Children.ForEach(child => Children.Add(new StudentSharedDTO(child)));
        }
    }
}
