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
        [Display(Name = "Total Adults for the chosen day")]
        public int TotalAdultsDate { get; set; }
        [Display(Name = "Total Kids for the chosen day")]
        public int TotalKidsDate { get; set; }
        [Display(Name = "Total Adults and Kids for the chosen day")]
        public int Total { get; set; } // Kids + Adults
        [Display(Name = "Checked In Adults")]
        public int CheckedInAdults { get; set; }
        [Display(Name = "Checked In Kids")]
        public int CheckedInKids { get; set; }
        [Display(Name = "Remaining Adults")]
        public int RemainingAdults { get; set; }
        [Display(Name = "Remaining Kids")]
        public int RemainingKids { get; set; }
        [Display(Name = "Remaining Total")]
        public int RemainingTotal { get; set; }
        public String Date { get; set; }
    }
}
