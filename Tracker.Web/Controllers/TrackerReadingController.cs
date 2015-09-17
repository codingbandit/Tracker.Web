using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Tracker.Web.Models;

namespace Tracker.Web.Api
{
    [RoutePrefix("api/reading")]
    public class TrackerReadingController : ApiController
    {

        [HttpPost]
        [Route("add-reading")]
        public HttpResponseMessage PostTrackerReadingModel(TrackerReadingModel trackerReadingModel)
        {
            TrackerReadingRepository repo = new TrackerReadingRepository();
            bool ok = repo.AddReading(trackerReadingModel);
            if(ok)
                return Request.CreateResponse(HttpStatusCode.OK);
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route("add-multi-readings")]
        public HttpResponseMessage PostMultiTrackerReadings(List<TrackerReadingModel> trackerReadingModels)
        {
            TrackerReadingRepository repo = new TrackerReadingRepository();
            var ok = repo.AddReadings(trackerReadingModels);
            if (ok)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            
        }

  
    }
}
