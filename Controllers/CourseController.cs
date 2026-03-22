using Microsoft.AspNetCore.Mvc;
using Student4API.Data;
using Student4API.Models;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CoursesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Courses.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var item = _context.Courses.Find(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public IActionResult Create(Course course)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Courses.Add(course);
        _context.SaveChanges();
        return Ok(course);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Course course)
    {
        var existing = _context.Courses.Find(id);
        if (existing == null) return NotFound();

        existing.Code = course.Code;
        existing.Title = course.Title;
        existing.Units = course.Units;

        _context.SaveChanges();
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _context.Courses.Find(id);
        if (item == null) return NotFound();

        _context.Courses.Remove(item);
        _context.SaveChanges();
        return Ok();
    }
}