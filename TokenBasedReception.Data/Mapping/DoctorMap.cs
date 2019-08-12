using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenBasedReception.Core.Entity;

namespace TokenBasedReception.Data.Mapping
{
    public class DoctorMap : EntityTypeConfiguration<Doctor>
    {
        public DoctorMap()
        {
            //key
            HasKey(t => t.ID);
            //properties
            Property(t => t.FirstName).IsRequired();
            Property(t => t.LastName).IsRequired();
            Property(t => t.AddedOn).IsRequired();
            Property(t => t.ModifiedOn).IsRequired();
            
            HasMany(u => u.Appointments);
            //table
            ToTable("Doctors");
        }
    }
}
