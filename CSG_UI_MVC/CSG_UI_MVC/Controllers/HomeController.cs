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


        public ActionResult create()
        {
            return View();
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
        
        public ActionResult Edit(string  id)
        {
            Status data = new Status();

            using (var client = new HttpClient())
            {

                var responseTask = client.GetAsync("https://localhost:44391/api/Employee/GetEmployeeId?id=" +id.ToString());
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


        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<Status> Edit(Status task)
        {
            string BaseUrl = " https://localhost:44391/api/employee/editemployee";
            var content = JsonConvert.SerializeObject(task);
            using (var client = new HttpClient())
            {
                var httpResponse = await client.PutAsync($"{BaseUrl}{task.Id}", new StringContent(content, Encoding.Default, "application/json"));

                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot update todo task");
                }


                var createdTask = JsonConvert.DeserializeObject<Status>(await httpResponse.Content.ReadAsStringAsync());
                return createdTask;
            }
        }


        public ActionResult Delete(string id)
        {
            Status data = new Status();

            using (var client = new HttpClient())
            {

                var responseTask = client.GetAsync("https://localhost:44391/api/Employee/GetEmployeeId?id=" + id.ToString());
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

        public ActionResult Details(string id)
        {
            Status data = new Status();

            using (var client = new HttpClient())
            {

                var responseTask = client.GetAsync("https://localhost:44391/api/Employee/GetEmployeeId?id=" + id.ToString());
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
