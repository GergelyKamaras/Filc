using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [Authorize]
    [ApiController]
    [Route("api/parent")]
    public class ParentApiController : ControllerBase
    {
        private readonly IStudentServiceForParentRole _studentService;
        private readonly ISchoolServiceForParentRole _schoolService;
        private readonly IMarkServiceForParentRole _markService;
        private readonly IParentServiceForParentRole _parentService;

        public ParentApiController(IStudentServiceForParentRole studentService, ISchoolServiceForParentRole schoolService,
            IMarkServiceForParentRole markService, IParentServiceForParentRole parentService)
        {
            _studentService = studentService;
            _schoolService = schoolService;
            _markService = markService;
            _parentService = parentService;
        }
    }
}
