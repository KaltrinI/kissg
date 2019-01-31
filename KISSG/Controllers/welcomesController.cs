using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KISSG.Context;
using KISSG.Templates.OnePageSite;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

namespace KISSG.Controllers
{
    public class welcomesController : Controller
    {
        private readonly welcomeContext _context;

        public welcomesController(welcomeContext context)
        {
            _context = context;
        }

        // GET: welcomes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Welcomes.ToListAsync());
        }

        // GET: welcomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welcome = await _context.Welcomes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (welcome == null)
            {
                return NotFound();
            }

            return View(welcome);
        }

        // GET: welcomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: welcomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstSectionColor,LogoUrl,Motto,MottoColor,MainSectionBgColor,MainSectionTxtColor,MainSection,PictureUrl,Projects,ContactSectionBgColor,ContactSectionTxtColor,Email,Phone,Address")] welcome welcome)
        {
            if (ModelState.IsValid)
            {
                String pageContent = welcome.TransformText();
                System.IO.File.WriteAllText("outputPage.html", pageContent);

                Response.Clear();
                Response.Headers.Clear();
                Response.Headers.Add("Content-Disposition", "attachment; filename=outputPage.html");
                Response.Headers.Add("Content-Length", pageContent.Length.ToString());
                Response.ContentType = "text/plain";
                await Response.SendFileAsync("outputPage.html");
            }
            
            return View(welcome);
        }

        // GET: welcomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welcome = await _context.Welcomes.FindAsync(id);
            if (welcome == null)
            {
                return NotFound();
            }
            return View(welcome);
        }

        // POST: welcomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstSectionColor,LogoUrl,Motto,MottoColor,MainSectionBgColor,MainSectionTxtColor,MainSection,PictureUrl,Projects,ContactSectionBgColor,ContactSectionTxtColor,Email,Phone,Address")] welcome welcome)
        {
            if (id != welcome.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(welcome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!welcomeExists(welcome.Id))
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
            return View(welcome);
        }

        // GET: welcomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welcome = await _context.Welcomes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (welcome == null)
            {
                return NotFound();
            }

            return View(welcome);
        }

        // POST: welcomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var welcome = await _context.Welcomes.FindAsync(id);
            _context.Welcomes.Remove(welcome);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool welcomeExists(int id)
        {
            return _context.Welcomes.Any(e => e.Id == id);
        }
    }
}
