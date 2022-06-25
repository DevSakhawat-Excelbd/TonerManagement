using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Toner.Domain.Entities;
using TonerManagement.Data;

namespace TonerManagement.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ProjectInfosController : ControllerBase
   {
      private readonly DataContext _context;

      public ProjectInfosController(DataContext context)
      {
         _context = context;
      }

      [HttpGet]
      [Route("AllProject")]
      public async Task<ActionResult<IEnumerable<ProjectInfo>>> GetProjectInfos()
      {
         if (_context.ProjectInfos == null)
         {
            return NotFound();
         }
         //var AllDetails = _context.CustomerInfos.Include("MachineInfo").Include("TonerInfo").ToListAsync();

         //var AllDetails = _context.CustomerInfos.Include(m => m.MachineInfo);
         //return await AllDetails.ToListAsync();
         return await _context.ProjectInfos.ToListAsync();
      }

      [HttpGet]
      [Route("GetProjectById/{id}")]
      public async Task<ActionResult<ProjectInfo>> GetProjectInfosById(int id)
      {
         if (_context.ProjectInfos == null)
         {
            return NotFound();
         }
         var projectInfo = await _context.ProjectInfos.FindAsync(id);

         if (projectInfo == null)
         {
            return NotFound();
         }

         return projectInfo;
      }


      [HttpPost]
      [Route("EditProject")]
      public async Task<IActionResult> EditProjectInfos(ProjectInfo projectInfo)
      {

         if (_context.ProjectInfos == null)
         {
            return Problem("Entity set 'DataContext.CustomerInfos'  is null.");
         }

         _context.Entry(projectInfo).State = EntityState.Modified;

         try
         {
            await _context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException)
         {
            throw;
         }

         return CreatedAtAction("GetProjectInfos", new { id = projectInfo.ProjectId }, projectInfo);
      }

      [HttpPost]
      [Route("InsertProject")]
      public async Task<ActionResult<ProjectInfo>> AddProjectInfos(ProjectInfo projectInfo)
      {
         if (_context.ProjectInfos == null)
         {
            return Problem("Entity set 'DataContext.CustomerInfos'  is null.");
         }
         _context.ProjectInfos.Add(projectInfo);
         await _context.SaveChangesAsync();

         return CreatedAtAction("GetProjectInfos", new { id = projectInfo.ProjectId }, projectInfo);
      }

      [HttpPost]
      [Route("DeleteProject/{id}")]
      public async Task<IActionResult> DeleteProjectInfos(int id)
      {
         if (_context.ProjectInfos == null)
         {
            return NotFound();
         }
         var projectInfo = await _context.ProjectInfos.FindAsync(id);
         if (projectInfo == null)
         {
            return NotFound();
         }

         _context.ProjectInfos.Remove(projectInfo);
         await _context.SaveChangesAsync();

         return NoContent();
      }

      private bool CustomerInfoExists(int id)
      {
         return (_context.ProjectInfos?.Any(e => e.ProjectId == id)).GetValueOrDefault();
      }
   }
}
