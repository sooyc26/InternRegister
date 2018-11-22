using InternRegister.Models.InternsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace InternRegister.Controllers
{
    [RoutePrefix("api/interns")]
    public class InternController : ApiController
    {

        HttpRequestMessage req = new HttpRequestMessage();
        HttpConfiguration configuration = new HttpConfiguration();
        public InternController()
        {
            req.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = configuration;

        }

        [HttpPost]
        public HttpResponseMessage Create(InternCreateRequest request)
        {
            if (request == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "please enter valid input");
            }
            int id = _userService.Create(request);

            return req.CreateResponse(HttpStatusCode.OK, id);
        }


        [HttpGet]
        public HttpResponseMessage ReadAll()
        {
            var lyrics = _userService.ReadAll();
            return req.CreateResponse(HttpStatusCode.OK, lyrics);
        }

        [HttpGet, Route("{id:int}")]
        public HttpResponseMessage ReadById(int id)
        {
            var lyric = _userService.ReadById(id);
            return req.CreateResponse(HttpStatusCode.OK, lyric);
        }

        [HttpPut, Route("{id:int}")]
        public HttpResponseMessage UpdateById(InternUpdateRequest request, int id)
        {
            var retId = _userService.UpdateUser(request, id);
            return Request.CreateResponse(HttpStatusCode.OK, retId);
        }

        [HttpDelete, Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            var retId = _userService.Delete(id);
            var message = "deleted Id: " + retId;
            return Request.CreateResponse(HttpStatusCode.OK, message);
        }
    }
}