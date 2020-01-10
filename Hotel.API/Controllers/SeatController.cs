using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheaterTicketsManagement.IRepositories;
using TheaterTicketsManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace TheaterTickets.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeatController : Controller
    {
        private readonly ILogger<SeatController> _logger;

        private readonly ISeatRepository _seatRepository;

        public SeatController(ILogger<SeatController> logger, ISeatRepository seatRepository)
        {
            _logger = logger;
            _seatRepository = seatRepository;
        }

        [HttpGet("all")]
        public async Task<ObjectResult> GetAllSeatsAsync()
        {
            List<Seat> result = await _seatRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("by-id")]
        public async Task<ObjectResult> GetSeatById(int id)
        {
            Seat result = await _seatRepository.GetOneByCondition((seat) => seat.Id == id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<ObjectResult> AddSeatAsync(Seat seat)
        {
            Seat result = await _seatRepository.CreateAsync(seat);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete")]
        public void DeleteSeat(int id)
        {
            _seatRepository.Delete(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("UpdateSeat")]
        public ObjectResult UpdateSeat(Seat seat)
        {
            Seat result = _seatRepository.Update(seat);
            return Ok(result);
        }
    }
}