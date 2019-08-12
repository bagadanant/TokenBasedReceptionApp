using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenBasedReception.Core.Entity;

namespace TokenBasedReception.Data
{
    internal class AppDbInitializer : MigrateDatabaseToLatestVersion<AppDbContext, Migrations.Configuration>
    {
        public override void InitializeDatabase(AppDbContext context)
        {

            IList<Disease> defaultDiseases = new List<Disease>()
            {
                new Disease() { Code = "Ischemic", DisplayName = "Ischemic heart disease" },
                new Disease() { Code = "Malaria", DisplayName = "Malaria" },
                new Disease() { Code = "Dengue", DisplayName = "Dengue" },
                new Disease() { Code = "Tuberculosis", DisplayName = "Tuberculosis" }
            };
            context.Entry(defaultDiseases);

            IList<Doctor> defaultDoctors = new List<Doctor>();
            defaultDoctors.Add(new Doctor() { FirstName = "Jim", LastName = "Orbit" });
            context.Entry(defaultDoctors);

            base.InitializeDatabase(context);
        }
    }
}
