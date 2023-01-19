using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameDataApp.Data;
using GameDataApp.Models;
using GameDataApp.DAL;

namespace GameDataApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly GenericRepository<Inventory> _inventoryRepository;

        public InventoriesController(GameDataAppContext context)
        {
            _inventoryRepository = new GenericRepository<Inventory>(context);
        }

        /// <summary>
        /// Returns all the Inventory table entries.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventories()
        {
            var inventories = await _inventoryRepository.Get();

            if (inventories == null)
            {
                return NotFound();
            }
            return Ok(inventories);
        }

        /// <summary>
        /// Returns the Inventory table entry with the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventory(int id)
        {
            var inventory = await _inventoryRepository.GetById(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

        /// <summary>
        /// Updates the Inventory table entry with the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="inventory"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory(int id, Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return BadRequest();
            }

            await _inventoryRepository.Update(inventory);

            try
            {
                await _inventoryRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await InventoryExists(id))
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
        /// Creates a new Inventory table entry.
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory)
        {
            await _inventoryRepository.Insert(inventory);
            await _inventoryRepository.Save();

            return CreatedAtAction("GetInventory", new { id = inventory.Id }, inventory);
        }

        /// <summary>
        /// Deletes the Inventory table entry with the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            await _inventoryRepository.Delete(id);
            await _inventoryRepository.Save();

            return NoContent();
        }

        private async Task<bool> InventoryExists(int id)
        {
            return await _inventoryRepository.Exists(id);
        }
    }
}
