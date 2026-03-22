using Microsoft.AspNetCore.Mvc;
using Student4API.Data;
using Student4API.Models;

[ApiController]
[Route("api/[controller]")]
public class InstructorsController : ControllerBase
{
    private readonly AppDbContext _context;

    public InstructorsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Instructors.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var item = _context.Instructors.Find(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public IActionResult Create(Instructor instructor)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Instructors.Add(instructor);
        _context.SaveChanges();
        return Ok(instructor);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Instructor instructor)
    {
        var existing = _context.Instructors.Find(id);
        if (existing == null) return NotFound();

        existing.EmployeeNo = instructor.EmployeeNo;
        existing.FirstName = instructor.FirstName;
        existing.LastName = instructor.LastName;
        existing.Email = instructor.Email;
        existing.DepartmentId = instructor.DepartmentId;

        _context.SaveChanges();
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _context.Instructors.Find(id);
        if (item == null) return NotFound();

        _context.Instructors.Remove(item);
        _context.SaveChanges();
        return Ok();
    }
}