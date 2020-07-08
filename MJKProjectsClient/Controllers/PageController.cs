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
    public class PageController : Controller
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IWorkHistoryRepository _workHistoryRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IPageContentSectionRepository _pageContentSectionRepository;

        public PageController(ISkillRepository skillRepository,
                              IWorkHistoryRepository workHistoryRepository,
                              IEducationRepository educationRepository,
                              IPageContentSectionRepository pageContentSectionRepository)
        {
            _skillRepository = skillRepository;
            _workHistoryRepository = workHistoryRepository;
            _educationRepository = educationRepository;
            _pageContentSectionRepository = pageContentSectionRepository;
        }

        public IActionResult About()
        {
            var about = new AboutModel()
            {
                Skills = _skillRepository.List(),
                Educations = _educationRepository.List(),
                WorkHistory = _workHistoryRepository.List(),
                ContentSections = _pageContentSectionRepository.List(),
            };
            
            // ReSharper disable once Mvc.ViewNotResolved
            return View("Views/Pages/About.cshtml", about);
        }

        /// <summary>
        /// Inner class to use as page view model
        /// Refactor to full model later i guess
        /// </summary>
        public class AboutModel
        {
            public List<Skill> Skills { get; set; }
            public List<WorkHistory> WorkHistory { get; set; }
            public List<Education> Educations { get; set; }
            public List<PageContentSection> ContentSections { get; set; }
        }
    }
}