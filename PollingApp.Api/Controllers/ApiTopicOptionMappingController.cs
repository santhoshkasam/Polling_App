using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PollingApp.Models;
using PollingApp.Repositories;

namespace PollingApp.Api.Controllers
{
  public class ApiTopicOptionMappingController : ApiController
  {

    private readonly ITopicOptionMappingRepo _topicOptionMappingRepo;
    public ApiTopicOptionMappingController(ITopicOptionMappingRepo topicOptionMappingRepo)
    {
      _topicOptionMappingRepo = topicOptionMappingRepo;
    }
    // GET: api/ApiTopicOptionMapping
    public IEnumerable<TopicOptionMapping> Get()
    {
      return _topicOptionMappingRepo.GetAll();
    }

    // GET: api/ApiTopicOptionMapping/5
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/ApiTopicOptionMapping
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/ApiTopicOptionMapping/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/ApiTopicOptionMapping/5
    public void Delete(int id)
    {
    }
  }
}
