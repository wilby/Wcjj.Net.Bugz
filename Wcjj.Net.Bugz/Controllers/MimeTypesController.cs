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
    public class MimeTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MimeTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MimeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MimeTypes.ToListAsync());
        }

        // GET: MimeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mimeType = await _context.MimeTypes
                .FirstOrDefaultAsync(m => m.MimeTypeId == id);
            if (mimeType == null)
            {
                return NotFound();
            }

            return View(mimeType);
        }

        // GET: MimeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MimeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MimeTypeId,Type,Description,AltType")] MimeType mimeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mimeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mimeType);
        }

        // GET: MimeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mimeType = await _context.MimeTypes.FindAsync(id);
            if (mimeType == null)
            {
                return NotFound();
            }
            return View(mimeType);
        }

        // POST: MimeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MimeTypeId,Type,Description,AltType")] MimeType mimeType)
        {
            if (id != mimeType.MimeTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mimeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MimeTypeExists(mimeType.MimeTypeId))
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
            return View(mimeType);
        }

        // GET: MimeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mimeType = await _context.MimeTypes
                .FirstOrDefaultAsync(m => m.MimeTypeId == id);
            if (mimeType == null)
            {
                return NotFound();
            }

            return View(mimeType);
        }

        // POST: MimeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mimeType = await _context.MimeTypes.FindAsync(id);
            if (mimeType != null)
            {
                _context.MimeTypes.Remove(mimeType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MimeTypeExists(int id)
        {
            return _context.MimeTypes.Any(e => e.MimeTypeId == id);
        }
    }
}
