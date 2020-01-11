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
    public class PlayController : Controller
    {
        private readonly ILogger<PlayController> _logger;

        private readonly IPlayRepository _playRepository;
        public PlayController(ILogger<PlayController> logger, IPlayRepository playRepository)
        {
            _logger = logger;
            _playRepository = playRepository;
        }

        [HttpGet("all")]
        public async Task<ObjectResult> GetAllPlaysAsync()
        {
            List<Play> result = await _playRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("by-id")]
        public async Task<ObjectResult> GetPlayByIdAsync(int id)
        {
            Play result = await _playRepository.GetOneByCondition((Play) => Play.Id == id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete")]
        public void DeletePlay(int id)
        {
            _playRepository.Delete(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("update")]
        public ObjectResult UpdatePlay(Play p)
        {
            Play result = _playRepository.Update(p);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<ObjectResult> CreatePlayAsync(Play p)
        {
            Play result = await _playRepository.CreateAsync(p);
            return Ok(result);
        }
    }
}