using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MJKProjectsDAL.Models;
using MJKProjectsDAL.Repos;
using MJKProjectsDAL.Repos.Interfaces;

namespace MJKProjectsClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectRepository _projectRepository;
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IPageContentSectionRepository _pageContentSectionRepository;

        public HomeController(ILogger<HomeController> logger, IProjectRepository projectRepository, IBlogPostRepository blogPostRepository, IPageContentSectionRepository pageContentSectionRepository)
        {
            _logger = logger;
            _projectRepository = projectRepository;
            _blogPostRepository = blogPostRepository;
            _pageContentSectionRepository = pageContentSectionRepository;
        }

        public IActionResult Index()
        {
            /*
             * new List<Project>()
                {
                    Project.MakeProject("Lorem ipsum", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam iaculis porta quam eget malesuada. Maecenas facilisis diam vel imperdiet posuere. Fusce ac libero ultrices, cursus purus non, interdum velit. Mauris tristique, erat quis accumsan sollicitudin, nibh risus scelerisque dui, et euismod orci nisi bibendum massa. Aliquam erat volutpat. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce malesuada rutrum varius. Aliquam orci dolor, viverra at sagittis id, sagittis at magna. Cras sit amet erat a metus laoreet convallis eget vel mi. Morbi nunc sem, pretium eu eros sed, sagittis pharetra turpis. Interdum et malesuada fames ac ante ipsum primis in faucibus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam iaculis dignissim risus, id pellentesque urna aliquet non. Donec laoreet ultrices diam varius dapibus.n sem eros, porttitor id risus at, scelerisque lacinia lectus. Proin suscipit arcu sit amet felis sodales placerat. Duis consectetur elementum viverra. Pellentesque dolor felis, rutrum ut auctor sodales, tempus suscipit ante. Fusce non viverra leo. Proin lorem nisl, congue eget quam vitae, ornare vestibulum purus. Aliquam porttitor nibh nec placerat eleifend. Nullam semper auctor sapien, nec scelerisque tortor lobortis vitae."),
                    Project.MakeProject("Proin varius magna", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam iaculis porta quam eget malesuada. Maecenas facilisis diam vel imperdiet posuere. Fusce ac libero ultrices, cursus purus non, interdum velit. Mauris tristique, erat quis accumsan sollicitudin, nibh risus scelerisque dui, et euismod orci nisi bibendum massa. Aliquam erat volutpat. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce malesuada rutrum varius. Aliquam orci dolor, viverra at sagittis id, sagittis at magna. Cras sit amet erat a metus laoreet convallis eget vel mi. Morbi nunc sem, pretium eu eros sed, sagittis pharetra turpis. Interdum et malesuada fames ac ante ipsum primis in faucibus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam iaculis dignissim risus, id pellentesque urna aliquet non. Donec laoreet ultrices diam varius dapibus.n sem eros, porttitor id risus at, scelerisque lacinia lectus. Proin suscipit arcu sit amet felis sodales placerat. Duis consectetur elementum viverra. Pellentesque dolor felis, rutrum ut auctor sodales, tempus suscipit ante. Fusce non viverra leo. Proin lorem nisl, congue eget quam vitae, ornare vestibulum purus. Aliquam porttitor nibh nec placerat eleifend. Nullam semper auctor sapien, nec scelerisque tortor lobortis vitae."),
                    Project.MakeProject("Quisque sit amet ", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam iaculis porta quam eget malesuada. Maecenas facilisis diam vel imperdiet posuere. Fusce ac libero ultrices, cursus purus non, interdum velit. Mauris tristique, erat quis accumsan sollicitudin, nibh risus scelerisque dui, et euismod orci nisi bibendum massa. Aliquam erat volutpat. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce malesuada rutrum varius. Aliquam orci dolor, viverra at sagittis id, sagittis at magna. Cras sit amet erat a metus laoreet convallis eget vel mi. Morbi nunc sem, pretium eu eros sed, sagittis pharetra turpis. Interdum et malesuada fames ac ante ipsum primis in faucibus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam iaculis dignissim risus, id pellentesque urna aliquet non. Donec laoreet ultrices diam varius dapibus.n sem eros, porttitor id risus at, scelerisque lacinia lectus. Proin suscipit arcu sit amet felis sodales placerat. Duis consectetur elementum viverra. Pellentesque dolor felis, rutrum ut auctor sodales, tempus suscipit ante. Fusce non viverra leo. Proin lorem nisl, congue eget quam vitae, ornare vestibulum purus. Aliquam porttitor nibh nec placerat eleifend. Nullam semper auctor sapien, nec scelerisque tortor lobortis vitae."),
                    //Project.MakeProject("laoreet congue nulla aliquam", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam iaculis porta quam eget malesuada. Maecenas facilisis diam vel imperdiet posuere. Fusce ac libero ultrices, cursus purus non, interdum velit. Mauris tristique, erat quis accumsan sollicitudin, nibh risus scelerisque dui, et euismod orci nisi bibendum massa. Aliquam erat volutpat. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce malesuada rutrum varius. Aliquam orci dolor, viverra at sagittis id, sagittis at magna. Cras sit amet erat a metus laoreet convallis eget vel mi. Morbi nunc sem, pretium eu eros sed, sagittis pharetra turpis. Interdum et malesuada fames ac ante ipsum primis in faucibus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam iaculis dignissim risus, id pellentesque urna aliquet non. Donec laoreet ultrices diam varius dapibus.n sem eros, porttitor id risus at, scelerisque lacinia lectus. Proin suscipit arcu sit amet felis sodales placerat. Duis consectetur elementum viverra. Pellentesque dolor felis, rutrum ut auctor sodales, tempus suscipit ante. Fusce non viverra leo. Proin lorem nisl, congue eget quam vitae, ornare vestibulum purus. Aliquam porttitor nibh nec placerat eleifend. Nullam semper auctor sapien, nec scelerisque tortor lobortis vitae.")
                }*/
            
        var homePageModel = new HomePageModel()
            {
                Projects = _projectRepository.List(),
                Posts = _blogPostRepository.List(),
                ContentSections = _pageContentSectionRepository.List(),
                PageSettings = new PageSettings()
                {
                    ShowAboutRow = true,
                    ShowBlogRow = false,
                    ShowProjectRow = true
                }
            };

            return View(homePageModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public class HomePageModel
        {
            public List<Project> Projects { get; set; }
            public List<BlogPost> Posts { get; set; }
            public List<PageContentSection> ContentSections { get; set; }

            public PageSettings PageSettings { get; set; }
        }

        public class PageSettings
        {
            public bool ShowProjectRow { get; set; }
            public bool ShowBlogRow { get; set; }
            public bool ShowAboutRow { get; set; }
        }
    }
}
