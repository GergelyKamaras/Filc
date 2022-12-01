using System.ComponentModel.DataAnnotations;
using EFDataAccessLibrary.Models;

namespace Filc.Models.ViewModels.Shared
{
    public class SubjectViewModelShared
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public SubjectViewModelShared(Subject subject)
        {
            Id = subject.Id;
            Title = subject.Title;
        }
    }
}
