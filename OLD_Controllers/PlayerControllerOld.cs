using GameDataApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameDataApp.ControllersOld
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [HttpPost]
        public ActionResult CreatePlayer([FromBody] Player player)
        {
            var successfullyCreated = true;

            if (!successfullyCreated)
            {
                return BadRequest();
            }

            return Created("[controller]", player);
        }


        [HttpGet]
        public ActionResult GetPlayers([FromQuery] int count)
        {
            Player[] players = {
                new() { Id = 1, Username = "First user", Password = "123" },
                new() { Id = 2, Username = "Second user", Password = "456" },
                new() { Id = 3, Username = "Third user", Password = "789" }
            };

            if (!players.Any())
            {
                return NotFound();
            }

            return Ok(players.Take(count));
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePlayer(int id)
        {
            var successfullyDeleted = true;

            if (!successfullyDeleted)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut("entire/{id}")]
        public ActionResult UpdateEntirePlayer(int id)
        {
            var successfullyUpdated = true;

            if (!successfullyUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch("partial/{id}")]
        public ActionResult UpdatePartialPlayer(int id)
        {
            var successfullyUpdated = true;

            if (!successfullyUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}