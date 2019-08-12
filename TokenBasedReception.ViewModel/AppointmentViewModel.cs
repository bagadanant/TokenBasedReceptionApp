using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenBasedReception.ViewModel
{
    public class AppointmentViewModel : BaseEntityViewModel
    {
        public AppointmentViewModel()
        {
            this.AddedOn = DateTime.UtcNow;
            this.ModifiedOn = DateTime.UtcNow;
        }

        public DateTime? BookedSlot { get; set; }

        public TimeSpan? Duration { get; set; }

        public bool IsFollowUp { get; set; }

        public Int64? PatientId { get; set; }

        public PatientViewModel Patient { get; set; }

        public ICollection<DiseaseViewModel> Diseases { get; set; }

        public Int64? DoctorId { get; set; }

        public DoctorViewModel Doctor { get; set; }

        public WaitingQueueViewModel WaitingQueue { get; set; }
    }
}
