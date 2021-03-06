using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GUI_assignment_2.Models
{
    public class CheckedInModel
    {
        public int CheckedInModelID { get; set; }
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }
        [Display(Name = "Kids Checked In")]
        public int CheckedInKids { get; set; }
        [Display(Name = "Adults Checked In")]
        public int CheckedInAdults { get; set; }
    }
}
