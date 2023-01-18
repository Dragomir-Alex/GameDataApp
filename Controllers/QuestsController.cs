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
    public class QuestsController : ControllerBase
    {
        private readonly GenericRepository<Quest> _questRepository;

        public QuestsController(GameDataAppContext context)
        {
            _questRepository = new GenericRepository<Quest>(context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quest>>> GetQuest()
        {
            var quests = await _questRepository.Get();

            if (quests == null)
            {
                return NotFound();
            }
            return Ok(quests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Quest>> GetQuest(int id)
        {
            var quest = await _questRepository.GetById(id);

            if (quest == null)
            {
                return NotFound();
            }

            return Ok(quest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuest(int id, Quest quest)
        {
            if (id != quest.Id)
            {
                return BadRequest();
            }

            await _questRepository.Update(quest);

            try
            {
                await _questRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await QuestExists(id))
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
        public async Task<ActionResult<Quest>> PostQuest(Quest quest)
        {
            await _questRepository.Insert(quest);
            await _questRepository.Save();

            return CreatedAtAction("GetQuest", new { id = quest.Id }, quest);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuest(int id)
        {
            await _questRepository.Delete(id);
            await _questRepository.Save();

            return NoContent();
        }

        private async Task<bool> QuestExists(int id)
        {
            return await _questRepository.Exists(id);
        }
    }
}
