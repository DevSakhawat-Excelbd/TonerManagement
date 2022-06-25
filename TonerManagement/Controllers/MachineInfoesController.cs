using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Toner.Domain.Entities;
using TonerManagement.Data;

namespace TonerManagement.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class MachineInfoesController : ControllerBase
   {
      private readonly DataContext _context;

      public MachineInfoesController(DataContext context)
      {
         _context = context;
      }

      [HttpGet]
      [Route("AllMachine")]
      public async Task<ActionResult<IEnumerable<MachineInfo>>> GetMachineInfos()
      {
         if (_context.MachineInfos == null)
         {
            return NotFound();
         }
         //var AllDetails = _context.CustomerInfos.Include("MachineInfo").Include("TonerInfo").ToListAsync();

         //var AllDetails = _context.CustomerInfos.Include(m => m.MachineInfo);
         //return await AllDetails.ToListAsync();
         return await _context.MachineInfos.ToListAsync();
      }

      [HttpGet]
      [Route("GetMachineById/{id}")]
      public async Task<ActionResult<MachineInfo>> GetMachineInfosById(int id)
      {
         if (_context.MachineInfos == null)
         {
            return NotFound();
         }
         var machineInfo = await _context.MachineInfos.FindAsync(id);

         if (machineInfo == null)
         {
            return NotFound();
         }

         return machineInfo;
      }


      [HttpPost]
      [Route("EditMachine")]
      public async Task<IActionResult> EditMachineInfos(MachineInfo machineInfo)
      {

         if (_context.MachineInfos == null)
         {
            return Problem("Entity set 'DataContext.CustomerInfos'  is null.");
         }

         _context.Entry(machineInfo).State = EntityState.Modified;

         try
         {
            await _context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException)
         {
            throw;
         }

         return CreatedAtAction("GetMachineInfos", new { id = machineInfo.MachineId }, machineInfo);
      }

      [HttpPost]
      [Route("InsertMachine")]
      public async Task<ActionResult<MachineInfo>> AddMachineInfos(MachineInfo machineInfo)
      {
         if (_context.MachineInfos == null)
         {
            return Problem("Entity set 'DataContext.CustomerInfos'  is null.");
         }
         _context.MachineInfos.Add(machineInfo);
         await _context.SaveChangesAsync();

         return CreatedAtAction("GetMachineInfos", new { id = machineInfo.MachineId }, machineInfo);
      }

      [HttpPost]
      [Route("DeleteMachine/{id}")]
      public async Task<IActionResult> DeleteMachineInfos(int id)
      {
         if (_context.MachineInfos == null)
         {
            return NotFound();
         }
         var machineInfo = await _context.MachineInfos.FindAsync(id);
         if (machineInfo == null)
         {
            return NotFound();
         }

         _context.MachineInfos.Remove(machineInfo);
         await _context.SaveChangesAsync();

         return NoContent();
      }

      private bool CustomerInfoExists(int id)
      {
         return (_context.ProjectInfos?.Any(e => e.ProjectId == id)).GetValueOrDefault();
      }
   }
}
