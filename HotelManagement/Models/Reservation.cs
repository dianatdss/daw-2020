using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterTicketsManagement.Models
{
    public class Reservation : Base
    {
        public Boolean IsPaid { get; set; }
        public int Price { get; set; }

        public int SeatId { get; set; }

        public int PlayId {get;set;}
        public string AppUserId {get;set;}

       
        public virtual Seat Seat { get; set; }
        public virtual Play Play { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
