using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameDataApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        [HttpPost]
        public ActionResult CreateQuest()
        {
            var successfullyCreated = true;

            if (!successfullyCreated)
            {
                return BadRequest();
            }

            return Created("[controller]", new object());
        }


        [HttpGet]
        public ActionResult GetQuests()
        {
            string[] Quests = { "Quest_1", "Quest_2", "Quest_3" };

            if (Quests == null)
            {
                return NotFound();
            }

            return Ok(Quests);
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
