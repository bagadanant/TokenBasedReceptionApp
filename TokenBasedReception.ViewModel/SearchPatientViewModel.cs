using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenBasedReception.ViewModel
{
    public class SearchPatientViewModel
    {

        [Required]
        public string Keyword { get; set; }
    }
}
