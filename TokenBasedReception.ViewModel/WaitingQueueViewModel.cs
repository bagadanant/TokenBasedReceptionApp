using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenBasedReception.ViewModel
{
    public class WaitingQueueViewModel : BaseEntityViewModel
    {
        public WaitingQueueViewModel()
        {
            this.AddedOn = DateTime.UtcNow;
            this.ModifiedOn = DateTime.UtcNow;
        }

        public int TokenNumber { get; set; }

        public Int64? AppointmentId { get; set; }

        public virtual AppointmentViewModel Appointment { get; set; }
    }
}
