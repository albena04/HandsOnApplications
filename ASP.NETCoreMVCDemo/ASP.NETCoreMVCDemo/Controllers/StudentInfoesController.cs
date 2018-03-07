using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NETCoreMVCDemo.Models;

namespace ASP.NETCoreMVCDemo.Controllers
{
    public class StudentInfoesController : Controller
    {
        private readonly AAAFamilyDBContext _context;

        public StudentInfoesController(AAAFamilyDBContext context)
        {
            _context = context;
        }

        // GET: StudentInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentInfo.ToListAsync());
        }

        // GET: StudentInfoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInfo = await _context.StudentInfo
                .SingleOrDefaultAsync(m => m.studentid == id);
            if (studentInfo == null)
            {
                return NotFound();
            }

            return View(studentInfo);
        }

        // GET: StudentInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("studentid,studentname,branchname,startdate,gpapercentage,emailid")] StudentInfo studentInfo)
        {
            if (ModelState.IsValid)
            {
                studentInfo.studentid = Guid.NewGuid();
                _context.Add(studentInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentInfo);
        }

        // GET: StudentInfoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInfo = await _context.StudentInfo.SingleOrDefaultAsync(m => m.studentid == id);
            if (studentInfo == null)
            {
                return NotFound();
            }
            return View(studentInfo);
        }

        // POST: StudentInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("studentid,studentname,branchname,startdate,gpapercentage,emailid")] StudentInfo studentInfo)
        {
            if (id != studentInfo.studentid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentInfoExists(studentInfo.studentid))
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
            return View(studentInfo);
        }

        // GET: StudentInfoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInfo = await _context.StudentInfo
                .SingleOrDefaultAsync(m => m.studentid == id);
            if (studentInfo == null)
            {
                return NotFound();
            }

            return View(studentInfo);
        }

        // POST: StudentInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var studentInfo = await _context.StudentInfo.SingleOrDefaultAsync(m => m.studentid == id);
            _context.StudentInfo.Remove(studentInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentInfoExists(Guid id)
        {
            return _context.StudentInfo.Any(e => e.studentid == id);
        }
    }
}
