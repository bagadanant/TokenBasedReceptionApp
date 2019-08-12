using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenBasedReception.Core.Entity
{
  public  class WaitingQueue : BaseEntity
    {
        public WaitingQueue()
        {
            this.AddedOn = DateTime.UtcNow;
            this.ModifiedOn = DateTime.UtcNow;
        }

        public int TokenNumber { get; set; }

        public Int64? AppointmentId { get; set; }

        public virtual Appointment Appointment { get; set; }
        
    }
}
