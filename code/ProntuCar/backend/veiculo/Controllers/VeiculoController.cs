using Data;
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace csharp_crud_api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VeiculoController : ControllerBase
{
    private readonly VeiculoContext _context;

    public VeiculoController(VeiculoContext context)
    {
        _context = context;
    }

    // GET: api/veiculo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculo()
    {
        return await _context.Veiculos.ToListAsync();
    }

    // GET: api/veiculo/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Veiculo>> GetVeiculo(int id)
    {
        var veiculo = await _context.Veiculos.FindAsync(id);

        if (veiculo == null)
        {
            return NotFound();
        }

        return veiculo;
    }

    // POST: api/veiculo
    [HttpPost]
    public async Task<ActionResult<Veiculo>> CreateVeiculo(Veiculo veiculo)
    {
        _context.Veiculos.Add(veiculo);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVeiculo", new { id = veiculo.Id }, veiculo);
    }

    // PUT: api/veiculo/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVeiculo(int id, Veiculo veiculo)
    {
        if (id != veiculo.Id)
        {
            return BadRequest();
        }

        _context.Entry(veiculo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VeiculoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/veiculos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVeiculo(int id)
    {
        var veiculo = await _context.Veiculos.FirstOrDefaultAsync(v => v.Id == id);

        if (veiculo == null)
        {
            return NotFound();
        }

        _context.Veiculos.Remove(veiculo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VeiculoExists(int id)
    {
        return _context.Veiculos.Any(v => v.Id == id);
    }

    // Dummy method to test the connection
    [HttpGet("hello")]
    public string Test()
    {
        return "Hello World!";
    }
}
