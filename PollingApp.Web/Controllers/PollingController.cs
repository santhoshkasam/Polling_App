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
  public class PollingController : Controller
  {
    public string Result { get; private set; }

    // GET: Poll
    public ActionResult Index()
    {
      var lstTopics = GetCategoryMasters().OrderBy(o => o.CategoryName).ToList();
      ViewBag.TopicNameList = new SelectList(lstTopics, "CategoryId", "CategoryName");
      return View();
    }

    // GET: Poll/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: Poll/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Poll/Create
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

    // GET: Poll/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: Poll/Edit/5
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

    // GET: Poll/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: Poll/Delete/5
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
    public List<CategoryMaster> GetCategoryMasters()
    {
      using (var client = new System.Net.Http.HttpClient())
      {
        UriBuilder builder = new UriBuilder("http://localhost:8080/api/apiCategorymaster");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = client.GetAsync(builder.Uri).Result;
        using (HttpContent content = response.Content)
        {
          Task<string> result = content.ReadAsStringAsync();
          Result = result.Result;
        }
      }
      string json = Result;
      var deserialized = JsonConvert.DeserializeObject<List<CategoryMaster>>(json);
      return deserialized;
    }
  }
}
