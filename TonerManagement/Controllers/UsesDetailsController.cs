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
   public class UsesDetailsController : ControllerBase
   {
      private readonly DataContext _context;

      public UsesDetailsController(DataContext context)
      {
         _context = context;
      }

      [HttpGet]
      [Route("AllUsesDetail")]
      public async Task<ActionResult<IEnumerable<UsesDetail>>> GetUsesDetails()
      {
         if (_context.UsesDetails == null)
         {
            return NotFound();
         }
         //var AllDetails = _context.CustomerInfos.Include("UsesDetail").Include("TonerInfo").ToListAsync();

         //var AllDetails = _context.CustomerInfos.Include(m => m.UsesDetail);
         //return await AllDetails.ToListAsync();
         return await _context.UsesDetails.ToListAsync();
      }

      [HttpGet]
      [Route("GetUsesDetailById/{id}")]
      public async Task<ActionResult<UsesDetail>> GetUsesDetailsById(int id)
      {
         if (_context.UsesDetails == null)
         {
            return NotFound();
         }
         var usesDetail = await _context.UsesDetails.FindAsync(id);

         if (usesDetail == null)
         {
            return NotFound();
         }

         return usesDetail;
      }


      [HttpPost]
      [Route("EditUsesDetail")]
      public async Task<IActionResult> EditUsesDetails(UsesDetail usesDetail)
      {

         if (_context.UsesDetails == null)
         {
            return Problem("Entity set 'DataContext.CustomerInfos'  is null.");
         }

         _context.Entry(usesDetail).State = EntityState.Modified;

         try
         {
            await _context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException)
         {
            throw;
         }

         return CreatedAtAction("GetUsesDetails", new { id = usesDetail.UsesDetailId }, usesDetail);
      }

      [HttpPost]
      [Route("InsertUsesDetail")]
      public async Task<ActionResult<UsesDetail>> AddUsesDetails(UsesDetail usesDetail)
      {
         if (_context.UsesDetails == null)
         {
            return Problem("Entity set 'DataContext.CustomerInfos'  is null.");
         }
         _context.UsesDetails.Add(usesDetail);
         await _context.SaveChangesAsync();

         return CreatedAtAction("GetUsesDetails", new { id = usesDetail.UsesDetailId }, usesDetail);
      }

      [HttpPost]
      [Route("DeleteUsesDetail/{id}")]
      public async Task<IActionResult> DeleteUsesDetails(int id)
      {
         if (_context.UsesDetails == null)
         {
            return NotFound();
         }
         var usesDetail = await _context.UsesDetails.FindAsync(id);
         if (usesDetail == null)
         {
            return NotFound();
         }

         _context.UsesDetails.Remove(usesDetail);
         await _context.SaveChangesAsync();

         return NoContent();
      }

      private bool UsesDetailExists(int id)
      {
         return (_context.UsesDetails?.Any(e => e.UsesDetailId == id)).GetValueOrDefault();
      }
   }
}
