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
    public class FeedbacksController : Controller
    {
        private readonly ProjectContext _context;
        HttpClient client = new HttpClient();
        string url = "https://localhost:44361/api/Feedbacks";

        public FeedbacksController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Feedbacks
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Feedback.ToListAsync());
            return View(JsonConvert.DeserializeObject<List<Feedback>>(await client.GetStringAsync(url)).ToList());
        }

        // GET: Feedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var feedback = await _context.Feedback
            // .FirstOrDefaultAsync(m => m.Id == id);
            var feedback = JsonConvert.DeserializeObject<Feedback>(await client.GetStringAsync(url + id));
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // GET: Feedbacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Courses,comments,Rating")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                // _context.Add(feedback);
                //await _context.SaveChangesAsync();
                await client.PostAsJsonAsync<Feedback>(url, feedback);
                return RedirectToAction(nameof(Success));
            }
            return View(feedback);
        }
        public IActionResult Success()
        {
            return View();
        }

        // GET: Feedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var feedback = await _context.Feedback.FindAsync(id);
            var feedback = JsonConvert.DeserializeObject<Feedback>(await client.GetStringAsync(url + id));
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Courses,comments,Rating")] Feedback feedback)
        {
            if (id != feedback.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(feedback);
                    //await _context.SaveChangesAsync();
                    await client.PutAsJsonAsync<Feedback>(url + id, feedback);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackExists(feedback.Id))
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
            return View(feedback);
        }

        // GET: Feedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var feedback = await _context.Feedback
            //.FirstOrDefaultAsync(m => m.Id == id);
            var feedback = JsonConvert.DeserializeObject<Feedback>(await client.GetStringAsync(url + id));
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedback = await _context.Feedback.FindAsync(id);
            //_context.Feedback.Remove(feedback);
            //await _context.SaveChangesAsync();
            await client.DeleteAsync(url + id);
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackExists(int id)
        {
            return _context.Feedback.Any(e => e.Id == id);
        }
    }
}
