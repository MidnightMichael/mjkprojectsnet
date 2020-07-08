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
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Project model)
        {
            _context.Projects.Add(model);
            _context.SaveChanges();
        }

        public bool Delete(Project model)
        {
            _context.Projects.Remove(model);
            return _context.SaveChanges() > 0;
        }

        public Project GetBy(Expression<Func<Project, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Project GetByTitle(string title)
        {
            return _context.Projects.ToList().Where(p => p.TitleToURL() == title).FirstOrDefault();
        }

        public Project GetByFunc(Func<Project, bool> func)
        {
            return _context.Projects.ToList().Where(func).FirstOrDefault();
        }

        public List<Project> List()
        {
            return _context.Projects.ToList();
        }

        public List<Project> OrderBy(Expression<Func<Project, bool>> expression)
        {
            return _context.Projects.OrderBy(expression).ToList();
        }

        public bool Update(Project model)
        {
            _context.Projects.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}
