﻿using TheaterTicketsManagement.Models;
using TheaterTicketsManagement.Repositiories;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterTicketsManagement.IRepositories
{
    public interface IPlayRepository : IBaseRepository<Play>
    {
        void SetAsOccupied();
    }
}
