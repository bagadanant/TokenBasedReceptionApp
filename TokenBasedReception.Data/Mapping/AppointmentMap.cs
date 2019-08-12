using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenBasedReception.Core.Entity;

namespace TokenBasedReception.Data.Mapping
{
    public class AppointmentMap : EntityTypeConfiguration<Appointment>
    {
        public AppointmentMap()
        {
            //key
            HasKey(t => t.ID);
            //properties
            Property(t => t.AddedOn).IsRequired();
            Property(t => t.ModifiedOn).IsRequired();

            HasRequired(u => u.Patient).WithMany(u=> u.Appointments);
            HasMany(u => u.Diseases);
            HasRequired(u => u.Doctor).WithMany(u => u.Appointments);
            HasOptional(u => u.WaitingQueue);

            //table
            ToTable("Appointments");
        }
    }
}
