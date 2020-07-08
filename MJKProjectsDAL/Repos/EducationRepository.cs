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
    public class EducationRepository : IEducationRepository
    {
        private readonly ApplicationDbContext _context;

        public EducationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Education model)
        {
            _context.Educations.Add(model);
            _context.SaveChanges();
        }

        public bool Delete(Education model)
        {
            _context.Educations.Remove(model);
            return _context.SaveChanges() > 0;
        }

        public Education GetBy(Expression<Func<Education, bool>> expression)
        {
            return _context.Educations.Where(expression).FirstOrDefault();
        }

        public List<Education> List()
        {
            return _context.Educations.ToList();
        }

        public List<Education> OrderBy(Expression<Func<Education, bool>> expression)
        {
            return _context.Educations.OrderBy(expression).ToList();
        }

        public bool Update(Education model)
        {
            _context.Educations.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}
