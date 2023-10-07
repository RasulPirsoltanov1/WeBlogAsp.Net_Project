using BlogSite.Api.Context;
using BlogSite.Api.Context.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;

namespace BlogSite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public ApiDbContext _context;

        public EmployeeController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _context.Employees;
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            var employees = _context.Employees;
            return StatusCode((int)HttpStatusCode.Created, employees);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == Id);
            return StatusCode((int)HttpStatusCode.Found, employee);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == Id);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return StatusCode((int)HttpStatusCode.OK);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Employee employee)
        {
            var dbEmployee = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == employee.Id);
            if (dbEmployee != null)
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }
            return StatusCode((int)HttpStatusCode.Created, employee);
        }
    }
}
