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
    public class WorkHistoryRepository : IWorkHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(WorkHistory model)
        {
            _context.WorkHistories.Add(model);
            _context.SaveChanges();
        }

        public bool Delete(WorkHistory model)
        {
            _context.WorkHistories.Remove(model);
            return _context.SaveChanges() > 0;
        }

        public WorkHistory GetBy(Expression<Func<WorkHistory, bool>> expression)
        {
            return _context.WorkHistories.Where(expression).FirstOrDefault();
        }

        public List<WorkHistory> List()
        {
            return _context.WorkHistories.ToList();
        }

        public List<WorkHistory> OrderBy(Expression<Func<WorkHistory, bool>> expression)
        {
            return _context.WorkHistories.OrderBy(expression).ToList();
        }

        public bool Update(WorkHistory model)
        {
            _context.WorkHistories.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}
