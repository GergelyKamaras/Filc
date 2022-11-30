using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;
using Filc.Models.EntityViewModels.SchoolAdmin;

namespace Filc.Services.ModelConverter
{
    public static class ModelConverter
    {
        public static List<SchoolAdminViewModel> MapSchoolAdminToSchoolAdminViewModel(List<SchoolAdmin> schoolAdmins)
        {
            List<SchoolAdminViewModel> schoolAdminList = new List<SchoolAdminViewModel>();
            schoolAdmins.ForEach(admin => schoolAdminList.Add(new SchoolAdminViewModel(admin)));

            return schoolAdminList;
        }

        public static List<SchoolViewModel> MapSchoolToSchoolViewModel(List<School> schools)
        {
            List<SchoolViewModel> schoolList = new List<SchoolViewModel>();
            schools.ForEach(school => schoolList.Add(new SchoolViewModel(school)));
            return schoolList;
        }

    }
}
