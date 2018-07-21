using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace FirstMVC.Models
{
    public class Cars4DB : DbContext
    {
        public DbSet<Cars> Cars { get; set; }
        public DbSet <CarReviews> Reviews { get; set; }

        public Cars4DB()
        {
            Database.SetInitializer<Cars4DB>(new CreateDatabaseIfNotExists<Cars4DB>());
        }
    }
}