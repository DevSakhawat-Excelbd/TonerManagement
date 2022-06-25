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
   public class CustomerInfoesController : ControllerBase
   {
      private readonly DataContext _context;

      public CustomerInfoesController(DataContext context)
      {
         _context = context;
      }

      [HttpGet]
      [Route("AllCustomer")]
      public async Task<ActionResult<IEnumerable<CustomerInfo>>> GetCustomerInfos()
      {
         if (_context.CustomerInfos == null)
         {
            return NotFound();
         }
         //var AllDetails = _context.CustomerInfos.Include("MachineInfo").Include("TonerInfo").ToListAsync();

         //var AllDetails = _context.CustomerInfos.Include(m => m.MachineInfo);
         //return await AllDetails.ToListAsync();
         return await _context.CustomerInfos.ToListAsync();
      }

      [HttpGet]
      [Route("GetCustomerById/{id}")]
      public async Task<ActionResult<CustomerInfo>> GetCustomerInfosById(int id)
      {
         if (_context.CustomerInfos == null)
         {
            return NotFound();
         }
         var customerInfo = await _context.CustomerInfos.FindAsync(id);

         if (customerInfo == null)
         {
            return NotFound();
         }

         return customerInfo;
      }


      [HttpPost]
      [Route("EditCustomer")]
      public async Task<IActionResult> EditCustomerInfos(CustomerInfo customerInfo)
      {

         if (_context.CustomerInfos == null)
         {
            return Problem("Entity set 'DataContext.CustomerInfos'  is null.");
         }

         _context.Entry(customerInfo).State = EntityState.Modified;

         try
         {
            await _context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException)
         {
            throw;
         }

         return CreatedAtAction("GetCustomerInfos", new { id = customerInfo.CustomerId }, customerInfo);
      }




      [HttpPost]
      [Route("InsertCustomer")]
      public async Task<ActionResult<CustomerInfo>> AddCustomerInfos(CustomerInfo customerInfo)
      {
         if (_context.CustomerInfos == null)
         {
            return Problem("Entity set 'DataContext.CustomerInfos'  is null.");
         }
         _context.CustomerInfos.Add(customerInfo);
         await _context.SaveChangesAsync();

         return CreatedAtAction("GetCustomerInfos", new { id = customerInfo.CustomerId }, customerInfo);
      }


      //[HttpDelete]
      [HttpPost]
      [Route("DeleteCustomer/{id}")]
      public async Task<IActionResult> DeleteCustomerInfos(int id)
      {
         if (_context.CustomerInfos == null)
         {
            return NotFound();
         }
         var customerInfo = await _context.CustomerInfos.FindAsync(id);
         if (customerInfo == null)
         {
            return NotFound();
         }

         _context.CustomerInfos.Remove(customerInfo);
         await _context.SaveChangesAsync();

         return NoContent();
      }


    
      private bool CustomerInfoExists(int id)
      {
         return (_context.CustomerInfos?.Any(e => e.CustomerId == id)).GetValueOrDefault();
      }
   }
}
