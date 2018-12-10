using Newtonsoft.Json;
using PollingApp.Models;
using PollingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace PollingApp.Api.Controllers
{
  public class ApiPollingController : ApiController
  {
    private readonly IPollingRepo _pollingRepo;

    public string Result { get; private set; }

    public ApiPollingController(IPollingRepo pollingRepo)
    {
      _pollingRepo = pollingRepo;
    }
    // GET: api/ApiPolling
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET: api/ApiPolling/5
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/ApiPolling
    public void Post([FromBody]List<Polling> polling)
    {
      foreach (Polling item in polling)
      {
        item.SubmittedDate = DateTime.Now;
        Polling p = item;
        if (ModelState.IsValid)
        {
          _pollingRepo.Add(ref p);
        }
      }
    }

    // PUT: api/ApiPolling/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/ApiPolling/5
    public void Delete(int id)
    {
    }

    [HttpPost]
    [Route("GetTopicWisePolls")]
    public List<TopicPolls> GetTopicWisePolls(int categroyId)
    {
      var topicPolls = _pollingRepo.GetTopicPolls(categroyId);
      return topicPolls;
    }

  }
}
