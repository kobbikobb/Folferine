using System.Collections.Generic;

namespace Folferine.Website.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int HoleCount { get; set; }

        public virtual List<Game> Games { get; set; }

        public Course()
        {
            
        }
    }
}