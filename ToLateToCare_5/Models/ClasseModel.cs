﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToLateToCare_5.Models
{
    public class ClasseModel
    {
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        [Required]
        public string libelle { get; set; }

    }
}