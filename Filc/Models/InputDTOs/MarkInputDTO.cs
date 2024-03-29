﻿using EFDataAccessLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace Filc.Models.ViewModels.Shared
{
    public class MarkInputDTO
    {
        public int? Id { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public float Grade { get; set; }
        public string Description { get; set; }
        public int LessonId { get; set; }
        public int SubjectId { get; set; }
        public DateTime Date { get; set; }

    }
}
