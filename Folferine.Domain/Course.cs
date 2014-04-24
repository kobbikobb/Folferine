using System.Collections.Generic;

namespace Folferine.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int HoleCount { get; set; }

        public List<Game> Games { get; set; }
    }
}