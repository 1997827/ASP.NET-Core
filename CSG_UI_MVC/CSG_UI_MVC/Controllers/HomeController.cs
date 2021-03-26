using CSG_UI_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace CSG_UI_MVC.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            List<Status> Employees = new List<Status>();

            using (var client = new HttpClient())
            {

                var responseTask = client.GetAsync("https://localhost:44391/api/employee/getemployee");


                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    Employees = JsonConvert.DeserializeObject<List<Status>>(readTask);
                }
                else
                {
                    Employees = null;

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Employees);
        }


        [HttpPost]
        public ActionResult create(Status data)
        {
            using (var client = new HttpClient())
            {
              
                var postTask = client.PostAsJsonAsync<Status>("https://localhost:44391/api/employee/addemployee", data);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(data);
        }


        public ActionResult Edit(string id)
        {
            Status data = null;

            using (var client = new HttpClient())
            {

                var responseTask = client.GetAsync("https://localhost:44391/api/employee/editemployee?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Status>();
                    readTask.Wait();

                    data = readTask.Result;
                }
            }

            return View(data);
        }






    }
}
