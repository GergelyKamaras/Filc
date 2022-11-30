using System.ComponentModel.DataAnnotations;
using EFDataAccessLibrary.Models;

namespace Filc.Models.EntityViewModels.School
{
    public class SubjectViewModelForSchool
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public SubjectViewModelForSchool(Subject subject)
        {
            Id = subject.Id;
            Title = subject.Title;
        }
    }
}
