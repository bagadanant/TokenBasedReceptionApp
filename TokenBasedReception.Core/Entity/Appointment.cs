using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenBasedReception.Core.Entity
{
    public class Appointment : BaseEntity
    {
        public Appointment()
        {
            this.AddedOn = DateTime.UtcNow;
            this.ModifiedOn = DateTime.UtcNow;
        }

        public DateTime? BookedSlot { get; set; }

        public TimeSpan? Duration { get; set; }

        public bool IsFollowUp { get; set; }

        public Int64? PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual ICollection<Disease> Diseases { get; set; }

        public Int64? DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual WaitingQueue WaitingQueue { get; set; }

    }
}
