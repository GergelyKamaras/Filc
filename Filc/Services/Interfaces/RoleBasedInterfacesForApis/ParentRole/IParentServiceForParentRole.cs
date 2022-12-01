﻿using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Parent;

namespace Filc.Services.Interfaces.RoleBasedInterfacesForApis.ParentRole
{
    public interface IParentServiceForParentRole
    {
        public ParentViewModel GetParent(int id);
        public void UpdateParent(Parent parent);
    }
}
