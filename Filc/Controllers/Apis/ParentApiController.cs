using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.EntityBasedInterfaces;
using Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentApiController : ControllerBase
    {
        private IParentRoleSchoolService _studentService;
        private IParentRoleSchoolService _schoolService;
        private IParentRoleSchoolService _markService;
        private IParentRoleSchoolService _parentService;

        public ParentApiController(IParentRoleSchoolService studentService, IParentRoleSchoolService schoolService, 
            IParentRoleSchoolService markService, IParentRoleSchoolService parentService)
        {
            _studentService = studentService;
            _schoolService = schoolService;
            _markService = markService;
            _parentService = parentService;
        }

        [Route("/student")]
        [HttpGet]
        public Student GetStudent(int id)
        {
            return _studentService.GetStudent(id);
        }

    }
}
