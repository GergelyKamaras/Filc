using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Shared;
using System.ComponentModel.DataAnnotations;

namespace Filc.Models.InputDTOs
{
    public class LessonInputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubjectId { get; set; }

    }
}
