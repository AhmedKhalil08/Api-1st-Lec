using API.Models;
using API.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentRepository studentrepo;
        public StudentController(IStudentRepository _studentrepo)
        {
            studentrepo = _studentrepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = studentrepo.GetAll();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = studentrepo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            studentrepo.Add(student);
            studentrepo.Save();
            return CreatedAtAction(nameof(GetById), new { id = student.SSN }, student);
        }
        [HttpPut]
        public IActionResult Update(Student student)
        {
            studentrepo.Update(student);
            studentrepo.Save();
            return Ok(new { msg = "Student Updated", student });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var std = studentrepo.GetById(id);
            studentrepo.Delete(id);
            studentrepo.Save();
            return Ok(new {msg="Student Deleted",data = std });
        }
    }
}
