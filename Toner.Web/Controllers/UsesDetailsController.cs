using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toner.Domain.Entities;

namespace Toner.Web.Controllers
{
   public class UsesDetailsController : Controller
   {

      #region start-index
      [HttpGet]
      public async Task<IActionResult> Index()
      {
         var usesDetails = await GetAllUsesDetails();
         return View(usesDetails);
      }

      private async Task<List<UsesDetail?>> GetAllUsesDetails()
      {
         using var client = new HttpClient();
         var response = await client.GetAsync($"http://localhost:5133/api/UsesDetails/AllUsesDetail");
         if (!response.IsSuccessStatusCode)
         {
            return new List<UsesDetail>();
         }
         string result = await response.Content.ReadAsStringAsync();
         var usesDetail = JsonConvert.DeserializeObject<List<UsesDetail>>(result);
         return usesDetail ?? new List<UsesDetail>();
      }
      #endregion end-index

      #region start-Create
      [HttpGet]
      public IActionResult Create()
      {
         var usesDetail = new UsesDetail();

         return View(usesDetail);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create(UsesDetail model)
      {
         UsesDetail usesDetail = new UsesDetail
         {
            UsesDetailId = model.UsesDetailId,
            PrevCount = model.PrevCount,
            CurCount = model.CurCount,
            TotalCount = model.TotalCount,
            TonerPercentage = model.TonerPercentage,
            DateCreated = DateTime.Now
         };
         var usesDetailAdded = await CreateUsesDetail(usesDetail);

         if (usesDetailAdded == null)
         {
            return View(usesDetail);
         }
         return RedirectToAction("Index", "UsesDetails");
      }

      private async Task<UsesDetail> CreateUsesDetail(UsesDetail usesDetail)
      {
         var data = JsonConvert.SerializeObject(usesDetail);
         using var client = new HttpClient();
         var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PostAsync($"http://localhost:5133/api/UsesDetails/InsertUsesDetail", httpContent);

         if (!response.IsSuccessStatusCode)
         {
            return null;
         }

         string result = await response.Content.ReadAsStringAsync();
         return JsonConvert.DeserializeObject<UsesDetail>(result);
      }
      #endregion end-create



      #region start-edit
      public async Task<IActionResult> Edit(int usesDetailId)
      {
         var usesDetailById = await GetById(usesDetailId);

         if (usesDetailById == null)
            return RedirectToAction("Index");

         return View(usesDetailById);
      }


      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(UsesDetail model)
      {
         UsesDetail usesDetail = new UsesDetail
         {
            UsesDetailId = model.UsesDetailId,
            PrevCount = model.PrevCount,
            CurCount = model.CurCount,
            TotalCount = model.TotalCount,
            TonerPercentage = model.TonerPercentage,
            DateModified = DateTime.Now
         };
         var usesDetailUpdated = await UpdateUsesDetail(usesDetail);
         if (usesDetailUpdated == null)
            return View(usesDetail);
         return RedirectToAction("Index", usesDetail);
      }

      private async Task<UsesDetail> UpdateUsesDetail(UsesDetail usesDetailInfo)
      {
         var data = JsonConvert.SerializeObject(usesDetailInfo);
         using var client = new HttpClient();
         var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PostAsync($"http://localhost:5133/api/UsesDetails/EditUsesDetail", httpContent);

         if (!response.IsSuccessStatusCode)
            return null;

         string result = await response.Content.ReadAsStringAsync();
         return JsonConvert.DeserializeObject<UsesDetail>(result);
      }
      #endregion end-edit

      #region start-Details
      public async Task<IActionResult> Details(int usesDetailId)
      {
         var usesDetailById = await GetById(usesDetailId);

         if (usesDetailById == null)
            return RedirectToAction("Index");

         return View(usesDetailById);
      }
      #endregion end-Details


      //#region Start-Category-Delete
      //[HttpGet]
      //public async Task<IActionResult> Delete(int customerId)
      //{
      //   var customer = new CustomerInfo();
      //   using (var client = new HttpClient())
      //   {
      //      var response = await client.GetAsync("http://localhost:5133/api/UsesDetails/DeleteCustomerInfos/{customerId}");
      //      string result = response.Content.ReadAsStringAsync().Result;
      //      customer = JsonConvert.DeserializeObject<CustomerInfo>(result);
      //   }
      //   return View(customer);
      //}

      ////[HttpPost("DeleteConfirm")]
      //[HttpPost]
      //public async Task<IActionResult> Delete(CustomerInfo customer)
      //{
      //   var categoryJson = JsonConvert.SerializeObject(customer);
      //   using (var client = new HttpClient())
      //   {
      //      HttpContent httpContent = new StringContent(categoryJson, Encoding.UTF8, "application/json");
      //      var response = await client.PostAsync("http://localhost:5120/api/UsesDetails/DeleteCategory", httpContent);

      //      string result = response.Content.ReadAsStringAsync().Result;
      //   }
      //   return RedirectToAction("Index", customer);
      //}
      //#endregion End-Category-Delete



      private async Task<UsesDetail?> GetById(int usesDetailId)
      {
         var usesDetailInfo = new UsesDetail();
         using var client = new HttpClient();
         var response = await client.GetAsync($"http://localhost:5133/api/UsesDetails/GetUsesDetailById/{usesDetailId}");
         if (!response.IsSuccessStatusCode)
         {
            return null;
         }
         string result = await response.Content.ReadAsStringAsync();
         usesDetailInfo = JsonConvert.DeserializeObject<UsesDetail>(result);

         return usesDetailInfo;
      }

   }
}

