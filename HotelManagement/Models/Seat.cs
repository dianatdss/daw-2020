using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterTicketsManagement.Models
{
    public class Seat : Base
    {
        public int Number { get; set; }
        public Boolean isTaken { get; set; }

        virtual public  ICollection<Reservation> Reservations { get;set;}

    }
}
