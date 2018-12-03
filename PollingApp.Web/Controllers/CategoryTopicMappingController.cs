using Newtonsoft.Json;
using PollingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace PollingApp.Web.Controllers
{
    public class CategoryTopicMappingController : Controller
    {
        // GET: CategoryTopicMapping
        public string Result { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //Index
        public ActionResult Index(List<CategoryTopicMapping> categorytopicmapping)
        {
            return PartialView("CategoryTopicMappingList", categorytopicmapping);
        }
        public ActionResult Details(int id)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                UriBuilder builder = new UriBuilder("http://localhost:57203/api/apitopicoptionmapping/get");
                builder.Query = "id=" + id;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(builder.Uri).Result;
                using (HttpContent content = response.Content)
                {
                    Task<string> result = content.ReadAsStringAsync();
                    Result = result.Result;
                }
            }
            string json = Result;
            var deserialized = JsonConvert.DeserializeObject<CategoryTopicMapping>(json);
            return PartialView(deserialized);
        }
        //Create Method
        /*public ActionResult Create()
        {
           // var lstTopics = GetCategoryMasters().OrderBy(o => o.CategoryId).ToList();

            ViewBag.CategoryNameList = new SelectList(lstTopics, "CategoryId", "CategoryName");
            //var lstOptions = GetOptionMasters().OrderBy(o => o.OptionName).ToList();
           // ViewBag.OptionNameList = new SelectList(lstOptions, "OptionId", "OptionName");
            return PartialView();
        }*/
        /*public List<CategoryMaster> GetCategoryMasters()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                UriBuilder builder = new UriBuilder("http://localhost:57203/api/apitopicmaster");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(builder.Uri).Result;
                using (HttpContent content = response.Content)
                {
                    Task<string> result = content.ReadAsStringAsync();
                    Result = result.Result;
                }
            }
            string json = Result;
            var deserialized = JsonConvert.DeserializeObject<List<TopicMaster>>(json);
            //return deserialized;
        }*/
    }
}