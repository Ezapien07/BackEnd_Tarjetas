using BackEndFETarjeta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndFETarjeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly AppDBContext _context;
        public TarjetaController(AppDBContext context)
        {
            _context=context;
        }
        // GET: api/<TarjetaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lstTarjetas = await _context.tarjetaCredito.ToListAsync();
                return Ok(lstTarjetas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TarjetaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var tarjeta = await _context.tarjetaCredito.FindAsync(id);
                if (tarjeta != null)
                {
                    return Ok(tarjeta);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TarjetaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TarjetaCredito tcredito)
        {
            try
            {
                _context.Add(tcredito);
                await  _context.SaveChangesAsync();
                return Ok(tcredito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TarjetaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TarjetaCredito tcredito)
        {
            try
            {
                if (id != tcredito.id)
                {
                    return NotFound();
                }
                _context.Update(tcredito);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Se actualizo correctamente la tarjeta" });

            } catch (Exception ex) {
                return BadRequest(ex.Message);
                    }
        }

        // DELETE api/<TarjetaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarjeta = await _context.tarjetaCredito.FindAsync(id);
                if (tarjeta != null)
                {
                    _context.Remove(tarjeta);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Tarjeta Elminada con exito" });
                }
                else
                {
                    return BadRequest();
                }

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
