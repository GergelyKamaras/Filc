using System.ComponentModel.DataAnnotations;
using EFDataAccessLibrary.Models;

namespace Filc.Models.ViewModels.Shared
{
    public class SubjectSharedDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public SubjectSharedDTO(Subject subject)
        {
            Id = subject.Id;
            Title = subject.Title;
        }
    }
}
