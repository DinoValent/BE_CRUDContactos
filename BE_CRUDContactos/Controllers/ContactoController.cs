using AutoMapper;
using BE_CRUDContactos.Models;
using BE_CRUDContactos.Models.DTO;
using BE_CRUDContactos.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_CRUDContactos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
         //se decalra una variable que va a ser de tipo lectura
        private readonly IMapper _mapper;
        private readonly IContactoRepository _contactoRepository;
        public ContactoController( IMapper mapper, IContactoRepository contactoRepository) //Inyeccion de dependencia
        {
            _contactoRepository = contactoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get() //IActionsresults nos va a permitir trabajar con los distintos estados(200 etc)
        {
            try
            {
                var ListContactos = await _contactoRepository.GetListContactos();
                var ListContactosDto = _mapper.Map<IEnumerable<ContactoDTO>>(ListContactos);
                return Ok(ListContactosDto);
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
                var contacto = await _contactoRepository.GetContacto(id);
                if (contacto == null)
                {
                    return NotFound();
                }

                var contactoDto = _mapper.Map<ContactoDTO>(contacto);

                return Ok(contactoDto);
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
                var contacto = await _contactoRepository.GetContacto(id);

                if (contacto == null)
                {
                    return NotFound();
                }

                await _contactoRepository.DeleteContacto(contacto);


                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(ContactoDTO contactoDto) //DTO
        {
            try
            {

                var contacto = _mapper.Map<Contacto>(contactoDto);
                contacto.FechaCreacion = DateTime.Now;
                contacto= await _contactoRepository.AddContacto(contacto);
                var contactoItemDto = _mapper.Map<ContactoDTO>(contacto);
                return CreatedAtAction("Get", new { id = contactoItemDto.Id }, contactoItemDto); //En los metodos post tenemos que devolver un 201
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ContactoDTO contactoDto)
        {
            try
            {
                var contacto = _mapper.Map<Contacto>(contactoDto);
                if (id != contacto.Id)
                {
                    return BadRequest();
                }

                var contactoItem = await _contactoRepository.GetContacto(id);

                if (contactoItem == null)
                {
                    return NotFound();
                }

                await _contactoRepository.UpdateContacto(contacto);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
