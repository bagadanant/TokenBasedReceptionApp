using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenBasedReception.Core.Entity
{
   public class Disease : BaseEntity
    {
        public Disease()
        {
            this.AddedOn = DateTime.UtcNow;
            this.ModifiedOn = DateTime.UtcNow;
        }

        public string Code { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

    }
}
