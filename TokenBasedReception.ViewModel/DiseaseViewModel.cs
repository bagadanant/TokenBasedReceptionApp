using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenBasedReception.ViewModel
{
    public class DiseaseViewModel : BaseEntityViewModel
    {
        public DiseaseViewModel()
        {
            this.AddedOn = DateTime.UtcNow;
            this.ModifiedOn = DateTime.UtcNow;
        }

        public string Code { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public ICollection<PatientViewModel> Patients { get; set; }
    }
}
