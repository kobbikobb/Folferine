using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Folferine.Website.Domain;
using Folferine.Website.Domain.Repositories;
using Folferine.Website.Infrastructure;
using Folferine.Website.Models;

namespace Folferine.Website.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseRepository courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            if (courseRepository == null) throw new ArgumentNullException("courseRepository");
            this.courseRepository = courseRepository;
        }

        public ActionResult Index()
        {
            return View(Mapper.Map<List<Course>, List<CourseViewModel>>(courseRepository.GetAll()));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = courseRepository.Find(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Course, CourseViewModel>(course));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel course)
        {
            if (ModelState.IsValid)
            {
                courseRepository.Create(Mapper.Map<CourseViewModel, Course>(course));
                courseRepository.Save();
    
                return RedirectToAction("Index");
            }

            return View(course);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = courseRepository.Find(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Course, CourseViewModel>(course));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseViewModel course)
        {
            if (ModelState.IsValid)
            {
                courseRepository.Update(Mapper.Map<CourseViewModel, Course>(course));
                courseRepository.Save();
        
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = courseRepository.Find(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = courseRepository.Find(id);
            courseRepository.Delete(course);
            courseRepository.Save();
    
            return RedirectToAction("Index");
        }
    }
}
