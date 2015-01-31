using TeamProjectWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamProject.Business.Contracts;
using TeamProject.Business.Entities;

namespace TeamProjectWeb.Controllers.MVC
{
    public class ProjectsController : BaseController
    {
        ITeamProjectService _teamProjectService; 
        IContactService _contactService;

        public ProjectsController(ITeamProjectService teamProjectService, IContactService contactService)
        {
            _teamProjectService = teamProjectService;
            _contactService = contactService;
        }

        // GET: Projects
        public ActionResult Index()
        {
            IEnumerable<Project> projects=  _teamProjectService.GetTeamProjects();
            IEnumerable<ProjectItemViewModel> projectItems = new ViewModelFactory().Create(projects);
            return View(projectItems);
        }

        // GET: Projects/Details/5
        public ActionResult Details(int id)
        {
          Project project=  _teamProjectService.GetTeamProject(id);
          ProjectViewModel projectViewModel = new ViewModelFactory(_contactService).Create(project);
          return View(projectViewModel);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Projects/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Projects/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
