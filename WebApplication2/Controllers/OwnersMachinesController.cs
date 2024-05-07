using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class OwnersMachinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OwnersMachinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OwnersMachines
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OwnerMachines.Include(o => o.Owner).Include(o => o.VendingMachine);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OwnersMachines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerMachine = await _context.OwnerMachines
                .Include(o => o.Owner)
                .Include(o => o.VendingMachine)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ownerMachine == null)
            {
                return NotFound();
            }

            return View(ownerMachine);
        }

        // GET: OwnersMachines/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id");
            ViewData["VendingMachineId"] = new SelectList(_context.VendingMachines, "Id", "Id");
            return View();
        }

        // POST: OwnersMachines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VendingMachineId,OwnerId")] OwnerMachine ownerMachine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ownerMachine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id", ownerMachine.OwnerId);
            ViewData["VendingMachineId"] = new SelectList(_context.VendingMachines, "Id", "Id", ownerMachine.VendingMachineId);
            return View(ownerMachine);
        }

        // GET: OwnersMachines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerMachine = await _context.OwnerMachines.FindAsync(id);
            if (ownerMachine == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id", ownerMachine.OwnerId);
            ViewData["VendingMachineId"] = new SelectList(_context.VendingMachines, "Id", "Id", ownerMachine.VendingMachineId);
            return View(ownerMachine);
        }

        // POST: OwnersMachines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VendingMachineId,OwnerId")] OwnerMachine ownerMachine)
        {
            if (id != ownerMachine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ownerMachine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerMachineExists(ownerMachine.Id))
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
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id", ownerMachine.OwnerId);
            ViewData["VendingMachineId"] = new SelectList(_context.VendingMachines, "Id", "Id", ownerMachine.VendingMachineId);
            return View(ownerMachine);
        }

        // GET: OwnersMachines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerMachine = await _context.OwnerMachines
                .Include(o => o.Owner)
                .Include(o => o.VendingMachine)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ownerMachine == null)
            {
                return NotFound();
            }

            return View(ownerMachine);
        }

        // POST: OwnersMachines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ownerMachine = await _context.OwnerMachines.FindAsync(id);
            if (ownerMachine != null)
            {
                _context.OwnerMachines.Remove(ownerMachine);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerMachineExists(int id)
        {
            return _context.OwnerMachines.Any(e => e.Id == id);
        }
    }
}
