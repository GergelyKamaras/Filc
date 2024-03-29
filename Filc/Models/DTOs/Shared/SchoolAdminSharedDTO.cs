﻿using EFDataAccessLibrary.Models;

namespace Filc.Models.DTOs.Shared
{
    public class SchoolAdminSharedDTO
    {
        public int Id { get; set; }
        public ApplicationUser user { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

        public SchoolAdminSharedDTO(SchoolAdmin schoolAdmin)
        {
            Id = schoolAdmin.Id;
            user = schoolAdmin.user;
            FirstName = schoolAdmin.FirstName;
            LastName = schoolAdmin.LastName;
            BirthDate = schoolAdmin.BirthDate;
            Address = schoolAdmin.Address;
        }
    }
}
