using GameDataApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameDataApp.ControllersOld
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        [HttpPost]
        public ActionResult CreateQuest([FromBody] Quest quest)
        {
            var successfullyCreated = true;

            if (!successfullyCreated)
            {
                return BadRequest();
            }

            return Created("[controller]", quest);
        }


        [HttpGet]
        public ActionResult GetQuests([FromQuery] int count)
        {
            Quest[] quests = {
                new() { Id = 1, Name = "First quest" },
                new() { Id = 2, Name = "Second quest" },
                new() { Id = 3, Name = "Third quest" }
            };

            if (!quests.Any())
            {
                return NotFound();
            }

            return Ok(quests.Take(count));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteQuest(int id)
        {
            var successfullyDeleted = true;

            if (!successfullyDeleted)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut("entire/{id}")]
        public ActionResult UpdateEntireQuest(int id)
        {
            var successfullyUpdated = true;

            if (!successfullyUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch("partial/{id}")]
        public ActionResult UpdatePartialQuest(int id)
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
