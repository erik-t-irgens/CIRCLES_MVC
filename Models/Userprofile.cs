using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Circles_MVC.Models
{

    public class Userprofile
    {                                
        public int UserprofileId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }
        public string Photo { get; set; }
        public string Location { get; set; }
        public int ApplicationUserId { get; set; }

        public ICollection<TagUserprofile> Tags { get; set; }
        public ICollection<CircleUserprofile> Circles { get; set; }
    }
}