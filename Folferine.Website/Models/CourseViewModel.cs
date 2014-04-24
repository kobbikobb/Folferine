using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Folferine.Website.Models
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        [DisplayName("Hole count")]
        public int HoleCount { get; set; }
    }
}