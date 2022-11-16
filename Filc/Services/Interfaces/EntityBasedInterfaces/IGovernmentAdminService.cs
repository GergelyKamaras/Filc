﻿using EFDataAccessLibrary.Models;

namespace Filc.Services.Interfaces.EntityBasedInterfaces
{
    public interface IGovernmentAdminService
    {
        public GovernmentAdmin GetGovernmentAdmin(int id);
        public void AddGovernmentAdmin(GovernmentAdmin governmentAdmin);
        public void RemoveGovernmentAdmin(int id);
        public void UpdateGovernmentAdmin(GovernmentAdmin governmentAdmin);
    }
}
