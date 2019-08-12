using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenBasedReception.Core.Entity
{
    public class Patient : BaseEntity
    {
        public Patient()
        {
            this.AddedOn = DateTime.UtcNow;
            this.ModifiedOn = DateTime.UtcNow;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public virtual ICollection<Disease> Diseases { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
