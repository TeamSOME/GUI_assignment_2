using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GUI_assignment_2.Models
{
    public class OrderModel
    {
        [Required]
        public int OrderModelId { get; set; }
        [Required]
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }//Bindes til Restaurant
        [Required]
        public DateTime Date { get; set; }
        public int Adults { get; set; } = 0;
        public int Kids { get; set; } = 0;
        public int CheckedInAdults { get; set; } = 0;//Bindes til Restaurant eller til reception?
        public int CheckedInKids { get; set; } = 0;//Bindes til Restaurant

    }
}
