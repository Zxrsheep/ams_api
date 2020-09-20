using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_test.Data;
using mvc_test.Models;

namespace mvc_test.Controllers
{
    public class coursesController : Controller
    {
        // GET: coursesController
        private readonly mvc_testContext _context;
        public coursesController(mvc_testContext context)
        {
            _context = context;
        }

        // GET: courses
        public async Task<IActionResult> Index(string searchString)
        {

            var course = from m in _context.course
                         select m;

            if (!String.IsNullOrEmpty(searchString))
             {
                 course = course.Where(s => s.course_name.Contains(searchString));

             }

            return View(await course.ToListAsync());
        }


        // GET: courses/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.course
                .FirstOrDefaultAsync(m => m.course_id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: courses/Create
        public IActionResult Create()
        {
            string type = HttpContext.Session.GetString("type");
            if (type == "student")
            {
                return View("2");
            }
            else if (type == "teacher")
            {
                return View("Create");
            }
            return View("3");
        }
        // POST: courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(course course)
        {
            if (ModelState.IsValid)
            {
                if (_context.course.Any(u => u.course_id == course.course_id))
                {
                    ModelState.AddModelError("course_id", "course_id is already  used!!!");
                    return View("Create");
                }
                if (!(_context.teacher.Any(u => u.num != course.T_num)))
                {
                    ModelState.AddModelError("T_num", "T_num no exist!");
                    return View("Create");
                }
                _context.Add(course);
                _context.SaveChanges();

                HttpContext.Session.SetInt32("course_id", course.course_id);

                return View("Create_sec");
            }
            return View("Create");
        }

        public IActionResult Create_sec()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create_sec(section section,classroom_info classroom_info)
        {
            if (ModelState.IsValid)
            {
                section.course_id = (int)HttpContext.Session.GetInt32("course_id");
                if (_context.section.Any(u => u.sec_id == section.sec_id))
                {
                    ModelState.AddModelError("sec_id", "sec_id already in use!!!");
                    return View("Create_sec");
                }

                HttpContext.Session.SetString("time_slot_id", section.time_slot_id);
                classroom_info.classroom_id = section.classroom_id;

                _context.Add(classroom_info);
                _context.Add(section);
                _context.SaveChanges();
                return RedirectToAction("Create_time");
            }
            return View("Create_sec");
        }
        public IActionResult Create_time()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create_time(time_slot time_slot)
        {
            if (ModelState.IsValid)
            {
                time_slot.time_slot_id = HttpContext.Session.GetString("time_slot_id");
                _context.Add(time_slot);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("Create_time");
        }

       /* public async Task<IActionResult> Create_class([Bind("classroom_id")] classroom_info classroom_info)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classroom_info);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }*/



        // GET: courses/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("course_id,course_name,T_num")] course course)
        {
            if (id != course.course_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!courseExists(course.course_id))
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
            return View(course);
        }

        // GET: courses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.course
                .FirstOrDefaultAsync(m => m.course_id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.course.FindAsync(id);
            _context.course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool courseExists(int id)
        {
            return _context.course.Any(e => e.course_id == id);
        }
    }
}
