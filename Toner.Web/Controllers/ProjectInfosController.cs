using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Toner.Domain.Entities;

namespace Toner.Web.Controllers
{
   public class ProjectInfosController : Controller
   {
      #region start-index
      [HttpGet]
      public async Task<IActionResult> Index()
      {
         var projectInfos = await GetAllProjectInfos();
         return View(projectInfos);
      }

      private async Task<List<ProjectInfo?>> GetAllProjectInfos()
      {
         using var client = new HttpClient();
         var response = await client.GetAsync($"http://localhost:5133/api/ProjectInfos/AllProject");
         if (!response.IsSuccessStatusCode)
         {
            return new List<ProjectInfo>();
         }
         string result = await response.Content.ReadAsStringAsync();
         var project = JsonConvert.DeserializeObject<List<ProjectInfo>>(result);
         return project ?? new List<ProjectInfo>();
      }
      #endregion end-index

      #region start-Create
      [HttpGet]
      public IActionResult Create()
      {
         var project = new ProjectInfo();

         return View(project);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create(ProjectInfo model)
      {
         ProjectInfo project = new ProjectInfo
         {
            ProjectId = model.ProjectId,
            ProjectName = model.ProjectName,
            ContactNumber = model.ContactNumber,
            Address = model.Address,
            CustomerId = model.CustomerId,
            DateCreated = DateTime.Now
         };
         var projectAdded = await CreateProject(project);

         if (projectAdded == null)
         {
            return View(project);
         }
         return RedirectToAction("Index", "ProjectInfos");
      }

      private async Task<ProjectInfo> CreateProject(ProjectInfo project)
      {
         var data = JsonConvert.SerializeObject(project);
         using var client = new HttpClient();
         var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PostAsync($"http://localhost:5133/api/ProjectInfos/InsertProject", httpContent);

         if (!response.IsSuccessStatusCode)
         {
            return null;
         }

         string result = await response.Content.ReadAsStringAsync();
         return JsonConvert.DeserializeObject<ProjectInfo>(result);
      }
      #endregion end-create



      #region start-edit
      public async Task<IActionResult> Edit(int projectId)
      {
         var projectInfoById = await GetById(projectId);

         if (projectInfoById == null)
            return RedirectToAction("Index");

         return View(projectInfoById);
      }


      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(ProjectInfo model)
      {
         ProjectInfo project = new ProjectInfo
         {
            ProjectId = model.ProjectId,
            ProjectName = model.ProjectName,
            ContactNumber = model.ContactNumber,
            Address = model.Address,
            CustomerId = model.CustomerId,
            DateModified = DateTime.Now
         };
         var projectUpdated = await UpdateProject(project);
         if (projectUpdated == null)
            return View(project);
         return RedirectToAction("Index", project);
      }

      private async Task<ProjectInfo> UpdateProject(ProjectInfo projectInfo)
      {
         var data = JsonConvert.SerializeObject(projectInfo);
         using var client = new HttpClient();
         var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PostAsync($"http://localhost:5133/api/ProjectInfos/EditProject", httpContent);

         if (!response.IsSuccessStatusCode)
            return null;

         string result = await response.Content.ReadAsStringAsync();
         return JsonConvert.DeserializeObject<ProjectInfo>(result);
      }
      #endregion end-edit

      #region start-Details
      public async Task<IActionResult> Details(int projectId)
      {
         var projectInfoById = await GetById(projectId);

         if (projectInfoById == null)
            return RedirectToAction("Index");

         return View(projectInfoById);
      }
      #endregion end-Details


      //#region Start-Category-Delete
      //[HttpGet]
      //public async Task<IActionResult> Delete(int customerId)
      //{
      //   var customer = new CustomerInfo();
      //   using (var client = new HttpClient())
      //   {
      //      var response = await client.GetAsync("http://localhost:5133/api/ProjectInfos/DeleteCustomerInfos/{customerId}");
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
      //      var response = await client.PostAsync("http://localhost:5120/api/ProjectInfos/DeleteCategory", httpContent);

      //      string result = response.Content.ReadAsStringAsync().Result;
      //   }
      //   return RedirectToAction("Index", customer);
      //}
      //#endregion End-Category-Delete



      private async Task<ProjectInfo?> GetById(int projectId)
      {
         var projectInfo = new ProjectInfo();
         using var client = new HttpClient();
         var response = await client.GetAsync($"http://localhost:5133/api/ProjectInfos/GetProjectById/{projectId}");
         if (!response.IsSuccessStatusCode)
         {
            return null;
         }
         string result = await response.Content.ReadAsStringAsync();
         projectInfo = JsonConvert.DeserializeObject<ProjectInfo>(result);

         return projectInfo;
      }


   }
}
