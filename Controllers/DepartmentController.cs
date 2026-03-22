using Microsoft.AspNetCore.Mvc;
using Student4API.Data;
using Student4API.Models;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public DepartmentsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Departments.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {

        var item = _context.Departments.Find(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public IActionResult Create(Department dept)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Departments.Add(dept);
        _context.SaveChanges();
        return Ok(dept);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Department dept)
    {
        var existing = _context.Departments.Find(id);
        if (existing == null) return NotFound();

        existing.Code = dept.Code;
        existing.Name = dept.Name;
        existing.Office = dept.Office;

        _context.SaveChanges();
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _context.Departments.Find(id);
        if (item == null) return NotFound();

        _context.Departments.Remove(item);
        _context.SaveChanges();
        return Ok();
    }
}