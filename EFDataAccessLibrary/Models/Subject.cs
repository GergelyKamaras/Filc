﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class Subject
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

    }
}
