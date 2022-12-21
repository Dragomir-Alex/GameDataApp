using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameDataApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        [HttpPost]
        public ActionResult CreateInventory()
        {
            var successfullyCreated = true;

            if (!successfullyCreated)
            {
                return BadRequest();
            }

            return Created("[controller]", new object());
        }


        [HttpGet]
        public ActionResult GetInventories()
        {
            string[] inventories = { "Player_1's inventory: Item1, Item2 etc.",
                                     "Player_2's inventory: Item1, Item2 etc.",
                                     "Player_3's inventory: Item1, Item2 etc."};

            if (inventories == null)
            {
                return NotFound();
            }

            return Ok(inventories);
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
