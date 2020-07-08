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
    public class BlogController : Controller
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogController(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public IActionResult Index()
        {
            var blogs = _blogPostRepository.List();
            return View(blogs);
        }

        public IActionResult Single(string id)
        {
            var blog = _blogPostRepository.GetByFunction(b => b.TitleToURL() == id);
            return View(blog);
        }
    }
}