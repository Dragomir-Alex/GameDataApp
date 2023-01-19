using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameDataApp.Data;
using GameDataApp.Models;
using GameDataApp.DAL;

namespace GameDataApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Returns all the Item table entries.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var items = await _unitOfWork.ItemRepository.Get();

            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        /// <summary>
        /// Returns the Item table entry with the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _unitOfWork.ItemRepository.GetById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        /// <summary>
        /// Updates the Item table entry with the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            await _unitOfWork.ItemRepository.Update(item);

            try
            {
                await _unitOfWork.ItemRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ItemExists(id))
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
        /// Creates a new Item table entry.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            await _unitOfWork.ItemRepository.Insert(item);
            await _unitOfWork.ItemRepository.Save();

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        /// <summary>
        /// Deletes the Item table entry with the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _unitOfWork.ItemRepository.Delete(id);
            await _unitOfWork.ItemRepository.Save();

            return NoContent();
        }

        private async Task<bool> ItemExists(int id)
        {
            return await _unitOfWork.ItemRepository.Exists(id);
        }
    }
}
