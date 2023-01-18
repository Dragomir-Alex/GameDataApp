using GameDataApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameDataApp.ControllersOld
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        [HttpPost]
        public ActionResult CreateInventory([FromBody] Inventory inventory)
        {
            var successfullyCreated = true;

            if (!successfullyCreated)
            {
                return BadRequest();
            }

            return Created("[controller]", inventory);
        }


        [HttpGet]
        public ActionResult GetInventories([FromQuery] int count)
        {
            Inventory[] inventories = {
                new() { Id = 1, PlayerId = 1 },
                new() { Id = 2, PlayerId = 2 },
                new() { Id = 3, PlayerId = 3 }
            };

            if (!inventories.Any())
            {
                return NotFound();
            }

            return Ok(inventories.Take(count));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteInventory(int id)
        {
            var successfullyDeleted = true;

            if (!successfullyDeleted)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut("entire/{id}")]
        public ActionResult UpdateEntireInventory(int id)
        {
            var successfullyUpdated = true;

            if (!successfullyUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch("partial/{id}")]
        public ActionResult UpdatePartialInventory(int id)
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
