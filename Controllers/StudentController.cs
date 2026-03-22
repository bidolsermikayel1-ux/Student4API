using Microsoft.AspNetCore.Mvc;
using Student4API.Data;
using Student4API.Models;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Students.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var student = _context.Students.Find(id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState); 
        _context.Students.Add(student);
        _context.SaveChanges();
        return Ok(student);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Student student)
    {
        var existing = _context.Students.Find(id);
        if (existing == null) return NotFound();

       
        existing.FirstName = student.FirstName;
        existing.LastName = student.LastName;
        existing.Email = student.Email;

        _context.SaveChanges();
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var student = _context.Students.Find(id);
        if (student == null) return NotFound();

        _context.Students.Remove(student);
        _context.SaveChanges();
        return Ok();
    }
}