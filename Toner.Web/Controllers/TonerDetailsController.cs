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
   public class TonerDetailsController : Controller
   {

      #region start-index
      [HttpGet]
      public async Task<IActionResult> Index()
      {
         var tonerDetails = await GetAllTonerDetails();
         return View(tonerDetails);
      }

      private async Task<List<TonerDetail?>> GetAllTonerDetails()
      {
         using var client = new HttpClient();
         var response = await client.GetAsync($"http://localhost:5133/api/TonerDetails/AllTonerDetail");
         if (!response.IsSuccessStatusCode)
         {
            return new List<TonerDetail>();
         }
         string result = await response.Content.ReadAsStringAsync();
         var tonerDetail = JsonConvert.DeserializeObject<List<TonerDetail>>(result);
         return tonerDetail ?? new List<TonerDetail>();
      }
      #endregion end-index

      #region start-Create
      [HttpGet]
      public IActionResult Create()
      {
         var tonerDetail = new TonerDetail();

         return View(tonerDetail);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create(TonerDetail model)
      {
         TonerDetail tonerDetail = new TonerDetail
         {
            TotalMachineToner = model.TotalMachineToner,
            CurrentTonerStock = model.CurrentTonerStock,
            InHouseTotalToner = model.InHouseTotalToner,
            LastMonthTotalTonerStock = model.LastMonthTotalTonerStock,
            MonthlyDeliveryToner = model.MonthlyDeliveryToner,
            TotalTonerStock = model.TotalTonerStock,
            MonthlyUsedToner = model.MonthlyUsedToner,
            DateCreated = DateTime.Now
         };
         var tonerDetailAdded = await CreateTonerDetail(tonerDetail);

         if (tonerDetailAdded == null)
         {
            return View(tonerDetail);
         }
         return RedirectToAction("Index", "TonerDetails");
      }

      private async Task<TonerDetail> CreateTonerDetail(TonerDetail tonerDetail)
      {
         var data = JsonConvert.SerializeObject(tonerDetail);
         using var client = new HttpClient();
         var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PostAsync($"http://localhost:5133/api/TonerDetails/InsertTonerDetail", httpContent);

         if (!response.IsSuccessStatusCode)
         {
            return null;
         }

         string result = await response.Content.ReadAsStringAsync();
         return JsonConvert.DeserializeObject<TonerDetail>(result);
      }
      #endregion end-create



      #region start-edit
      public async Task<IActionResult> Edit(int tonerDetailId)
      {
         var tonerDetailById = await GetById(tonerDetailId);

         if (tonerDetailById == null)
            return RedirectToAction("Index");

         return View(tonerDetailById);
      }


      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(TonerDetail model)
      {
         TonerDetail tonerDetail = new TonerDetail
         {
            TonerDetailId = model.TonerDetailId,
            TotalMachineToner = model.TotalMachineToner,
            CurrentTonerStock = model.CurrentTonerStock,
            InHouseTotalToner = model.InHouseTotalToner,
            LastMonthTotalTonerStock = model.LastMonthTotalTonerStock,
            MonthlyDeliveryToner = model.MonthlyDeliveryToner,
            TotalTonerStock = model.TotalTonerStock,
            MonthlyUsedToner = model.MonthlyUsedToner,
            DateModified = DateTime.Now
         };
         var tonerDetailUpdated = await UpdateTonerDetail(tonerDetail);
         if (tonerDetailUpdated == null)
            return View(tonerDetail);
         return RedirectToAction("Index", tonerDetail);
      }

      private async Task<TonerDetail> UpdateTonerDetail(TonerDetail tonerDetailInfo)
      {
         var data = JsonConvert.SerializeObject(tonerDetailInfo);
         using var client = new HttpClient();
         var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PostAsync($"http://localhost:5133/api/TonerDetails/EditTonerDetail", httpContent);

         if (!response.IsSuccessStatusCode)
            return null;

         string result = await response.Content.ReadAsStringAsync();
         return JsonConvert.DeserializeObject<TonerDetail>(result);
      }
      #endregion end-edit

      #region start-Details
      public async Task<IActionResult> Details(int tonerDetailId)
      {
         var tonerDetailById = await GetById(tonerDetailId);

         if (tonerDetailById == null)
            return RedirectToAction("Index");

         return View(tonerDetailById);
      }
      #endregion end-Details


      //#region Start-Category-Delete
      //[HttpGet]
      //public async Task<IActionResult> Delete(int customerId)
      //{
      //   var customer = new CustomerInfo();
      //   using (var client = new HttpClient())
      //   {
      //      var response = await client.GetAsync("http://localhost:5133/api/TonerDetails/DeleteCustomerInfos/{customerId}");
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
      //      var response = await client.PostAsync("http://localhost:5120/api/TonerDetails/DeleteCategory", httpContent);

      //      string result = response.Content.ReadAsStringAsync().Result;
      //   }
      //   return RedirectToAction("Index", customer);
      //}
      //#endregion End-Category-Delete



      private async Task<TonerDetail?> GetById(int tonerDetailId)
      {
         var tonerDetailInfo = new TonerDetail();
         using var client = new HttpClient();
         var response = await client.GetAsync($"http://localhost:5133/api/TonerDetails/GetTonerDetailById/{tonerDetailId}");
         if (!response.IsSuccessStatusCode)
         {
            return null;
         }
         string result = await response.Content.ReadAsStringAsync();
         tonerDetailInfo = JsonConvert.DeserializeObject<TonerDetail>(result);

         return tonerDetailInfo;
      }
   }
}
