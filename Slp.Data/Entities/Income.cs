﻿using System.ComponentModel.DataAnnotations;

namespace Slp.Data.Entities
{
    public class Income:BaseIncome
    {
        [Required]
        public DateTime Date { get; set; }
    }
}
