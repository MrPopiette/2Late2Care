using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToLateToCare_5.Models
{
    public class ContexteBdd : DbContext
    {
        public ContexteBdd()
        {
        }

        public ContexteBdd(DbContextOptions<ContexteBdd> options) : base(options)
        {
        }

        public DbSet<TagModel> Tags { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }
        public DbSet<UtilisateurModel> Utilisateurs { get; set; }
        public DbSet<ClasseModel> Classes { get; set; }
        public DbSet<VoteModel> Votes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VoteModel>().HasKey(v => new { v.utilisateurId, v.ticketId });
        }
    }
}