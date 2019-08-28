
using System.ComponentModel.DataAnnotations;

namespace Circles_MVC.Models
{
    public class TagUserprofile
    {
        public int TagUserprofileId { get; set; }
        public int TagId { get; set; }
        public int UserprofileId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Userprofile Userprofile { get; set; }
    }
}