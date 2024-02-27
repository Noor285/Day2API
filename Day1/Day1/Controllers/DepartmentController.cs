using Day1.Custom_Filter;
using Day1.Custom_Validation;
using Day1.Models;
using Day1.Repositories;
using Day1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        DepartmentRepo deptRepo;

        public DepartmentController(DepartmentRepo departmentRepository)
        {
            deptRepo = departmentRepository;
        }

        // Get All
        [HttpGet ("/api/Departments/Get/")]
        public IActionResult GetAll()
        {
            var departments = deptRepo.GetAll();
            return Ok(departments);
        }

        // Add
        [HttpPost("/api/Departments/Add/")]
        [LocationFilter("USA", "EG")]
        public IActionResult Add([FromBody] Department department)
        {
            if (department == null)
                return BadRequest();

            deptRepo.Add(department);
                return CreatedAtRoute("GetStudentById", new { id = department.Id }, department);
        }

        // Get By ID
        [HttpGet("/api/Departments/Details/{id:int}")]
        public IActionResult GetById(int id)
        {
            var department = deptRepo.GetById(id);
            if (department == null)
            {
                return NotFound(new { message = $"Department with ID = {id} Not found" });
            }
            return Ok(department);
        }

        // Get By Name
        [HttpGet("/api/Departments/Details/{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            var department = deptRepo.GetByName(name);
            if (department == null)
            {
                return NotFound(new { message = $"Department with Name = {name} Not found" });
            }
            return Ok(department);
        }

        // Update
        [HttpPut ("/api/Departments/Update/")]
        [LocationFilter("USA", "EG")]
        public IActionResult Update(Department department)
        {
            if (ModelState.IsValid)
            {
                deptRepo.Update(department);
                return NoContent();
            }
            return BadRequest();
        }

        // Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = deptRepo.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            deptRepo.Delete(id);
            return Ok(department);
        }


    }
}
