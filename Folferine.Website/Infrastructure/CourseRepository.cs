using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Folferine.Website.Domain;
using Folferine.Website.Domain.Repositories;

namespace Folferine.Website.Infrastructure
{
    public class CourseRepository: Repository<Course, int>, ICourseRepository
    {
        public CourseRepository(FolferineContext context) : base(context)
        {

        }
    }
}