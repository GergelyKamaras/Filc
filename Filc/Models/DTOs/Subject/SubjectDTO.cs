namespace Filc.Models.EntityViewModels.Subject
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public SubjectDTO(EFDataAccessLibrary.Models.Subject subject)
        {
            Title = subject.Title;
        }
    }
}