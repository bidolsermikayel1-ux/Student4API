using Microsoft.AspNetCore.Mvc;
using Student4API.Data;
using Student4API.Models;


[ApiController]
[Route("api/[controller]")]
public class SectionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public SectionsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Sections.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var item = _context.Sections.Find(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public IActionResult Create(Section section)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Sections.Add(section);
        _context.SaveChanges();
        return Ok(section);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Section section)
    {
        var existing = _context.Sections.Find(id);
        if (existing == null) return NotFound();

        existing.SectionCode = section.SectionCode;
        existing.CourseId = section.CourseId;
        existing.InstructorId = section.InstructorId;
        existing.Room = section.Room;
        existing.Schedule = section.Schedule;

        _context.SaveChanges();
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _context.Sections.Find(id);
        if (item == null) return NotFound();

        _context.Sections.Remove(item);
        _context.SaveChanges();
        return Ok();
    }
}