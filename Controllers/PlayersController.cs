using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameDataApp.Data;
using GameDataApp.Models;
using GameDataApp.DAL;

namespace GameDataApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly GenericRepository<Player> _playerRepository;

        public PlayersController(GameDataAppContext context)
        {
            _playerRepository = new GenericRepository<Player>(context);
        }

        /// <summary>
        /// Returns all the Player table entries.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayer()
        {
            var players = await _playerRepository.Get();

            if (players == null)
            {
                return NotFound();
            }
            return Ok(players);
        }

        /// <summary>
        /// Returns the Player table entry with the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _playerRepository.GetById(id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        /// <summary>
        /// Updates the Player table entry with the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="player"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            _playerRepository.Update(player);

            try
            {
                await _playerRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Creates a new Player table entry.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            await _playerRepository.Insert(player);
            await _playerRepository.Save();

            return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
        }

        /// <summary>
        /// Deletes the Player table entry with the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            await _playerRepository.Delete(id);
            await _playerRepository.Save();

            return NoContent();
        }

        private async Task<bool> PlayerExists(int id)
        {
            return await _playerRepository.Exists(id);
        }
    }
}
