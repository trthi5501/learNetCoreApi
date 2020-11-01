using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interface;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentInterface _studentService;

        public StudentController(IStudentInterface studentservice)
        {
            _studentService = studentservice;
        }
        
        // GET: api/Student
        [HttpGet]
        public List<Student> Get()
        {
            var student = _studentService.GetAll();
            return student;
        }

        // GET: api/Student/5
        [Authorize(Policy = "ApiUser")]
        [HttpGet("{id}", Name = "Get")]
        public List<Student> Get(string id)
        {
            var student = _studentService.GetSID(id);

            return student;
        }

        // POST: api/Student
        
        [HttpPost]
        public IActionResult Post([FromBody] Student std)
        {
            var token = _studentService.Authenticate(std.SID);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
