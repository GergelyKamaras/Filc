using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [Authorize]
    [Route("/api/gov")]
    public class GovernmentAdminApi : Controller
    {
        [HttpGet]
        [Route("school")]
        public School GetSchool(int schoolId)
        {
            // Restricted to: Government admin, SchoolAdmin that matches id of school
        }

        [HttpPost]
        [Route("school")]
        public void AddSchool(School school)
        {
            // Restricted to: Government admin
        }

        [HttpPut]
        [Route("school")]
        public void UpdateSchool(School school)
        {
            // Restricted to: Government admin
        }

        [HttpDelete]
        [Route("school")]
        public void DeleteSchool(int schoolId)
        {
            // Restricted to: Government admin
        }
    }
}
