﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table ("Admin")]
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required, StringLength(50,ErrorMessage ="Must be at least 50 characters!")]
        public string Email { get; set; }
        [Required, StringLength(50, ErrorMessage = "Must be at least 50 characters!")]
        public string Password { get; set; }
        public string AdminAutherization { get; set; }
    }
}