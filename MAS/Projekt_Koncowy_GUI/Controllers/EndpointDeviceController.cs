using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_Koncowy_GUI.Models;

namespace Projekt_Koncowy_GUI.Controllers
{
    public class EndpointDeviceController : Controller
    {
        private readonly LocalContext _context;

        public EndpointDeviceController(LocalContext context)
        {
            _context = context;
        }

        // GET: EndpointDevice
        public async Task<IActionResult> Index()
        {
            return View(await _context.EndpointDevices.ToListAsync());
        }
        public async Task<IActionResult> Test(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endpointDevice = await _context.EndpointDevices
             .FirstOrDefaultAsync(m => m.Identifier == id);
            if (endpointDevice == null)
            {
                return NotFound();
            }

            endpointDevice.Tested = Tested.Tak;
            endpointDevice.TestResult = TestResult.Negatywny;

            if (await _context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("Index");
            }

            return BadRequest("Coś poszło nie tak.");
        }
        public async Task<IActionResult> TestSucceed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endpointDevice = await _context.EndpointDevices
             .FirstOrDefaultAsync(m => m.Identifier == id);
            if (endpointDevice == null)
            {
                return NotFound();
            }

            endpointDevice.Tested = Tested.Tak;
            endpointDevice.TestResult = TestResult.Pozytywny;

            if ( await _context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("Index");
            }

            return BadRequest("Coś poszło nie tak.");
        }

        public async Task<IActionResult> TestFailed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endpointDevice = await _context.EndpointDevices
             .FirstOrDefaultAsync(m => m.Identifier == id);
            if (endpointDevice == null)
            {
                return NotFound();
            }

            return View(endpointDevice);
        }

        // GET: EndpointDevice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endpointDevice = await _context.EndpointDevices
                .FirstOrDefaultAsync(m => m.Identifier == id);
            if (endpointDevice == null)
            {
                return NotFound();
            }

            return View(endpointDevice);
        }

        // GET: EndpointDevice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EndpointDevice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identifier,DateOfProduction,Model,Tested,TestResult,Gauge")] EndpointDevice endpointDevice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(endpointDevice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(endpointDevice);
        }

        // GET: EndpointDevice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endpointDevice = await _context.EndpointDevices.FindAsync(id);
            if (endpointDevice == null)
            {
                return NotFound();
            }
            return View(endpointDevice);
        }

        // POST: EndpointDevice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identifier,DateOfProduction,Model,Tested,TestResult,Gauge")] EndpointDevice endpointDevice)
        {
            if (id != endpointDevice.Identifier)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(endpointDevice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EndpointDeviceExists(endpointDevice.Identifier))
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
            return View(endpointDevice);
        }

        // GET: EndpointDevice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endpointDevice = await _context.EndpointDevices
                .FirstOrDefaultAsync(m => m.Identifier == id);
            if (endpointDevice == null)
            {
                return NotFound();
            }

            return View(endpointDevice);
        }

        // POST: EndpointDevice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var endpointDevice = await _context.EndpointDevices.FindAsync(id);
            _context.EndpointDevices.Remove(endpointDevice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EndpointDeviceExists(int id)
        {
            return _context.EndpointDevices.Any(e => e.Identifier == id);
        }
    }
}
