using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenBasedReception.Core.Entity;

namespace TokenBasedReceptio.Data.Mapping
{
    public class UsertMap : EntityTypeConfiguration<User>
    {
        public UsertMap()
        {
            //key
            HasKey(t => t.ID);
            //properties
            Property(t => t.UserName).IsRequired();
            Property(t => t.Email).IsRequired();
            Property(t => t.Password).IsRequired();
            Property(t => t.AddedOn).IsRequired();
            Property(t => t.ModifiedOn).IsRequired();
            //table
            ToTable("Users");
        }
    }
}
