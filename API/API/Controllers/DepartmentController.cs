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
        #region Get All
        
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
                StudentsCount = d.Students.Count
            }).ToList();
            return Ok(result);
        }
        #endregion

        #region Get By ID

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
        #endregion

        #region Add
        
        [HttpPost]
        public IActionResult Add(DepartmentCreationDTO dept)
        {
            var _dept = new Department();
            _dept.Name = dept.Name;
            _dept.Location = dept.Location;
            _repo.Add(_dept);
            _repo.Save();
            return CreatedAtAction(nameof(GetById), new { id = _dept.DeptNumber }, _dept);
        }
        #endregion

        #region Update

        [HttpPut("{id}")]
        public IActionResult Update(int id, DepartmentCreationDTO dto)
        {
            var existing = _repo.GetById(id);   // loads dept WITHOUT students
            if (existing == null) return NotFound();

            existing.Name = dto.Name;
            existing.Location = dto.Location;
            // Students collection is never touched — stays exactly as it was in DB

            _repo.Update(existing);
            _repo.Save();
            return NoContent();
        }
        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dept = _repo.GetById(id);
            if (dept == null) return NotFound();
            _repo.Delete(id);
            _repo.Save();
            return Ok(new { msg = "Dept Deleted", data = dept });
        }
        #endregion


    }
}
