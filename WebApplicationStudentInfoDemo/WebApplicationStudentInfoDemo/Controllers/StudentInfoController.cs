using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationStudentInfoDemo.Models;

namespace WebApplicationStudentInfoDemo.Controllers
{
    public class StudentInfoController : Controller
    {
        private readonly StudentInfoDBContext _context;

        public StudentInfoController(StudentInfoDBContext context)
        {
            _context = context;
        }

        // GET: StudentInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentInfomations.ToListAsync());
        }

        // GET: StudentInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInfo = await _context.StudentInfomations
                .SingleOrDefaultAsync(m => m.StudentId == id);
            if (studentInfo == null)
            {
                return NotFound();
            }

            return View(studentInfo);
        }

        // GET: StudentInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,Branch,StartDate,GraduatedDate,OverallPercentage,EmailId")] StudentInfo studentInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentInfo);
        }

        // GET: StudentInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInfo = await _context.StudentInfomations.SingleOrDefaultAsync(m => m.StudentId == id);
            if (studentInfo == null)
            {
                return NotFound();
            }
            return View(studentInfo);
        }

        // POST: StudentInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,Branch,StartDate,GraduatedDate,OverallPercentage,EmailId")] StudentInfo studentInfo)
        {
            if (id != studentInfo.StudentId)
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
                    if (!StudentInfoExists(studentInfo.StudentId))
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

        // GET: StudentInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInfo = await _context.StudentInfomations
                .SingleOrDefaultAsync(m => m.StudentId == id);
            if (studentInfo == null)
            {
                return NotFound();
            }

            return View(studentInfo);
        }

        // POST: StudentInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentInfo = await _context.StudentInfomations.SingleOrDefaultAsync(m => m.StudentId == id);
            _context.StudentInfomations.Remove(studentInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentInfoExists(int id)
        {
            return _context.StudentInfomations.Any(e => e.StudentId == id);
        }
    }
}
