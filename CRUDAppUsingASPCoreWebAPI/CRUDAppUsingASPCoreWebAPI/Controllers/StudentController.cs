using CRUDAppUsingASPCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;

namespace CRUDAppUsingASPCoreWebAPI.Controllers
{
    public class StudentController : Controller
    {
        private string url = "https://localhost:7244/api/StudentAPI/";
        private HttpClient client = new HttpClient();

        // all data show 
        [HttpGet] 
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var Data = JsonConvert.DeserializeObject<List<Student>>(result);
                if (Data != null)
                {
                    students = Data;
                }
            }
            return View(students);
        }
        // create a new data 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student Std)
        {
            String data = JsonConvert.SerializeObject(Std);
            StringContent content = new StringContent(data, Encoding.UTF8, "Application/Json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["insert_Message"] = "Student Added...";
                return RedirectToAction("Index");
            }
            return View();
        }

        // Edit valid data using id
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var Data = JsonConvert.DeserializeObject<Student>(result);
                if (Data != null)
                {
                    std = Data;
                }
            }
            return View(std);
        }
        [HttpPost]
        public IActionResult Edit(Student Std)
        {
            String data = JsonConvert.SerializeObject(Std);
            StringContent content = new StringContent(data, Encoding.UTF8, "Application/Json");
            HttpResponseMessage response = client.PutAsync(url + "?ID=" + Std.id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["insert_Message"] = "Student Edits...";
                return RedirectToAction("Index");
            }
            return View(Std);
        }

        // show particular data using detail
        [HttpGet]
        public IActionResult Detail(int id)
        {
            Student Std = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {

                string result = response.Content.ReadAsStringAsync().Result;
                var Data = JsonConvert.DeserializeObject<Student>(result);
                if (Data != null)
                {
                    Std = Data;
                }
            }
            return View(Std);
        }

        // delete id data 
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student Std = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {

                string result = response.Content.ReadAsStringAsync().Result;
                var Data = JsonConvert.DeserializeObject<Student>(result);
                if (Data != null)
                {
                    Std = Data;
                }
            }
            return View(Std);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConformed(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Delete_Message"] = "Student Deleted...";
                return RedirectToAction("Index");
            }
            return View();
        }

        // delete all data 
        [HttpPost]
        public IActionResult DeleteAll()
        {
            HttpResponseMessage response = client.DeleteAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Delete_Message"] = "All records deleted successfully.";
            }
            else
            {
                TempData["Delete_Error"] = "An error occurred while deleting records.";
            }
            return RedirectToAction(nameof(Index));
        }

        // using search bar find data 
        [HttpGet]
        public IActionResult Find(int id)
        {
            Student Std = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {

                string result = response.Content.ReadAsStringAsync().Result;
                var Data = JsonConvert.DeserializeObject<Student>(result);
                if (Data != null)
                {
                    Std = Data;
                }
            }
            return View(Std);
        }
      

    }
}
