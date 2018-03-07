using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApWebAPIDemo.Models;

namespace WebApWebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    public class StudentInfoController : Controller
    {

        private readonly StudentInfoContext _context;

        public StudentInfoController(StudentInfoContext context)
        {
            _context = context;

            if (_context.StudentInfomations.Count() == 0)
            {
                _context.StudentInfomations.Add(new StudentInfo ());
                _context.SaveChanges();
            }
        }

        // GET api/StudentInfo
        [HttpGet]
        public IEnumerable<StudentInfo> GetAll()
        {
            return _context.StudentInfomations.ToList();
        }

        // GET api/StudentInfo/5
        [HttpGet("{id}", Name ="GetStudent")]
        public IActionResult Get(int id)
        {
            var item = _context.StudentInfomations.FirstOrDefault(t => t.StudentId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/StudentInfo
        [HttpPost]
        public IActionResult Create([FromBody]StudentInfo value)
        {
            if(value == null)
            {
                return BadRequest();
            }
            _context.StudentInfomations.Add(value);
            _context.SaveChanges();
            return CreatedAtRoute("GetStudent", new { id = value.StudentId }, value);
        }

        // PUT api/StudentInfo/6
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]StudentInfo value)
        {
            if (value == null || value.StudentId != id)
            {
                return BadRequest();
            }
            var student = _context.StudentInfomations.FirstOrDefault(t => t.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            student.StudentName = value.StudentName;
            student.Branch = value.Branch;
            student.StartDate = DateTime.Now;
            student.GraduatedDate = student.StartDate.AddYears(4);
            student.EmailId = value.EmailId;
            student.OverallPercentage = value.OverallPercentage;
            _context.StudentInfomations.Update(student);
            _context.SaveChanges();
            return CreatedAtRoute("GetStudent", new { id = value.StudentId }, value);

        }

        // DELETE api/StudentInfo/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Student = _context.StudentInfomations.FirstOrDefault(t => t.StudentId == id);
            if (Student == null)
            {
                return NotFound();
            }

            _context.StudentInfomations.Remove(Student);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
