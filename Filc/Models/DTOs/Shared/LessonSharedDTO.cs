namespace Filc.Models.DTOs.Shared
{
    public class LessonSharedDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EFDataAccessLibrary.Models.Subject Subject { get; set; }
        public LessonSharedDTO(EFDataAccessLibrary.Models.Lesson lesson)
        {
            Id = lesson.Id;
            Name = lesson.Name;
            Subject = lesson.Subject;
        }
    }
}
