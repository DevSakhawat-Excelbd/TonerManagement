using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toner.Domain.Entities;
using TonerManagement.Data;

namespace TonerManagement.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class TonerDetailsController : ControllerBase
   {
      private readonly DataContext _context;

      public TonerDetailsController(DataContext context)
      {
         _context = context;
      }

      [HttpGet]
      [Route("AllTonerDetail")]
      public async Task<ActionResult<IEnumerable<TonerDetail>>> GetTonerDetails()
      {
         if (_context.TonerDetails == null)
         {
            return NotFound();
         }
        
         return await _context.TonerDetails.ToListAsync();
      }

      [HttpGet]
      [Route("GetTonerDetailById/{id}")]
      public async Task<ActionResult<TonerDetail>> GetTonerDetailsById(int id)
      {
         if (_context.TonerDetails == null)
         {
            return NotFound();
         }
         var tonerDetail = await _context.TonerDetails.FindAsync(id);

         if (tonerDetail == null)
         {
            return NotFound();
         }

         return tonerDetail;
      }


      [HttpPost]
      [Route("EditTonerDetail")]
      public async Task<IActionResult> EditTonerDetails(TonerDetail tonerDetail)
      {

         if (_context.TonerDetails == null)
         {
            return Problem("Entity set 'DataContext.TonerDetails'  is null.");
         }

         _context.Entry(tonerDetail).State = EntityState.Modified;

         try
         {
            await _context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException)
         {
            throw;
         }

         return CreatedAtAction("GetTonerDetails", new { id = tonerDetail.TonerDetailId }, tonerDetail);
      }

      [HttpPost]
      [Route("InsertTonerDetail")]
      public async Task<ActionResult<TonerDetail>> AddTonerDetails(TonerDetail tonerDetail)
      {
         if (_context.TonerDetails == null)
         {
            return Problem("Entity set 'DataContext.CustomerInfos'  is null.");
         }
         _context.TonerDetails.Add(tonerDetail);
         await _context.SaveChangesAsync();

         return CreatedAtAction("GetTonerDetails", new { id = tonerDetail.TonerDetailId }, tonerDetail);
      }

      [HttpPost]
      [Route("DeleteTonerDetail/{id}")]
      public async Task<IActionResult> DeleteTonerDetails(int id)
      {
         if (_context.TonerDetails == null)
         {
            return NotFound();
         }
         var tonerDetail = await _context.TonerDetails.FindAsync(id);
         if (tonerDetail == null)
         {
            return NotFound();
         }

         _context.TonerDetails.Remove(tonerDetail);
         await _context.SaveChangesAsync();

         return NoContent();
      }

      private bool TonerDetailExists(int id)
      {
         return (_context.TonerDetails?.Any(e => e.TonerDetailId == id)).GetValueOrDefault();
      }
   }
}
