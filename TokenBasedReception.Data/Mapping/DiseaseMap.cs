using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenBasedReception.Core.Entity;

namespace TokenBasedReception.Data.Mapping
{
    public class DiseaseMap : EntityTypeConfiguration<Disease>
    {
        public DiseaseMap()
        {
            //key
            HasKey(t => t.ID);
            //properties
            Property(t => t.Code).IsRequired();
            Property(t => t.DisplayName).IsRequired();
            Property(t => t.Description);
            Property(t => t.AddedOn).IsRequired();
            Property(t => t.ModifiedOn).IsRequired();

            HasMany(u => u.Patients).WithMany(u => u.Diseases);
            
            //table
            ToTable("Diseases");
        }
    }
}
