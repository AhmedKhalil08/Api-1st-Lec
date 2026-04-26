using API.DTO;
using API.Models;
using API.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentRepository _repo;
        public DepartmentController(IDepartmentRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var depts = _repo.GetAllWithDetails();
            var result = depts.Select(d => new DepartmentDTO
            {
                DeptNumber = d.DeptNumber,
                Name = d.Name,
                Location = d.Location,
                Students = d.Students.Select(s => s.Name).ToList(),
                StudentsCount=d.Students.Select(s=>s.Name).Count()
            });
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var dept = _repo.GetById(id);
            if (dept == null)
            {
                return NotFound();
            }
            return Ok(dept);
        }
        [HttpPost]
        public IActionResult Add(Department dept)
        {
            _repo.Add(dept);
            _repo.Save();
            return CreatedAtAction(nameof(GetById), new { id = dept.DeptNumber }, dept);
        }
        [HttpPut]
        public IActionResult Update(Department dept)
        {
            _repo.Update(dept);
            _repo.Save();
            return Ok(new { msg = "Department Updated", dept });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dept = _repo.GetById(id);
            _repo.Delete(id);
            _repo.Save();
            return Ok(new { msg = "Dept Deleted", data = dept });
        }



    }
}
