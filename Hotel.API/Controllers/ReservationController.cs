using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheaterTicketsManagement.IRepositories;
using TheaterTicketsManagement.Models;

namespace TheaterTickets.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : Controller
    {
        // GET: api/<controller>
        private readonly ILogger<ReservationController> _logger;
        private IReservationRepository _ReservationRepository;
        public ReservationController(ILogger<ReservationController> logger, IReservationRepository ReservationRepository)
        {
            _logger = logger;
            _ReservationRepository = ReservationRepository;
        }


        [HttpGet("all")]
        public async Task<ObjectResult> GetAllReservationsAsync()
        {
            List<Reservation> result = await _ReservationRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("by-id")]
        public async Task<ObjectResult> GetReservationById(int id)
        {
            Reservation result = await _ReservationRepository.GetOneByCondition((Reservation) => Reservation.Id == id);
            return Ok(result);
        }

        [HttpPost("update")]
        public ObjectResult UpdateReservation(Reservation b)
        {
            Reservation result = _ReservationRepository.Update(b);
            return Ok(b);
        }

        [HttpDelete("delete")]
        public void DeleteReservation(int id)
        {
            _ReservationRepository.Delete(id);
        }

        [HttpPost("create")]
        public async Task<ObjectResult> CreateReservationAsync(Reservation p)
        {
            Reservation result = await _ReservationRepository.CreateAsync(p);
            return Ok(result);
        }
    }
}
