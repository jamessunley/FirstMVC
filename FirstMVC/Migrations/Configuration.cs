namespace FirstMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FirstMVC.Models.Cars4DB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "FirstMVC.Models.Cars4DB";
        }

        protected override void Seed(FirstMVC.Models.Cars4DB context)
        {

            for (int i = 0; i < 1000; i++)
            {
                context.Cars.AddOrUpdate(r => r.Make,
                    new Models.Cars { Make = i.ToString(), Model = "Car", Price = 11111 });
            }
        }

    }
}
