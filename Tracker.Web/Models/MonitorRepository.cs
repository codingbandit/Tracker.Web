using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Web.Models
{
    public class MonitorRepository
    {
        public List<Monitor> GetAllMonitors()
        {
            List<Monitor> retvalue = null;
            using(var db = new trackerwebdbEntities())
            {
                retvalue = db.Monitors.ToList();
            }
            return retvalue;
        }

        public Monitor GetMonitorById(int id)
        {
            Monitor retvalue = null;
            using(var db = new trackerwebdbEntities())
            {
                retvalue = db.Monitors.Where(x => x.Id == id).FirstOrDefault();
            }
            return retvalue;
        }

        public bool AddMonitor(Monitor monitor)
        {
            int affectedRows = 0;
            using(var db = new trackerwebdbEntities())
            {
                monitor.Status = 1;
                db.Monitors.Add(monitor);
                affectedRows = db.SaveChanges();
            }
            return affectedRows > 0;
        }

        public bool UpdateMonitor(Monitor monitor)
        {
            int affectedRows = 0;
            using(var db = new trackerwebdbEntities())
            {
                //update mac, friendly name, location and status
                var model = db.Monitors.Where(x => x.Id == monitor.Id).First();
                model.IpAddress = monitor.IpAddress;
                model.FriendlyName = monitor.FriendlyName;
                model.Location = monitor.Location;
                model.Status = monitor.Status;
                affectedRows = db.SaveChanges();
            }
            return affectedRows > 0;
        }
    }
}
