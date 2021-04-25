using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_assignment_2.Models
{
    public class KitchenModel
    {
        public int KitchenModelID { get; set; }
        [Display(Name = "Total Adults for a chousen day")]
        public int TotalAdultsDate { get; set; }
        [Display(Name = "Total Kids for a chousen day")]
        public int TotalKidsDate { get; set; }
        [Display(Name = "Total Adults and Kids for a chousen dag")]
        public int Total { get; set; } // Kids + Adults
        [Display(Name = "Checked In Adults")]
        public int CheckedInAdults { get; set; }
        public int CheckedInKids { get; set; }
        public int RemainingAdults { get; set; }
        public int RemainingKids { get; set; }
        public int RemainingTotal { get; set; }
        public String Date { get; set; }
    }
}
