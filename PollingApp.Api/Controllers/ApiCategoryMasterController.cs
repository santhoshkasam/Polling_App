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
    public class ApiCategoryMasterController : ApiController
    {
        private readonly ICategoryMasterRepo _categoryMasterRepo;
        public ApiCategoryMasterController(ICategoryMasterRepo categoryMasterRepo)
        {
            _categoryMasterRepo = categoryMasterRepo;
        }
        // GET api/<controller>
        public IEnumerable<CategoryMaster> Get()
        {
            return _categoryMasterRepo.GetAll();
        }

        // GET: api/ApiTopicMaster/5
        public CategoryMaster Get(int id)
        {
            return _categoryMasterRepo.Get(id);
        }

        // POST: api/ApiTopicMaster
        public HttpResponseMessage Post([FromBody]CategoryMaster categoryMaster)
        {
            categoryMaster.CreatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _categoryMasterRepo.Add(ref categoryMaster);
            }
            if (categoryMaster.CategoryId > 0)
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

        // PUT: api/ApiTopicMaster/5
        [HttpPut]
        public HttpResponseMessage Put([FromBody]CategoryMaster categoryMaster)
        {
            categoryMaster.LastModifiedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _categoryMasterRepo.Update(categoryMaster);
            }
            if (categoryMaster.CategoryId > 0)
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

        // DELETE: api/ApiTopicMaster/5
        [HttpPost]
        public HttpResponseMessage DeleteCategory(int id)
        {
            try
            {
                _categoryMasterRepo.Delete(id);
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