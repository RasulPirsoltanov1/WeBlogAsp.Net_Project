using BlogSite.Api.Context.Entites;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogSite.Demo.Controllers
{
    public class ApiTestController : Controller
    {
        public async Task<IActionResult> Index()
        {

            try
            {
                var httpClient = new HttpClient();
                var apiResponse = await httpClient.GetAsync("https://localhost:7283/api/Employee");
                var jsonString = await apiResponse.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Employee>>(jsonString);
                return View(values);
            }
            catch (Exception ex)
            {
                return Content("Error this the server is closed "+ex.Message);
            }
        
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Employee employee)
        {
            var httpClient = new HttpClient();
            var apiResponse = await httpClient.PostAsJsonAsync<Employee>("https://localhost:7283/api/Employee",employee);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var httpClient = new HttpClient();
            var apiResponse = await httpClient.DeleteAsync("https://localhost:7283/api/Employee/"+Id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var httpClient = new HttpClient();
            var response =await httpClient.GetAsync("https://localhost:7283/api/Employee/" + Id);
                var content=await response.Content.ReadAsStringAsync();
                var resObject = JsonConvert.DeserializeObject<Employee>(content);
                return View(resObject);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            var httpClient = new HttpClient();
            var stringData=JsonConvert.SerializeObject(employee);
            StringContent stringContent = new StringContent(stringData);
            var response = await httpClient.PutAsJsonAsync("https://localhost:7283/api/Employee",employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
