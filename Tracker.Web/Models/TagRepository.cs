using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Web.Models
{
    public class TagRepository
    {
        public List<Tag> GetAllTags()
        {
            List<Tag> retvalue = null;
            using (var db = new trackerwebdbEntities())
            {
                retvalue = db.Tags.ToList();
            }
            return retvalue;
        }

        public Tag GetTagById(int id)
        {
            Tag retvalue = null;
            using (var db = new trackerwebdbEntities())
            {
                retvalue = db.Tags.Where(x => x.Id == id).FirstOrDefault();
            }
            return retvalue;
        }

        public bool AddTag(Tag Tag)
        {
            int affectedRows = 0;
            using (var db = new trackerwebdbEntities())
            {
                Tag.Status = 1;
                db.Tags.Add(Tag);
                affectedRows = db.SaveChanges();
            }
            return affectedRows > 0;
        }

        public bool UpdateTag(Tag Tag)
        {
            int affectedRows = 0;
            using (var db = new trackerwebdbEntities())
            {
                //update tagid, friendly name, description and (future) image blob
                var model = db.Tags.Where(x => x.Id == Tag.Id).First();
                model.TagId = Tag.TagId;
                model.FriendlyName = Tag.FriendlyName;
                model.Description = Tag.Description;
                model.Status = Tag.Status;
                affectedRows = db.SaveChanges();
            }
            return affectedRows > 0;
        }
    }
}
