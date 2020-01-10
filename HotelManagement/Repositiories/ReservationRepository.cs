using TheaterTicketsManagement.IRepositories;
using TheaterTicketsManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterTicketsManagement.Repositiories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(TheaterDbContext context) : base(context) {
        }
    }
}
