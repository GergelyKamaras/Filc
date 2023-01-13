namespace Filc.Models.DTOs.Shared
{
    public class SchoolClassSharedDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SchoolClassSharedDTO(EFDataAccessLibrary.Models.SchoolClass schoolClass)
        {
            Id = schoolClass.Id;
            Name = schoolClass.Name;
        }
    }
}
