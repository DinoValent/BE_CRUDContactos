using AutoMapper;
using BE_CRUDContactos.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_CRUDContactos.Models.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;

        public ContactRepository(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ContactDTO>> GetAllContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return _mapper.Map<List<ContactDTO>>(contacts);
        }

        public async Task<ContactDTO> GetContactById(int contactId)
        {
            var contact = await _context.Contacts.FindAsync(contactId);
            return _mapper.Map<ContactDTO>(contact);
        }

        public async Task<Contact> AddContact(InputContactDTO contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task DeleteContact(int contactId)
        {
            var contact = await _context.Contacts.FindAsync(contactId);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ContactDTO>> GetFavouriteContacts()
        {
            var favouriteContacts = await _context.Contacts.Where(c => c.IsFavourite).ToListAsync();
            return _mapper.Map<List<ContactDTO>>(favouriteContacts);
        }

        public async Task<ContactDTO> GetFavouriteContactByContactId(int contactId)
        {
            var favouriteContact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == contactId && c.IsFavourite);
            return _mapper.Map<ContactDTO>(favouriteContact);
        }

        public async Task AddToFavouriteContacts(int contactId)
        {
            var contact = await _context.Contacts.FindAsync(contactId);
            if (contact != null)
            {
                contact.IsFavourite = true;
                _context.Contacts.Update(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromFavouriteContacts(int contactId)
        {
            var contact = await _context.Contacts.FindAsync(contactId);
            if (contact != null)
            {
                contact.IsFavourite = false;
                _context.Contacts.Update(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteContact(Contact contact)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ContactDTO>> GetContactsByUserId(int userId)
        {
            var contacts = await _context.Contacts.Where(c => c.UserId == userId).ToListAsync();
            return _mapper.Map<IEnumerable<ContactDTO>>(contacts);
        }

        public async Task<IEnumerable<ContactDTO>> GetFavouriteContactsByUserId(int userId)
        {
            var favouriteContacts = await _context.Contacts.Where(c => c.UserId == userId && c.IsFavourite).ToListAsync();
            return _mapper.Map<IEnumerable<ContactDTO>>(favouriteContacts);
        }

        public async Task<ContactDTO> GetContactByUserIdAndContactId(int userId, int contactId)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.UserId == userId && c.Id == contactId);
            return _mapper.Map<ContactDTO>(contact);
        }

        public async Task<ContactDTO> GetFavouriteContactByUserIdAndContactId(int userId, int contactId)
        {
            var favouriteContact = await _context.Contacts.FirstOrDefaultAsync(c => c.UserId == userId && c.Id == contactId && c.IsFavourite);
            return _mapper.Map<ContactDTO>(favouriteContact);
        }
    }
}