using AutoMapper;
using BE_CRUDContactos.Models;
using BE_CRUDContactos.Models.DTO;
using BE_CRUDContactos.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_CRUDUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IContactRepository _contactRepository;

        public UserController(IMapper mapper, IUserRepository userRepository, IContactRepository contactRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _userRepository.GetListUsers();
                var usersDto = _mapper.Map<IEnumerable<UserDTO>>(users);
                return Ok(usersDto);
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
                var user = await _userRepository.GetUser(id);
                if (user == null)
                {
                    return NotFound();
                }

                var userDto = _mapper.Map<UserDTO>(user);

                return Ok(userDto);
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
                var user = await _userRepository.GetUser(id);

                if (user == null)
                {
                    return NotFound();
                }

                await _userRepository.DeleteUser(user);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(InputUserDTO userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                user = await _userRepository.AddUser(user);
                var userItemDto = _mapper.Map<UserDTO>(user);
                return CreatedAtAction(nameof(Get), new { id = user.Id }, userItemDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,  InputUserDTO userDto)
        {
            
            var existingUser = await _userRepository.GetUser(id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            try
            {
                _mapper.Map(userDto, existingUser); 
                await _userRepository.UpdateUser(existingUser);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{userId}/favourites")]
        public async Task<IActionResult> AddToFavourites(int userId, [FromBody] InputContactDTO contactDto)
        {
            var user = await _userRepository.GetUser(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            try
            {
                contactDto.UserId = userId; 
                var contact = await _contactRepository.AddContact(contactDto);
               // await _contactRepository.AddToFavouriteContacts(contact.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}/favourites")]
        public async Task<IActionResult> GetFavourites(int userId)
        {
            try
            {
                var favouriteContacts = await _contactRepository.GetFavouriteContactsByUserId(userId);
                var favouriteContactsDto = _mapper.Map<IEnumerable<ContactDTO>>(favouriteContacts);
                return Ok(favouriteContactsDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{userId}/favourites")]
        public async Task<IActionResult> RemoveFromFavourites(int userId, [FromBody] int contactId)
        {
            var user = await _userRepository.GetUser(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            try
            {
                var contact = await _contactRepository.GetContactByUserIdAndContactId(userId, contactId);
                if (contact == null)
                {
                    return NotFound("Contact not found.");
                }

                await _contactRepository.DeleteContact(contactId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}