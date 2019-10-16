using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using A1_200410745.Models;

namespace A1_200410745.Controllers
{
    public class PetFoodsController : Controller
    {
        private readonly A1_200410745Context _context;

        public PetFoodsController(A1_200410745Context context)
        {
            _context = context;
        }

        // GET: PetFoods
        public async Task<IActionResult> Index()
        {
            var a1_200410745Context = _context.PetFood.Include(p => p.PetFoodAnimal);
            return View(await a1_200410745Context.ToListAsync());
        }

        // GET: PetFoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petFood = await _context.PetFood
                .Include(p => p.PetFoodAnimal)
                .FirstOrDefaultAsync(m => m.PetFoodId == id);
            if (petFood == null)
            {
                return NotFound();
            }

            return View(petFood);
        }

        // GET: PetFoods/Create
        public IActionResult Create()
        {
            ViewData["AnimalId"] = new SelectList(_context.Animal, "AnimalId", "Name");
            return View();
        }

        // POST: PetFoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PetFoodId,Price,Name,Description,NutritionalInformation,Weight,Brand,AnimalId")] PetFood petFood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petFood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal, "AnimalId", "Name", petFood.AnimalId);
            return View(petFood);
        }

        // GET: PetFoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petFood = await _context.PetFood.FindAsync(id);
            if (petFood == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal, "AnimalId", "Name", petFood.AnimalId);
            return View(petFood);
        }

        // POST: PetFoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetFoodId,Price,Name,Description,NutritionalInformation,Weight,Brand,AnimalId")] PetFood petFood)
        {
            if (id != petFood.PetFoodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petFood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetFoodExists(petFood.PetFoodId))
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
            ViewData["AnimalId"] = new SelectList(_context.Animal, "AnimalId", "Name", petFood.AnimalId);
            return View(petFood);
        }

        // GET: PetFoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petFood = await _context.PetFood
                .Include(p => p.PetFoodAnimal)
                .FirstOrDefaultAsync(m => m.PetFoodId == id);
            if (petFood == null)
            {
                return NotFound();
            }

            return View(petFood);
        }

        // POST: PetFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petFood = await _context.PetFood.FindAsync(id);
            _context.PetFood.Remove(petFood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetFoodExists(int id)
        {
            return _context.PetFood.Any(e => e.PetFoodId == id);
        }
    }
}
