using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_test.Data;
using mvc_test.Models;

namespace mvc_test.Controllers
{
    public class select_secController : Controller
    {
        private readonly mvc_testContext _context;

        public select_secController(mvc_testContext context)
        {
            _context = context;
        }

        // GET: select_sec
        public async Task<IActionResult> Index()
        {
            string type = HttpContext.Session.GetString("type");
            if(type == "student"){
                return RedirectToAction("S");
            }
            else if(type == "teacher")
            {
                return View("2");
            }
            return View("3");
           // return View(await _context.select_sec.ToListAsync());
        }

        public async Task<IActionResult> S()
        {
             string num = null;
             string id = HttpContext.Session.GetString("ID");
             var s = from m in _context.student
                         where m.ID == id
                         select m;
             foreach (var u in s)
             {
                 HttpContext.Session.SetString("S_num", u.num);
                 num = u.num;
                 HttpContext.Session.SetString("S_name", u.name);
             }
             
            var select_sec = from m in _context.select_sec
                         select m;

            return View(await select_sec.ToListAsync());
        }

        // GET: select_sec/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            string num = HttpContext.Session.GetString("S_num");
            if (id == null)
            {
                return NotFound();
            }

            var select_sec = await _context.select_sec
                .FirstOrDefaultAsync(m => m.course_id == id && m.S_num == num);
            if (select_sec == null)
            {
                return NotFound();
            }

            return View(select_sec);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( select_sec select_sec)
        {
            if (ModelState.IsValid)
            {
                select_sec.S_num= HttpContext.Session.GetString("S_num");
                select_sec.S_name = HttpContext.Session.GetString("S_name");
                var course = from m in _context.course
                             where m.course_id == select_sec.course_id && m.course_name == select_sec.course_name
                             select m;
                if (course.FirstOrDefault() != null)  //&& (_context.select_sec.Any(u => u.S_num == select_sec.S_num)))
                {

                    _context.Add(select_sec);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                    
                }
                ModelState.AddModelError("course_id", "course_id 或者course_name 输入错误！");
                return View("Create");
            }
            return View(select_sec);
        }

        

        // GET: select_sec/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var select_sec = await _context.select_sec.FindAsync(id);
            if (select_sec == null)
            {
                return NotFound();
            }
            return View(select_sec);
        }

        // POST: select_sec/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("S_num,S_name,course_id,course_name")] select_sec select_sec)
        {
            if (id != select_sec.S_num)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(select_sec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!select_secExists(select_sec.S_num))
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
            return View(select_sec);
        }

        // GET: select_sec/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            string num = HttpContext.Session.GetString("S_num");
            if (id == null)
            {
                return NotFound();
            }

            var select_sec = await _context.select_sec
                .FirstOrDefaultAsync(m => m.course_id == id && m.S_num == num);
            if (select_sec == null)
            {
                return NotFound();
            }

            return View(select_sec);
        }

        // POST: select_sec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            select_sec sec = null;
            string num = HttpContext.Session.GetString("S_num");
            select_sec s = (from m in _context.select_sec
                            where m.course_id == id && m.S_num == num
                            select m).Single();
            _context.select_sec.Remove(s);
            await _context.SaveChangesAsync();
            return RedirectToAction("S");
        }

        private bool select_secExists(string id)
        {
            return _context.select_sec.Any(e => e.S_num == id);
        }
    }
}
