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
    public class PageContentSectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PageContentSectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PageContentSections
        public async Task<IActionResult> Index()
        {
            return View(await _context.PageContentSections.ToListAsync());
        }

        // GET: PageContentSections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageContentSection = await _context.PageContentSections
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pageContentSection == null)
            {
                return NotFound();
            }

            return View(pageContentSection);
        }

        // GET: PageContentSections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PageContentSections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Page,Content,ID,CreatedAt")] PageContentSection pageContentSection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pageContentSection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pageContentSection);
        }

        // GET: PageContentSections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageContentSection = await _context.PageContentSections.FindAsync(id);
            if (pageContentSection == null)
            {
                return NotFound();
            }
            return View(pageContentSection);
        }

        // POST: PageContentSections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Page,Content,ID,CreatedAt")] PageContentSection pageContentSection)
        {
            if (id != pageContentSection.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pageContentSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageContentSectionExists(pageContentSection.ID))
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
            return View(pageContentSection);
        }

        // GET: PageContentSections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageContentSection = await _context.PageContentSections
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pageContentSection == null)
            {
                return NotFound();
            }

            return View(pageContentSection);
        }

        // POST: PageContentSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pageContentSection = await _context.PageContentSections.FindAsync(id);
            _context.PageContentSections.Remove(pageContentSection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageContentSectionExists(int id)
        {
            return _context.PageContentSections.Any(e => e.ID == id);
        }
    }
}
