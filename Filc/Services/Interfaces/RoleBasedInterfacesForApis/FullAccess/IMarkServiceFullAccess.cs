﻿using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces.RoleBasedInterfaces.ParentRole;
using Filc.Services.Interfaces.RoleBasedInterfaces.StudentRole;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface IMarkServiceFullAccess : IMarkServiceForParentRole, IMarkServiceForStudentRole
    {
        public new Mark GetMark(int id);
        public new List<Mark> GetMarksByStudent(int studentId);
        public void AddMark(Mark mark);
        public void UpdateMark(Mark mark);
        public void DeleteMark(int id);
        public List<Mark> GetMarkByLesson(int lessonId);
    }
}
