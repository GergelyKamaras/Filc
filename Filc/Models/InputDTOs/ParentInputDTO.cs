﻿using EFDataAccessLibrary.Models;
using Filc.Models.ViewModels.Shared;

namespace Filc.Models.ViewModels.Parent
{
    public class ParentInputDTO
    {
        public int? Id { get; set; }
        public ApplicationUser user { get; set; }

    }
}
