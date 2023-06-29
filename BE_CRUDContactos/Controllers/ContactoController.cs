using BE_CRUDContactos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_CRUDContactos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly AplicationDbContext _context; //se decalra una variable que va a ser de tipo lectura

        public ContactoController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() //IActionsresults nos va a permitir trabajar con los distintos estados(200 etc)
        {
            try
            {
                var ListContactos = await _context.Contactos.ToListAsync();
                return Ok(ListContactos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var contacto = await _context.Contactos.FindAsync(id);
                if (contacto == null)
                {
                    return NotFound();
                }
                return Ok(contacto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var contacto = await _context.Contactos.FindAsync(id);

                if (contacto == null)
                {
                    return NotFound();
                }

                _context.Contactos.Remove(contacto);
                await _context.SaveChangesAsync();


                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Contacto contacto) //DTO
        {
            try
            {
                contacto.FechaCreacion = DateTime.Now;
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = contacto.Id }, contacto); //En los metodos post tenemos que devolver un 201
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
