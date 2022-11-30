using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.SchoolAdmin;

namespace Filc.Services.ModelConverter
{
    public static class ModelConverter
    {
        public static List<SchoolAdminViewModel> MapSchoolAdminToSchoolAdminViewModel(List<SchoolAdmin> schoolAdmin)
        {
            List<SchoolAdminViewModel> returnList = new List<SchoolAdminViewModel>();

            foreach (SchoolAdmin admin in schoolAdmin)
            {
                returnList.Add(new SchoolAdminViewModel(admin));
            }

            return returnList;
        }
        
    }
}
