using TheaterTicketsManagement.IRepositories;
using TheaterTicketsManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterTicketsManagement.Repositiories
{
    public class SeatRepository : BaseRepository<Seat>, ISeatRepository
    {
        public SeatRepository(TheaterDbContext context) : base(context) {
        }
    }
}
