using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToLateToCare_5.Data
{
    public class ToLateToCare_5Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ToLateToCare_5Context() : base("name=ToLateToCare_5Context")
        {
        }

        public System.Data.Entity.DbSet<ToLateToCare_5.Models.UtilisateurModel> UtilisateurModels { get; set; }

        public System.Data.Entity.DbSet<ToLateToCare_5.Models.TicketModel> TicketModels { get; set; }

        public System.Data.Entity.DbSet<ToLateToCare_5.Models.TagModel> TagModels { get; set; }
    }
}
