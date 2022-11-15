using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.Models.ModelInterfaces;
using Filc.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Filc.Controllers.Apis
{
    [Route("api/")]
    [ApiController]
    public class SchoolAdminApi : ControllerBase
    {
        // Users
        [HttpGet]
        [Route("user")]
        public IUser GetUser(string userRole, int id)
        {
            // Restricted to: Self, Government admin, SchoolAdmin that matches id of school, teacher of school, parent of child
            return null;
        }

        [HttpPost]
        [Route("user")]
        public void AddUser([FromBody]IUser user)
        {
            // Restricted to: GovernmentAdmin, SchoolAdmin
        }

        [HttpPut]
        [Route("user")]
        public void UpdateUser([FromBody]IUser user)
        {
            // Restricted to: Government admin, SchoolAdmin, self, parent of child
        }

        [HttpDelete]
        [Route("user")]
        public void DeleteUser(string userRole, int id)
        {
            // Restricted to: Government admin, SchoolAdmin
        }

        // Lessons
        [HttpGet]
        [Route("lesson")]
        public Lesson GetLesson(int id)
        {
            // GovernmentAdmin, SchoolAdmin and school users if User school id matches lesson school id
            return null;
        }

        [HttpPost]
        [Route("lesson")]
        public void AddLesson([FromBody]Lesson lesson)
        {
            // Restricted to: GovernmentAdmin, SchoolAdmin
        }

        [HttpPut]
        [Route("lesson")]
        public void UpdateLesson([FromBody]Lesson lesson)
        {
            //Restricted to: GovernmentAdmin, SchoolAdmin
        }

        [HttpDelete]
        [Route("lesson")]
        public void DeleteLesson(int id)
        {
            //Restricted to: GovernmentAdmin, SchoolAdmin
        }

        //Marks
        [HttpGet]
        [Route("mark")]
        public Mark GetMark(int id)
        {
            //Restricted to: GovernmentAdmin, SchoolAdmin, child, teacher, parent of child
            return null;
        }

        [HttpPost]
        [Route("mark")]
        public void AddMark([FromBody]Mark mark)
        {
            // Restricted to: Teacher, there needs to be a lesson where the child is taught by the teacher
        }

        [HttpPut]
        [Route("mark")]
        public void UpdateMark([FromBody]Mark mark)
        {
            // Restricted to: Teacher, there needs to be a lesson where the child is taught by the teacher
        }

        [HttpDelete]
        [Route("mark")]
        public void DeleteMark(int id)
        {
            // Restricted to: Teacher, there needs to be a lesson where the child is taught by the teacher
        }
    }
}
