using LMCProj.Models.Domain;
using LMCProj.Models.Request;
using LMCProj.Models.Response;
using LMCProj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMCProj.Web.Controllers.Api
{
    [RoutePrefix("api/people")]
    public class PeopleController : ApiController
    {
        protected PeopleService svc = new PeopleService();
        // GET GetAll
        [Route("getall"), HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                ItemListResponse<People> response = new ItemListResponse<People>();
                response.Items = svc.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET by Id
        [Route("getbyid/{id:int}"), HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                ItemResponse<People> response = new ItemResponse<People>();
                response.Item = svc.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST 
        [Route, HttpPost]
        public HttpResponseMessage Post([FromBody] PeopleAddRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //placeholder before authenticaction in place
                    model.ModifiedBy = "me";

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

        // PUT
        [Route, HttpPut]
        public HttpResponseMessage Put([FromBody]PeopleUpdateRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //placeholder before authentication in place
                    model.ModifiedBy = "me";

                    SuccessResponse response = new SuccessResponse();
                    svc.Update(model);
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE
        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                svc.Delete(id);
                SuccessResponse response = new SuccessResponse();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}