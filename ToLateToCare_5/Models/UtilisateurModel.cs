using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToLateToCare_5.Models
{
    public class UtilisateurModel
    {

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string pseudo { get; set; }

        [Required]
        public ClasseModel classe { get; set; }

        [Required]
        public string mail { get; set; }

        [Required]
        public string password { get; set; }
    }
}