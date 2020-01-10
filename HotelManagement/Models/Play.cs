using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterTicketsManagement.Models
{
    public class Play : Base
    {
        public string PlayTitle { get; set; }

        public DateTime date { get; set; }

        virtual public ICollection<Reservation> Reservations { get; set; }
    }
}
