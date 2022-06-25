using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Toner.Domain.Entities;
using TonerManagement.Data;

namespace TonerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonerInfoesController : ControllerBase
    {
        private readonly DataContext _context;

        public TonerInfoesController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TonerInfo>>> GetTonerInfos()
        {
          if (_context.TonerInfos == null)
          {
              return NotFound();
          }
            return await _context.TonerInfos.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TonerInfo>> GetTonerInfo(int id)
        {
          if (_context.TonerInfos == null)
          {
              return NotFound();
          }
            var tonerInfo = await _context.TonerInfos.FindAsync(id);

            if (tonerInfo == null)
            {
                return NotFound();
            }

            return tonerInfo;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTonerInfo(int id, TonerInfo tonerInfo)
        {
            if (id != tonerInfo.TonerId)
            {
                return BadRequest();
            }

            _context.Entry(tonerInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TonerInfoExists(id))
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
        public async Task<ActionResult<TonerInfo>> PostTonerInfo(TonerInfo tonerInfo)
        {
          if (_context.TonerInfos == null)
          {
              return Problem("Entity set 'DataContext.TonerInfos'  is null.");
          }
            _context.TonerInfos.Add(tonerInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTonerInfo", new { id = tonerInfo.TonerId }, tonerInfo);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTonerInfo(int id)
        {
            if (_context.TonerInfos == null)
            {
                return NotFound();
            }
            var tonerInfo = await _context.TonerInfos.FindAsync(id);
            if (tonerInfo == null)
            {
                return NotFound();
            }

            _context.TonerInfos.Remove(tonerInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TonerInfoExists(int id)
        {
            return (_context.TonerInfos?.Any(e => e.TonerId == id)).GetValueOrDefault();
        }
    }
}
