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

            PlayerMatchScore response = TennisService.UpdateMatch(model);
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

            List<Match> response = TennisService.GetAllMatches;
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

            List<Player> response = TennisService.GetPlayers;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("match/{id}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteMatch(int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            int response = TennisService.DeleteMatch(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("search")]
        [HttpPut]
        public HttpResponseMessage SearchMatches(Search search)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            IEnumerable<Match> response = TennisService.SearchMatches(search);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("search/data")]
        [HttpGet]
        public HttpResponseMessage SearchData()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            PopulateSearch response = new PopulateSearch();
            IEnumerable<string> player = TennisService.PlayerSearchBar();
            IEnumerable<string> location = TennisService.LocationSearchBar();
            IEnumerable<DateTime> date = TennisService.DateSearchBar();

            response.Players = player;
            response.Locations = location;
            response.Dates = date;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
