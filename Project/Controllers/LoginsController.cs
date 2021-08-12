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
    public class LoginsController : Controller
    {
        private readonly ProjectContext _context;

        HttpClient client = new HttpClient();
        string url = "https://localhost:44361/api/Logins";
        public LoginsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Logins
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Login.ToListAsync());
            return View(JsonConvert.DeserializeObject<List<Login>>(await client.GetStringAsync(url)).ToList());
        }

        // GET: Logins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var login = await _context.Login
            //.FirstOrDefaultAsync(m => m.Id == id);
            var login = JsonConvert.DeserializeObject<Login>(await client.GetStringAsync(url + id));
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: Logins/Create
        public IActionResult LCreate()
        {
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /*public async Task<IActionResult> LCreate([Bind("Username,Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                // _context.Add(login);
                //await _context.SaveChangesAsync();
                await client.PostAsJsonAsync<Login>(url, login);
                return RedirectToAction(nameof(Success));
            }
            return View(login);
        }*/
        public async Task<IActionResult> LCreate(string Username, string Password)
        {
            var items = (JsonConvert.DeserializeObject<List<Login>>(await client.GetStringAsync(url)).ToList().Where(m => m.Username == Username && m.Password == Password));

            if (items.Count()!=0)
            {
                return RedirectToAction(nameof(Success));
               
            }
            else
            {
                return RedirectToAction(nameof(Invalid));
            }

        }
        public IActionResult Invalid()
        {
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }

        // GET: Logins/Create
        public IActionResult RCreate()
        {
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RCreate([Bind("Id,Name,Email,Gender,Qualification,Username,Password,ConfirmPassword")] Login login)
        {
            if (ModelState.IsValid)
            {
                // _context.Add(login);
                //await _context.SaveChangesAsync();
                await client.PostAsJsonAsync<Login>(url, login);
                return RedirectToAction(nameof(LCreate));
            }
            
            return View(login);
        }

        // GET: Logins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var login = await _context.Login.FindAsync(id);
            var login = JsonConvert.DeserializeObject<Login>(await client.GetStringAsync(url + id));
            if (login == null)
            {
                return NotFound();
            }
            return View(login);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Gender,Qualification,Username,Password,ConfirmPassword")] Login login)
        {
            if (id != login.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // _context.Update(login);
                    //await _context.SaveChangesAsync();
                    await client.PutAsJsonAsync<Login>(url + id, login);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginExists(login.Id))
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
            return View(login);
        }

        // GET: Logins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var login = await _context.Login
            //.FirstOrDefaultAsync(m => m.Id == id);
            var login = JsonConvert.DeserializeObject<Login>(await client.GetStringAsync(url + id));
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // var login = await _context.Login.FindAsync(id);
            // _context.Login.Remove(login);
            //await _context.SaveChangesAsync();
            await client.DeleteAsync(url + id);
            return RedirectToAction(nameof(Index));
        }

        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.Id == id);
        }
    }
}
