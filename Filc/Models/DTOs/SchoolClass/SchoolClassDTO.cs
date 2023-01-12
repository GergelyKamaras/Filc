using Filc.Models.DTOs.Shared;

namespace Filc.Models.EntityViewModels.SchoolClass
{
    public class SchoolClassDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentSharedDTO>? Students { get; set; }
        public SchoolSharedDTO? School { get; set; }

    }
}
