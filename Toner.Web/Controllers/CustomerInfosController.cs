using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Toner.Domain.Entities;

namespace Toner.Web.Controllers
{
   public class CustomerInfosController : Controller
   {
      #region start-index
      [HttpGet]
      public async Task<IActionResult> Index()
      {
         var customer = await GetAllCustomer();
         return View(customer);
      }

      private async Task<List<CustomerInfo?>> GetAllCustomer()
      {
         using var client = new HttpClient();
         var response = await client.GetAsync($"http://localhost:5133/api/CustomerInfoes/AllCustomer");
         if (!response.IsSuccessStatusCode)
         {
            return new List<CustomerInfo>();
         }
         string result = await response.Content.ReadAsStringAsync();
         var customer = JsonConvert.DeserializeObject<List<CustomerInfo>>(result);
         return customer ?? new List<CustomerInfo>();
      }
      #endregion end-index

      #region start-Create
      [HttpGet]
      public IActionResult Create()
      {
         var customer = new CustomerInfo();

         return View(customer);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create(CustomerInfo model)
      {
         CustomerInfo customer = new CustomerInfo
         {
            CustomerId = model.CustomerId,
            CustomerName = model.CustomerName,
            ContactNumber = model.ContactNumber,
            Address = model.Address,
            DateCreated = DateTime.Now
         };
         var CreateCustomerAdded = await CreateCustomer(customer);

         if (CreateCustomerAdded == null)
         {
            return View(customer);
         }
         return RedirectToAction("Index", "CustomerInfos");
      }

      private async Task<CustomerInfo> CreateCustomer(CustomerInfo customerInfo)
      {
         var data = JsonConvert.SerializeObject(customerInfo);
         using var client = new HttpClient();
         var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PostAsync($"http://localhost:5133/api/CustomerInfoes/InsertCustomer", httpContent);

         if (!response.IsSuccessStatusCode)
         {
            return null;
         }

         string result = await response.Content.ReadAsStringAsync();
         return JsonConvert.DeserializeObject<CustomerInfo>(result);
      }
      #endregion end-create



      #region start-edit
      public async Task<IActionResult> Edit(int customerId)
      {
         var customerInfoById = await GetById(customerId);

         if (customerInfoById == null)
            return RedirectToAction("Index");

         return View(customerInfoById);
      }


      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(CustomerInfo customerInfo)
      {
         CustomerInfo customer = new CustomerInfo
         {
            CustomerId = customerInfo.CustomerId,
            CustomerName = customerInfo.CustomerName,
            ContactNumber = customerInfo.ContactNumber,
            Address = customerInfo.Address,
            DateModified = customerInfo.DateModified
         };
         var CustomerUpdated = await UpdateCategory(customer);
         if (CustomerUpdated == null)
            return View(customer);
         return RedirectToAction("Index", customer);
      }

      private async Task<CustomerInfo> UpdateCategory(CustomerInfo customerInfo)
      {
         var data = JsonConvert.SerializeObject(customerInfo);
         using var client = new HttpClient();
         var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PostAsync($"http://localhost:5133/api/CustomerInfoes/EditCustomer", httpContent);

         if (!response.IsSuccessStatusCode)
            return null;

         string result = await response.Content.ReadAsStringAsync();
         return JsonConvert.DeserializeObject<CustomerInfo>(result);
      }
      #endregion end-edit

      #region start-Details
      public async Task<IActionResult> Details(int customerId)
      {
         var customerInfoById = await GetById(customerId);

         if (customerInfoById == null)
            return RedirectToAction("Index");

         return View(customerInfoById);
      }
      #endregion end-Details


      //#region Start-Category-Delete
      //[HttpGet]
      //public async Task<IActionResult> Delete(int customerId)
      //{
      //   var customer = new CustomerInfo();
      //   using (var client = new HttpClient())
      //   {
      //      var response = await client.GetAsync("http://localhost:5133/api/CustomerInfos/DeleteCustomerInfos/{customerId}");
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
      //      var response = await client.PostAsync("http://localhost:5120/api/Categories/DeleteCategory", httpContent);

      //      string result = response.Content.ReadAsStringAsync().Result;
      //   }
      //   return RedirectToAction("Index", customer);
      //}
      //#endregion End-Category-Delete



      private async Task<CustomerInfo?> GetById(int customerId)
      {
         var customerInfo = new CustomerInfo();
         using var client = new HttpClient();
         var response = await client.GetAsync($"http://localhost:5133/api/CustomerInfoes/GetCustomerById/{customerId}");
         if (!response.IsSuccessStatusCode)
         {
            return null;
         }
         string result = await response.Content.ReadAsStringAsync();
         customerInfo = JsonConvert.DeserializeObject<CustomerInfo>(result);

         return customerInfo;
      }



   }
}
