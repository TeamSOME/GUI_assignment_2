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
        public DateTime Date { get; set; }
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }
        public int Kids { get; set; }
        public int Adults { get; set; }
    }
}
