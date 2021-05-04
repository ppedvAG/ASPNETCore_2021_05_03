using EFCoreWithMVC.Data;
using EFCoreWithMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreWithMVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonDBContext _context;

        public PersonController(PersonDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Persons.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            //Task<Person> retTask = _context.Persons.FirstOrDefaultAsync(m => m.Id == id);
            //retTask.Wait();

            Person person = await _context.Persons.FirstOrDefaultAsync(m => m.Id == id);

            return View(person);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Wenn Create(Get-Methode) und Create (Post-Methode), den selben Namen haben
        // Muss ValidateAntiForgeryToken mit angegeben werden -> ValidateAntiForgeryToken hilft gegenüber CrossSiteAttacks
        public async Task <IActionResult> Create(Person person)
        {
            //ModelState.AddModelError("PersonenObj", "Kombination der Wert im Objekt, machen das Objekt unverndbar");

            //serverseitige Validierung
            if (ModelState.IsValid)
            {
                
                _context.Persons.Add(person);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }


        // Get: localhost:12345/Person/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            Person person = await _context.Persons.FindAsync(id);

            if (person == null)
                return NotFound();

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Person person)
        {
            if (id != person.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                   if (!PersonExists(person.Id))
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
            return View(person);
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }

        
        //Get-Methoden um den Datensatz vor dem löschen nochmal darzustellen
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            Person person = await _context.Persons.FirstOrDefaultAsync(m => m.Id == id);

            if (person == null)
                return NotFound();

            return View(person);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Person person = await _context.Persons.FindAsync(id);
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
