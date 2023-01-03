using GameDataApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameDataApp.ControllersOld
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpPost]
        public ActionResult CreateItem([FromBody] Item item)
        {
            var successfullyCreated = true;

            if (!successfullyCreated)
            {
                return BadRequest();
            }

            return Created("[controller]", item);
        }


        [HttpGet]
        public ActionResult GetItems([FromQuery] int count)
        {
            Item[] items = {
                new() { Id = 1, Name = "First item" },
                new() { Id = 2, Name = "Second item" },
                new() { Id = 3, Name = "Third item" }
            };

            if (!items.Any())
            {
                return NotFound();
            }
            return Ok(items.Take(count));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            var successfullyDeleted = true;

            if (!successfullyDeleted)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut("entire/{id}")]
        public ActionResult UpdateEntireItem(int id)
        {
            var successfullyUpdated = true;

            if (!successfullyUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch("partial/{id}")]
        public ActionResult UpdatePartialItem(int id)
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