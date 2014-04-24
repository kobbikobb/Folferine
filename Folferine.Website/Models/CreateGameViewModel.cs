using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Folferine.Website.Domain;

namespace Folferine.Website.Models
{
    public class CreateGameViewModel
    {
        public List<Course> Courses { get; set; }
        public List<Player> OtherUsers { get; set; } 
        
        public int SelectedCourseId { get; set; }
        public List<string> SelectedOtherUserNames { get; set; } 

        public CreateGameViewModel()
        {
            SelectedOtherUserNames = new List<string>();
        }

        public IEnumerable<string> GetSelectableOtherUserNames()
        {
            return OtherUsers.Select(x => x.UserName);
        }
    }
}