using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly ProjectContext _context;
        HttpClient client = new HttpClient();
        string url = "https://localhost:44361/api/Payments";

        public PaymentsController(ProjectContext context)
        {
            _context = context;
        }

        public ActionResult PaidCourses()
        {
            return View();
        }
        // GET: Payments
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Payments.ToListAsync());
            return View(JsonConvert.DeserializeObject<List<Payments>>(await client.GetStringAsync(url)).ToList());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var payments = await _context.Payments
            // .FirstOrDefaultAsync(m => m.Id == id);
            var payments = JsonConvert.DeserializeObject<Feedback>(await client.GetStringAsync(url + id));
            if (payments == null)
            {
                return NotFound();
            }

            return View(payments);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subscription,CardNumber,Amount,CVV,ExpiryDate")] Payments payments)
        {
            if (ModelState.IsValid)
            {
               //_context.Add(payments);
               // await _context.SaveChangesAsync();
                await client.PostAsJsonAsync<Payments>(url, payments);
                //return RedirectToAction(nameof(Index));
            }
            //return View(payments);
            if (payments.Amount == 199)
            {
                return RedirectToRoute(new { controller = "Basic", action = "HTML" });
            }
            else if (payments.Amount == 399)
            {
                return RedirectToRoute(new { controller = "Standard", action = "HTML" });
            }
            else
            {
                return RedirectToRoute(new { controller = "Premium", action = "HTML" });
            }

        }
       /* public IActionResult Basic()
        {
            return View();
        }
        public IActionResult Standard()
        {
            return View();
        }
        public IActionResult Premium()
        {
            return View();
        }*/

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var payments = await _context.Payments.FindAsync(id);
            var payments = JsonConvert.DeserializeObject<Payments>(await client.GetStringAsync(url + id));
            if (payments == null)
            {
                return NotFound();
            }
            return View(payments);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subscription,CardNumber,Amount,CVV,ExpiryDate")] Payments payments)
        {
            if (id != payments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // _context.Update(payments);
                    // await _context.SaveChangesAsync();
                    await client.PutAsJsonAsync<Payments>(url + id, payments);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentsExists(payments.Id))
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
            return View(payments);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var payments = await _context.Payments
            // .FirstOrDefaultAsync(m => m.Id == id);
            var payments = JsonConvert.DeserializeObject<Payments>(await client.GetStringAsync(url + id));
            if (payments == null)
            {
                return NotFound();
            }

            return View(payments);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payments = await _context.Payments.FindAsync(id);
            //_context.Payments.Remove(payments);
            //await _context.SaveChangesAsync();
            await client.DeleteAsync(url + id);
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentsExists(int id)
        {
            return _context.Payments.Any(e => e.Id == id);
        }
    }
}
