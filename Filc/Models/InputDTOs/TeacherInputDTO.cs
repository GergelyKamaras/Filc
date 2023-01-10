﻿using EFDataAccessLibrary.Models;

namespace Filc.Models.InputDTOs
{
    public class TeacherInputDTO
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
    }
}