using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterTicketsManagement.Models
{
    public class AppUser
    {

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NormalizeUserName { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

        virtual public ICollection<Reservation> Reservations { get; set; }
    }
}
