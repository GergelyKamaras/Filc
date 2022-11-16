using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ParentApiController : ControllerBase
    {
        private readonly IParentRoleStudentService _studentService;
        private readonly IParentRoleSchoolService _schoolService;
        private readonly IParentRoleMarkService _markService;
        private readonly IParentRoleParentService _parentService;

        public ParentApiController(IParentRoleStudentService studentService, IParentRoleSchoolService schoolService,
            IParentRoleMarkService markService, IParentRoleParentService parentService)
        {
            _studentService = studentService;
            _schoolService = schoolService;
            _markService = markService;
            _parentService = parentService;
        }
    }
}
