﻿using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface ISchoolService
    {
        public School GetSchool(int id);
        public List<School> GetAllSchools();
        public void AddSchool(School school);
        public void RemoveSchool(int id);
        public void UpdateSchool(School school);
    }
}
