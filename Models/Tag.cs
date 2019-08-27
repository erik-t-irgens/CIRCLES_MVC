using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Circles_MVC.Models
{

    public class Tag
    {

        public int TagId { get; set; }
        public string Name { get; set; }

        public ICollection<Userprofile> Userprofiles { get; set; }
    }
}