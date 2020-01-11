using TheaterTicketsManagement.IRepositories;
using TheaterTicketsManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterTicketsManagement.Repositiories
{
    public class PlayRepository : BaseRepository<Play>, IPlayRepository
    {
        public PlayRepository(TheaterDbContext context) : base(context) {
        }

        public void SetAsOccupied()
        {
            // sets room as occupied
        }
    }
}
