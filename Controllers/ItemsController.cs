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
        private readonly GenericRepository<Item> _itemRepository;

        public ItemsController(GameDataAppContext context)
        {
            _itemRepository = new GenericRepository<Item>(context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItem()
        {
            var items = await _itemRepository.Get();

            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _itemRepository.GetById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            await _itemRepository.Update(item);

            try
            {
                await _itemRepository.Save();
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


        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            await _itemRepository.Insert(item);
            await _itemRepository.Save();

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _itemRepository.Delete(id);
            await _itemRepository.Save();

            return NoContent();
        }

        private async Task<bool> ItemExists(int id)
        {
            return await _itemRepository.Exists(id);
        }
    }
}
