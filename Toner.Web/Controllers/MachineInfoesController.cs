using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Toner.Domain.Entities;

namespace Toner.Web.Controllers
{
   public class MachineInfoesController : Controller
   {
      #region start-index
      [HttpGet]
      public async Task<IActionResult> Index()
      {
         var machineInfos = await GetAllMachineInfos();
         return View(machineInfos);
      }

      private async Task<List<MachineInfo?>> GetAllMachineInfos()
      {
         using var client = new HttpClient();
         var response = await client.GetAsync($"http://localhost:5133/api/MachineInfoes/AllMachine");
         if (!response.IsSuccessStatusCode)
         {
            return new List<MachineInfo>();
         }
         string result = await response.Content.ReadAsStringAsync();
         var machine = JsonConvert.DeserializeObject<List<MachineInfo>>(result);
         return machine ?? new List<MachineInfo>();
      }
      #endregion end-index

      #region start-Create
      [HttpGet]
      public IActionResult Create()
      {
         var machine = new MachineInfo();

         return View(machine);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create(MachineInfo model)
      {
         MachineInfo machine = new MachineInfo
         {
            MachineId = model.MachineId,
            MachineName = model.MachineName,
            MachineSI = model.MachineSI,
            ProjectInfo = model.ProjectInfo,
            DateCreated = DateTime.Now
         };
         var machineAdded = await CreateMachine(machine);

         if (machineAdded == null)
         {
            return View(machine);
         }
         return RedirectToAction("Index", "MachineInfoes");
      }

      private async Task<MachineInfo> CreateMachine(MachineInfo machine)
      {
         var data = JsonConvert.SerializeObject(machine);
         using var client = new HttpClient();
         var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PostAsync($"http://localhost:5133/api/MachineInfoes/InsertMachine", httpContent);

         if (!response.IsSuccessStatusCode)
         {
            return null;
         }

         string result = await response.Content.ReadAsStringAsync();
         return JsonConvert.DeserializeObject<MachineInfo>(result);
      }
      #endregion end-create



      #region start-edit
      public async Task<IActionResult> Edit(int machineId)
      {
         var machineInfoById = await GetById(machineId);

         if (machineInfoById == null)
            return RedirectToAction("Index");

         return View(machineInfoById);
      }


      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(MachineInfo model)
      {
         MachineInfo machine = new MachineInfo
         {
            MachineId = model.MachineId,
            MachineName = model.MachineName,
            MachineSI = model.MachineSI,
            ProjectInfo = model.ProjectInfo,
            DateModified = DateTime.Now
         };
         var machineUpdated = await UpdateMachine(machine);
         if (machineUpdated == null)
            return View(machine);
         return RedirectToAction("Index", machine);
      }

      private async Task<MachineInfo> UpdateMachine(MachineInfo machineInfo)
      {
         var data = JsonConvert.SerializeObject(machineInfo);
         using var client = new HttpClient();
         var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PostAsync($"http://localhost:5133/api/MachineInfoes/EditMachine", httpContent);

         if (!response.IsSuccessStatusCode)
            return null;

         string result = await response.Content.ReadAsStringAsync();
         return JsonConvert.DeserializeObject<MachineInfo>(result);
      }
      #endregion end-edit

      #region start-Details
      public async Task<IActionResult> Details(int machineId)
      {
         var machineInfoById = await GetById(machineId);

         if (machineInfoById == null)
            return RedirectToAction("Index");

         return View(machineInfoById);
      }
      #endregion end-Details


      //#region Start-Category-Delete
      //[HttpGet]
      //public async Task<IActionResult> Delete(int customerId)
      //{
      //   var customer = new CustomerInfo();
      //   using (var client = new HttpClient())
      //   {
      //      var response = await client.GetAsync("http://localhost:5133/api/MachineInfoes/DeleteCustomerInfos/{customerId}");
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
      //      var response = await client.PostAsync("http://localhost:5120/api/MachineInfoes/DeleteCategory", httpContent);

      //      string result = response.Content.ReadAsStringAsync().Result;
      //   }
      //   return RedirectToAction("Index", customer);
      //}
      //#endregion End-Category-Delete



      private async Task<MachineInfo?> GetById(int machineId)
      {
         var machineInfo = new MachineInfo();
         using var client = new HttpClient();
         var response = await client.GetAsync($"http://localhost:5133/api/MachineInfoes/GetmachineById/{machineId}");
         if (!response.IsSuccessStatusCode)
         {
            return null;
         }
         string result = await response.Content.ReadAsStringAsync();
         machineInfo = JsonConvert.DeserializeObject<MachineInfo>(result);

         return machineInfo;
      }

   }
}
