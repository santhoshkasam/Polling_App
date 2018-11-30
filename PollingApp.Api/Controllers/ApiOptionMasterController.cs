using PollingApp.Models;
using PollingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PollingApp.Models;

namespace PollingApp.Api.Controllers
{
    public class ApiOptionMasterController : ApiController
    {
        //get api/<controller>
        private readonly IOptionMasterRepo _optionmasterrepo;
        public ApiOptionMasterController(IOptionMasterRepo optionmasterrepo)
        {
            _optionmasterrepo = optionmasterrepo;
        }
        // get: api/apioptionmaster
        public IEnumerable<OptionMaster> Get()
        {
            return _optionmasterrepo.GetAll();
        }

        // GET: api/ApioptionMaster/5
        public OptionMaster Get(int id)
        {
            return _optionmasterrepo.Get(id);
        }

        // POST: api/ApioptionMaster
        public HttpResponseMessage Post([FromBody]OptionMaster optionMaster)
        {
            optionMaster.CreatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _optionmasterrepo.Add(ref optionMaster);
            }
            if (optionMaster.OptionId > 0)
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

        // PUT: api/ApioptionMaster/5
        [HttpPut]
        public HttpResponseMessage Put([FromBody]OptionMaster optionMaster)
        {
            optionMaster.LastModifiedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _optionmasterrepo.Update(optionMaster);
            }
            if (optionMaster.OptionId > 0)
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

        // DELETE: api/ApioptionMaster/5
        [HttpPost]
        public HttpResponseMessage DeleteOption(int id)
        {
            try
            {
                _optionmasterrepo.Delete(id);
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