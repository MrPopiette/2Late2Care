using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using _2Late2CareBack;
using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace ToLateToCare_front.Data
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ContexteBDD : DbContext
    {

        public ContexteBDD()
        {
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }

        public ContexteBDD(DbContextOptions<ContexteBDD> options) : base(options)
        {

        }

        public Microsoft.EntityFrameworkCore.DbSet<Tag> Tags { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Ticket> Tickets { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Utilisateur> Utilisateurs { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Classe> Classes { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Vote> Votes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketTag>().HasKey(tt => new { tt.libelle, tt.TicketId });
            modelBuilder.Entity<Vote>().HasKey(v => new { v.utilisateurId, v.ticketId });
        }


    }
}
