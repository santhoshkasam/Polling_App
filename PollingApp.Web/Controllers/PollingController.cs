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
      var lstTopics = GetCategoryMasters().OrderBy(o => o.CategoryName).ToList();
      ViewBag.TopicNameList = new SelectList(lstTopics, "CategoryId", "CategoryName");


      return View();
    }

    // POST: Poll/Create
    [HttpPost]
    public ActionResult Create(string[] selectedTopicOptionMappingId, string comments)
    {
      try
      {
        List<Polling> pollings = new List<Polling>();
        for (int i = 0; i < selectedTopicOptionMappingId.Length; i++)
        {
          Polling polling = new Polling();
          polling.TopicOptionMappingId = Convert.ToInt32(selectedTopicOptionMappingId[i]);
          polling.SubmittedDate = DateTime.Now;
          polling.Comments = comments;
          pollings.Add(polling);
        }
        var myContent = JsonConvert.SerializeObject(pollings);
        var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        using (var client = new System.Net.Http.HttpClient())
        {
          var response = client.PostAsync("http://localhost:57203/api/ApiPolling", byteContent).Result;
          using (HttpContent content = response.Content)
          {
            Task<string> result = content.ReadAsStringAsync();
            Result = result.Result;
          }
        }
        string json = Result;
        var deserialized = JsonConvert.DeserializeObject<List<CategoryMaster>>(json);
        return PartialView("SuccessMessage");
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

    public ActionResult Report()
    {
      var lstTopics = GetCategoryMasters().OrderBy(o => o.CategoryName).ToList();
      ViewBag.TopicNameList = new SelectList(lstTopics, "CategoryId", "CategoryName");
      return View();
    }
    public ActionResult GetTopicsWithOptions(int id)
    {
      using (var client = new System.Net.Http.HttpClient())
      {
        UriBuilder builder = new UriBuilder("http://localhost:8080/api/ApiTopicOptionMapping/GetTopicsWithOptions");
        builder.Query = "categroyId=" + id;
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = client.GetAsync(builder.Uri).Result;
        using (HttpContent content = response.Content)
        {
          Task<string> result = content.ReadAsStringAsync();
          Result = result.Result;
        }
      }
      string json = Result;
      var deserialized = JsonConvert.DeserializeObject<List<TopicWithOptions>>(json);
      return PartialView("_GetTopicsWithOptions", deserialized);
    }
  }
}
