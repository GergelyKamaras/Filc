﻿using EFDataAccessLibrary.Models;
using Filc.Models.EntityViewModels.School;
using Filc.Models.ViewModels.Mark;
using Filc.Models.ViewModels.Parent;
using Filc.Models.ViewModels.Student;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filc.Controllers.Apis
{
    [ApiController]
    [Route("api/parents")]
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

        // Schools
        [HttpGet]
        [Route("schools/{id}")]
        public SchoolDTO GetSchool(int id)
        {
            return _schoolService.GetSchool(id);
        }

        // Marks
        [HttpGet]
        [Route("marks/{id}")]
        public MarkDTO GetMark(int id)
        {
            return _markService.GetMark(id);
        }

        [HttpGet]
        [Route("marks/student/{id}")]
        public List<MarkDTO> GetMarksByStudent(int id)
        {
            return _markService.GetMarksByStudent(id);
        }

        [HttpGet]
        [Route("students/{id}")]
        public StudentDTO GetStudent(int id)
        {
            return _studentService.GetStudent(id);
        }

        [HttpPut]
        [Route("students")]
        public void UpdateStudent([FromBody] Student student)
        {
            _studentService.UpdateStudent(student);
        }

        // Parents
        [HttpGet]
        [Route("parents/{id}")]
        public ParentDTO GetParent(int id)
        {
            return _parentService.GetParent(id);
        }

        [HttpPut]
        [Route("parents")]
        public void UpdateParent([FromBody] Parent parent)
        {
            _parentService.UpdateParent(parent);
        }
    }
}
