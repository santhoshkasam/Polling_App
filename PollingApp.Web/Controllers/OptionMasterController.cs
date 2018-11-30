using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PollingApp.Models;
using System.Net.Http.Headers;

namespace PollingApp.Web.Controllers
{
    public class OptionMasterController : Controller
    {
        public string Result { get; set; }
        public class AllJournals
        {
            public IEnumerable<OptionMaster> JournalEntries { get; set; }
        }
        // GET: OptionMaster
        public ActionResult Index()
        {
            //using (var client = new System.Net.Http.HttpClient())
            //{
            //  // HTTP POST
            //  client.BaseAddress = new Uri("http://localhost:8080/api/apioptionmaster/");
            //  //client.DefaultRequestHeaders.Add("Authorization", "Basic dmNhM2VzZ2pqMjA0OTJzMjE4ajdkZjJyNmM2Ym5qNGo0YXNtazF5Zw==");
            //  client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //  //var response = client.GetAsync("/companies/709c095a-298b-49e8-8e73-07cea548c3d2").Result;
            //  var response = client.GetAsync("/api/apiOptionMaster").Result;
            //  using (HttpContent content = response.Content)
            //  {
            //    // ... Read the string.
            //    Task<string> result = content.ReadAsStringAsync();
            //    Result = result.Result;
            //  }
            //}
            //string json = Result;
            //var deserialized = JsonConvert.DeserializeObject<List<OptionMaster>>(json);
            //return View(deserialized);
            return View();
        }

        [HttpPost]
        public ActionResult Index(List<OptionMaster> optionMaster)
        {
            return PartialView("OptionList", optionMaster);
        }

        // GET: OptionMaste/Details/5
        public ActionResult Details(int id)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                UriBuilder builder = new UriBuilder("http://localhost:8080/api/apioptionmaster/get");
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
            var deserialized = JsonConvert.DeserializeObject<OptionMaster>(json);
            return PartialView(deserialized);
        }

        // GET: OptionMaster/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: OptionMaster/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OptionMaster/Edit/5
        public ActionResult Edit(int id)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                UriBuilder builder = new UriBuilder("http://localhost:8080/api/apioptionmaster/get");
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
            var deserialized = JsonConvert.DeserializeObject<OptionMaster>(json);
            return PartialView(deserialized);
        }

        // POST: OptionMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OptionMaster/Delete/5
        public ActionResult Delete(int id)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                UriBuilder builder = new UriBuilder("http://localhost:8080/api/apioptionmaster/get");
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
            var deserialized = JsonConvert.DeserializeObject<OptionMaster>(json);
            return PartialView(deserialized);
        }

        // POST: OptionMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
