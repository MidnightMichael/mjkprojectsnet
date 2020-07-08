using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MJKProjectsDAL.Models;
using MJKProjectsDAL.Repos;
using MJKProjectsDAL.Repos.Interfaces;

namespace MJKProjectsClient.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IActionResult Index()
        {
            var projects = _projectRepository.List();
            return View(projects);
        }

        public IActionResult Single(string id)
        {
            var project = _projectRepository.GetByFunc(p => p.TitleToURL() == id);            

            return View(project);
        }
    }
}