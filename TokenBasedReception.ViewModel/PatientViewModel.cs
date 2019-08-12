using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenBasedReception.ViewModel
{
    public class PatientViewModel : BaseEntityViewModel
    {
        public PatientViewModel()
        {
            this.AddedOn = DateTime.UtcNow;
            this.ModifiedOn = DateTime.UtcNow;
        }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string FullName { get { return $"{this.FirstName} {this.LastName}"; } private set { } }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        public string City { get; set; }

        [Display(Name = "Diseases")]
        public ICollection<DiseaseViewModel> Diseases { get; set; }


        public ICollection<AppointmentViewModel> Appointments { get; set; }
    }
}
