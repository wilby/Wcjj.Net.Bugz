using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wcjj.Net.Bugz.Data;

namespace Wcjj.Net.Bugz.Controllers
{
    public class BugsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BugsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bugs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bugs.Include(b => b.Application).Include(b => b.AssignedTo).Include(b => b.Submitter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Bugs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bug = await _context.Bugs
                .Include(b => b.Application)
                .Include(b => b.AssignedTo)
                .Include(b => b.Submitter)
                .FirstOrDefaultAsync(m => m.BugId == id);
            if (bug == null)
            {
                return NotFound();
            }

            

            return View(bug);
        }

        // GET: Bugs/Create
        public IActionResult Create()
        {
            ViewData["AppId"] = new SelectList(_context.Apps, "AppId", "AppId");
            ViewData["AssignedToId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["SubmitterId"] = new SelectList(_context.Users, "Id", "Id");
            var bug = new Bug();
            bug.Status_ = _context.Status_.ToList();
            bug.BugTypes = _context.Priorities.ToList();
           
            return View(bug);
        }

        // POST: Bugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BugId,Subject,Description,StatusId,PriorityId,SubmitterId,AssignedToId,AppId")] Bug bug)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppId"] = new SelectList(_context.Apps, "AppId", "AppId", bug.AppId);
            ViewData["AssignedToId"] = new SelectList(_context.Users, "Id", "Id", bug.AssignedToId);
            ViewData["SubmitterId"] = new SelectList(_context.Users, "Id", "Id", bug.SubmitterId);
            return View(bug);
        }

        // GET: Bugs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bug = await _context.Bugs.FindAsync(id);
            if (bug == null)
            {
                return NotFound();
            }
            ViewData["AppId"] = new SelectList(_context.Apps, "AppId", "AppId", bug.AppId);
            ViewData["AssignedToId"] = new SelectList(_context.Users, "Id", "Id", bug.AssignedToId);
            ViewData["SubmitterId"] = new SelectList(_context.Users, "Id", "Id", bug.SubmitterId);
            return View(bug);
        }

        // POST: Bugs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BugId,Subject,Description,StatusId,PriorityId,SubmitterId,AssignedToId,AppId")] Bug bug)
        {
            if (id != bug.BugId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bug);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BugExists(bug.BugId))
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
            ViewData["AppId"] = new SelectList(_context.Apps, "AppId", "AppId", bug.AppId);
            ViewData["AssignedToId"] = new SelectList(_context.Users, "Id", "Id", bug.AssignedToId);
            ViewData["SubmitterId"] = new SelectList(_context.Users, "Id", "Id", bug.SubmitterId);
            return View(bug);
        }

        // GET: Bugs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bug = await _context.Bugs
                .Include(b => b.Application)
                .Include(b => b.AssignedTo)
                .Include(b => b.Submitter)
                .FirstOrDefaultAsync(m => m.BugId == id);
            if (bug == null)
            {
                return NotFound();
            }

            return View(bug);
        }

        // POST: Bugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bug = await _context.Bugs.FindAsync(id);
            if (bug != null)
            {
                _context.Bugs.Remove(bug);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BugExists(int id)
        {
            return _context.Bugs.Any(e => e.BugId == id);
        }
    }
}
