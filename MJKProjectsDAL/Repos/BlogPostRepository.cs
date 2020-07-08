using MJKProjectsDAL.EF;
using MJKProjectsDAL.Models;
using MJKProjectsDAL.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MJKProjectsDAL.Repos
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(BlogPost model)
        {
            _context.BlogPosts.Add(model);
            _context.SaveChanges();
        }

        public bool Delete(BlogPost model)
        {
            _context.BlogPosts.Remove(model);
            return _context.SaveChanges() > 0;
        }

        public BlogPost GetBy(Expression<Func<BlogPost, bool>> expression)
        {
            return _context.BlogPosts.Where(expression).FirstOrDefault();
        }

        public BlogPost GetByFunc(Func<BlogPost, bool> func)
        {
            return _context.BlogPosts.Where(func).FirstOrDefault();
        }

        public BlogPost GetByFunction(Func<BlogPost, bool> func)
        {
            return _context.BlogPosts.Where(func).FirstOrDefault();
        }

        public List<BlogPost> List()
        {
            return _context.BlogPosts.ToList();
        }

        public List<BlogPost> OrderBy(Expression<Func<BlogPost, bool>> expression)
        {
            return _context.BlogPosts.OrderBy(expression).ToList();
        }

        public bool Update(BlogPost model)
        {
            _context.BlogPosts.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}
