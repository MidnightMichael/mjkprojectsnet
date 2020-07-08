using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MJKProjectsDAL.EF;
using MJKProjectsDAL.Models;

namespace MJKProjectsAdminClient.Controllers
{
    public class WorkHistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkHistories
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkHistories.ToListAsync());
        }

        // GET: WorkHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workHistory = await _context.WorkHistories
                .FirstOrDefaultAsync(m => m.ID == id);
            if (workHistory == null)
            {
                return NotFound();
            }

            return View(workHistory);
        }

        // GET: WorkHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Employer,From,Till,ID,CreatedAt")] WorkHistory workHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workHistory);
        }

        // GET: WorkHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workHistory = await _context.WorkHistories.FindAsync(id);
            if (workHistory == null)
            {
                return NotFound();
            }
            return View(workHistory);
        }

        // POST: WorkHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Employer,From,Till,ID,CreatedAt")] WorkHistory workHistory)
        {
            if (id != workHistory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkHistoryExists(workHistory.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(workHistory);
        }

        // GET: WorkHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workHistory = await _context.WorkHistories
                .FirstOrDefaultAsync(m => m.ID == id);
            if (workHistory == null)
            {
                return NotFound();
            }

            return View(workHistory);
        }

        // POST: WorkHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workHistory = await _context.WorkHistories.FindAsync(id);
            _context.WorkHistories.Remove(workHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkHistoryExists(int id)
        {
            return _context.WorkHistories.Any(e => e.ID == id);
        }
    }
}
