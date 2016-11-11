using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TennisMatchWebApp.Models;
using TennisMatchWebApp.Services;

namespace TennisMatchWebApp.Controllers.Api
{
    [RoutePrefix("api/tennis")]
    public class TennisApiController : ApiController
    {
        [Route("player")]
        [HttpPost]
        public HttpResponseMessage InsertPlayer([FromBody]string name)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            int response = TennisService.InsertPlayer(name);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("match")]
        [HttpPost]
        public HttpResponseMessage InsertMatch(PlayerMatchScore model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            int response = TennisService.InsertMatch(model);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("match/{id}")]
        [HttpPut]
        public HttpResponseMessage UpdateMatch(PlayerMatchScore model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            int response = TennisService.UpdateMatch(model);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("matches")]
        [HttpGet]
        public HttpResponseMessage GetMatches()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            List<Match> response = TennisService.GetMatches();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("players")]
        [HttpGet]
        public HttpResponseMessage GetPlayers()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            List<Player> response = TennisService.GetPlayers();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("match/{id}/delete")]
        [HttpPut]
        public HttpResponseMessage DeleteMatch(int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            int response = TennisService.DeleteMatch(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
