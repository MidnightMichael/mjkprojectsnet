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
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _context;

        public SkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Skill model)
        {
            _context.Skills.Add(model);
            _context.SaveChanges();
        }

        public bool Delete(Skill model)
        {
            _context.Skills.Remove(model);
            return _context.SaveChanges() > 0;
        }

        public Skill GetBy(Expression<Func<Skill, bool>> expression)
        {
            return _context.Skills.Where(expression).FirstOrDefault();
        }

        public List<Skill> List()
        {
            return _context.Skills.ToList();
        }

        public List<Skill> OrderBy(Expression<Func<Skill, bool>> expression)
        {
            return _context.Skills.OrderBy(expression).ToList();
        }

        public bool Update(Skill model)
        {
            _context.Skills.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}
