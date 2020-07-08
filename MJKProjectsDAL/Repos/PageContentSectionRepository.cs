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
    public class PageContentSectionRepository : IPageContentSectionRepository
    {
        private readonly ApplicationDbContext _context;

        public PageContentSectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(PageContentSection model)
        {
            _context.PageContentSections.Add(model);
            _context.SaveChanges();
        }

        public bool Delete(PageContentSection model)
        {
            _context.PageContentSections.Remove(model);
            return _context.SaveChanges() > 0;
        }

        public PageContentSection GetBy(Expression<Func<PageContentSection, bool>> expression)
        {
            return _context.PageContentSections.Where(expression).FirstOrDefault();
        }

        public List<PageContentSection> List()
        {
            return _context.PageContentSections.ToList();
        }

        public List<PageContentSection> OrderBy(Expression<Func<PageContentSection, bool>> expression)
        {
            return _context.PageContentSections.OrderBy(expression).ToList();
        }

        public bool Update(PageContentSection model)
        {
            _context.PageContentSections.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}
