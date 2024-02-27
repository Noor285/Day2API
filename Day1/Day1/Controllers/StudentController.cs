using Day1.Models;
using Day1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentRepo studentRepo;

        public StudentController(StudentRepo studentRepository)
        {
            studentRepo = studentRepository;
        }

        // GET: api/student
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = studentRepo.GetAll();
            return Ok(students);
        }

        [HttpPost("/api/Students/Add/")]
        public IActionResult Add([FromBody] Student student)
        {
            if (student == null)
                return BadRequest();

            studentRepo.Add(student);
            return CreatedAtRoute("GetStudentById", new { id = student.Id }, student);
        }


        [HttpGet("/api/Students/Details/{id}", Name = "GetStudentById")]
        public IActionResult GetById(int id)
        {
            var student = studentRepo.GetById(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpGet("/api/Students/Details/{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            var student = studentRepo.GetByName(name);
            if (student == null)
                return NotFound();
            return Ok(student);
        }


        [HttpPut("/api/Students/Update/{id}")]
        public IActionResult update(int id, Student std)
        {

            if (ModelState.IsValid)
            {
                studentRepo.Update(id, std);

                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("/api/Students/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var student = studentRepo.GetById(id);
            if (student == null)
                return NotFound();

            studentRepo.Delete(id);
            return Ok(student);
        }


    }
}
