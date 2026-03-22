using Microsoft.AspNetCore.Mvc;
using Student4API.Data;
using Student4API.Models;

[ApiController]
[Route("api/[controller]")]
public class EnrollmentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public EnrollmentsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Enrollments.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var item = _context.Enrollments.Find(id);
        if (item == null) return NotFound();
        return Ok(item);
    }
    [HttpGet("byStudent/{studentId}")]
    public IActionResult GetByStudent(int studentId)
    {
        var list = _context.Enrollments
            .Where(e => e.StudentId == studentId)
            .ToList();
        return Ok(list);
    }

    [HttpPost]
    public IActionResult Create(Enrollment enrollment)
    {
        _context.Enrollments.Add(enrollment);
        _context.SaveChanges();
        return Ok(enrollment);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Enrollment enrollment)
    {
        var existing = _context.Enrollments.Find(id);
        if (existing == null) return NotFound();

        existing.StudentId = enrollment.StudentId;
        existing.CourseId = enrollment.CourseId;
        existing.Semester = enrollment.Semester;
        existing.Grade = enrollment.Grade;

        _context.SaveChanges();
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _context.Enrollments.Find(id);
        if (item == null) return NotFound();

        _context.Enrollments.Remove(item);
        _context.SaveChanges();
        return Ok();
    }

}  