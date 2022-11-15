using Microsoft.AspNetCore.Mvc;

namespace Filc.Filc.Filc.Controllers.Apis
{
    // TODO restrict Endpoint access to GovernmentAdmins
    [Route("/api/gov")]
    public class GovernmentAdminApi : Controller
    {
        [HttpGet]
        [Route("school")]
        public School GetSchool(int schoolId)
        {

        }

        [HttpPost]
        [Route("school")]
        public void AddSchool(School school)
        {

        }

        [HttpPut]
        [Route("school")]
        public void UpdateSchool(School school)
        {

        }

        [HttpDelete]
        [Route("school")]
        public void DeleteSchool(int schoolId)
        {

        }
    }
}
