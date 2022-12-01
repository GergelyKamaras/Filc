using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace Filc.Models.ViewModels.Shared
{
    public class MarkViewModelShared
    {
        public int Id { get; set; }
        public float Grade { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public MarkViewModelShared(EFDataAccessLibrary.Models.Mark mark)
        {
            Id = mark.Id;
            Grade = mark.Grade;
            Description = mark.Description;
            Date = mark.Date;
        }
    }
}
