using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.SchoolAdmin;

namespace Filc.Services.ModelConverter
{
    public static class ModelConverter
    {
        public static List<SchoolAdminViewModel> MapSchoolAdminToSchoolAdminViewModel(List<SchoolAdmin> schoolAdmin)
        {
            List<SchoolAdminViewModel> schoolAdminList = new List<SchoolAdminViewModel>();

            foreach (SchoolAdmin admin in schoolAdmin)
            {
                schoolAdminList.Add(new SchoolAdminViewModel(admin));
            }

            return schoolAdminList;
        }

    }
}
