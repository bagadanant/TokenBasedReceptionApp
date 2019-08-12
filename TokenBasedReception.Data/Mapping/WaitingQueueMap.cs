using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenBasedReception.Core.Entity;

namespace TokenBasedReception.Data.Mapping
{
    public class WaitingQueueMap : EntityTypeConfiguration<WaitingQueue>
    {
        public WaitingQueueMap()
        {
            //key
            HasKey(t => t.ID);
            //properties
            Property(t => t.TokenNumber).IsRequired();
            Property(t => t.AddedOn).IsRequired();
            Property(t => t.ModifiedOn).IsRequired();

            HasRequired(u => u.Appointment).WithOptional(u => u.WaitingQueue);

            //table
            ToTable("WaitingQueue");
        }
    }
}
