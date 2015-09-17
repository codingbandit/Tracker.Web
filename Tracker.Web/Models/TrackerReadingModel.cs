using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Web.Models
{
    //represents read data from monitors to cloud
    public class TrackerReadingModel
    {
        public string IpAddress { get; set; }
        public string TagId { get; set; }
        public DateTime Reading { get; set; }
    }
}
