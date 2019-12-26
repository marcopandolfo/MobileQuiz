﻿using Quiz.Dependencies.Enums;
using Quiz.Dependencies.Interfaces;

using System.ComponentModel.DataAnnotations;

namespace Quiz.API.Models
{
    public class QuestionModel : IQuestion
    {
        public int? QuestionID { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string CorrectAnswer { get; set; }

        [Required]
        public CategoryEnum Category { get; set; }

        [Required]
        public string IncorrectAnswers { get; set; }
    }
}