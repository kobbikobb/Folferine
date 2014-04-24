using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Folferine.Website.Models
{
    public class GameDetailsViewModel
    {
        public int Id { get; set; }

        [DisplayName("Created")]
        public DateTime CreatedDate { get; set; }
        
        [DisplayName("Course")]
        public string CourseName { get; set; }
        
        [DisplayName("Location")]
        public string CourseLocation { get; set; }
        
        [DisplayName("Hole count")]
        public int CourseHoleCount { get; set; }

        public List<ScorecardViewModel> Scorecards { get; set; }
    }
}