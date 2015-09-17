using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Web.Models
{
    public class TrackerReadingRepository
    {

        public bool AddReadings(List<TrackerReadingModel> models)
        {
            int affectedRows = 0;
            foreach(var model in models)
            {
                affectedRows+= Convert.ToInt32(AddReading(model));
            }
            return affectedRows == models.Count();
        }

        public bool AddReading(TrackerReadingModel model)
        {
            int affectedRows = 0;

            using(var db = new trackerwebdbEntities())
            {
                //look up monitor
                Monitor monitor = db.Monitors.Where(x => x.IpAddress == model.IpAddress).FirstOrDefault();
                if (monitor != null)
                {
                    //update last ping
                    monitor.LastPing = model.Reading;

                    //look up tag
                    Tag tag = db.Tags.Where(x => x.TagId == model.TagId).FirstOrDefault();
                    if (tag != null)
                    {
                        Tracking t = null;
                        //get latest tag readings (keep most recent 3)
                        var historicReadings = db.Trackings.Where(x => x.TagId == tag.Id).OrderByDescending(x => x.Reading).ToList();
                        if(historicReadings.Count > 0)
                        {
                            //most recent reading first, check to see if location has changed
                            var mostRecent = historicReadings.First();
                            if(mostRecent.MonitorId == monitor.Id)
                            {
                                //just update reading
                                mostRecent.Reading = model.Reading;
                            }
                            else
                            {
                                //add reading -- only keep 3 of the last locations total per tag
                                if (historicReadings.Count == 3)
                                {
                                    db.Trackings.Remove(historicReadings[2]);
                                }
                                t = new Tracking();
                                t.MonitorId = monitor.Id;
                                t.TagId = tag.Id;
                                t.Reading = model.Reading;
                                db.Trackings.Add(t);
                            }
                        }
                        else 
                        {
                            //no history simply add
                            t = new Tracking();
                            t.MonitorId = monitor.Id;
                            t.TagId = tag.Id;
                            t.Reading = model.Reading;
                            db.Trackings.Add(t);
                        }
                        affectedRows = db.SaveChanges();
                    } //end find tag
                } // end find monitor
            }//end using statement
            return affectedRows > 0;
        }
    }
}
