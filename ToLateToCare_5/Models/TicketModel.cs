using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToLateToCare_5.Models
{
    public class TicketModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string titre { get; set; }

        [StringLength(150)]
        [Required]
        public string description { get; set; }

        public DateTime date { get; set; }

        [Required]
        public UtilisateurModel auteur { get; set; }

        public string urlPhoto { get; set; }

        public ICollection<TagModel> tags { get; set; }
    }
}