using StarterProj.Models.Domain;
using StarterProj.Models.Request;
using StarterProj.Models.Response;
using StarterProj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StarterProj.Web.Controllers.Api
{
    [RoutePrefix("api/people")]
    public class PeopleController : ApiController
    {
        // GET api/<controller>
        [Route("getall")]
        public HttpResponseMessage Get()
        {
            try
            {
                ItemListResponse<People> response = new ItemListResponse<People>();
                PeopleService svc = new PeopleService();
                response.Items = svc.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET api/<controller>/5
        [Route("getbyid")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [Route]
        public HttpResponseMessage Post([FromBody] PeopleAddRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.ModifiedBy = "me";
                    PeopleService svc = new PeopleService();
                    ItemResponse<int> response = new ItemResponse<int>();
                    response.Item = svc.Insert(model);
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}