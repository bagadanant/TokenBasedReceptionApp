namespace TokenBasedReception.Data.Migrations
{
    using Core.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TokenBasedReception.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TokenBasedReception.Data.AppDbContext context)
        {
            // Diseases
            IList<Disease> defaultDiseases = new List<Disease>()
            {
                new Disease() { Code = "Ischemic", DisplayName = "Ischemic heart disease" },
                new Disease() { Code = "Malaria", DisplayName = "Malaria" },
                new Disease() { Code = "Dengue", DisplayName = "Dengue" },
                new Disease() { Code = "Tuberculosis", DisplayName = "Tuberculosis" }
            };
            foreach (var disease in defaultDiseases)
            {
                context.Set<Disease>().Add(disease);
            }

            // Doctors
            IList<Doctor> defaultDoctors = new List<Doctor>() {
                new Doctor() { FirstName = "Jim", LastName = "Orbit" }
            };
            foreach (var doctor in defaultDoctors)
            {
                context.Set<Doctor>().Add(doctor);
            }

            base.Seed(context);
        }
    }
}
