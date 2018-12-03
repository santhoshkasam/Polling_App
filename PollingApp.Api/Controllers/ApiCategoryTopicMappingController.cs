using PollingApp.Models;
using PollingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PollingApp.Api.Controllers
{
    public class ApiCategoryTopicMappingController : ApiController
    {
        // GET api/<controller>
        private readonly ICategoryTopicMappingRepo _CategoryTopicMappingRepo;
        public ApiCategoryTopicMappingController(ICategoryTopicMappingRepo CategoryTopicMappingRepo)
        {
            _CategoryTopicMappingRepo = CategoryTopicMappingRepo;
        }
        public IEnumerable<CategoryTopicMapping> Get()
        {
            return _CategoryTopicMappingRepo.GetAll();
        }

        // GET api/<controller>/5
        public CategoryTopicMapping Get(int id)
        {
            return _CategoryTopicMappingRepo.Get(id);
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]CategoryTopicMapping categorytopicmapping)
        {
            categorytopicmapping.CreatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _CategoryTopicMappingRepo.Add(ref categorytopicmapping);
            }
            if (categorytopicmapping.CategoryTopicMappingId > 0)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, "Inserted Successfully");
                return response;
            }
            else
            {
                var response = Request.CreateResponse(HttpStatusCode.NotAcceptable, "Error Occured", Configuration.Formatters.JsonFormatter);
                return response;
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody]CategoryTopicMapping categorytopicmapping)
        {
            categorytopicmapping.LastModifiedDate = DateTime.Now;
            if(ModelState.IsValid)
            {
                _CategoryTopicMappingRepo.Update(categorytopicmapping);
            }
            if(categorytopicmapping.CategoryTopicMappingId > 0)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, "Updated Successfully");
                return response;
            }
            else
            {
                var response = Request.CreateResponse(HttpStatusCode.NotAcceptable, "Error Occured", Configuration.Formatters.JsonFormatter);
                return response;
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _CategoryTopicMappingRepo.Delete(id);
                var response = Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
                return response;
            }
            catch (Exception)
            {
                var response = Request.CreateResponse(HttpStatusCode.NotAcceptable, "Error Occured", Configuration.Formatters.JsonFormatter);
                return response;
            }
        }
    }
}