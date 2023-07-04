using Microsoft.EntityFrameworkCore;

namespace BE_CRUDContactos.Models.Repository
{
    public class ContactoRepository : IContactoRepository
    {
        private readonly AplicationDbContext _context;

        public ContactoRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Contacto> AddContacto(Contacto contacto)
        {
            _context.Add(contacto);
            await _context.SaveChangesAsync();
            return contacto;    
        }

        public async Task DeleteContacto(Contacto contacto)
        {
            _context.Contactos.Remove(contacto);
            await _context.SaveChangesAsync();
        }

        public async Task<Contacto> GetContacto(int id)
        {
           return await _context.Contactos.FindAsync(id);
        }

        public async Task<List<Contacto>> GetListContactos()
        {
            return await _context.Contactos.ToListAsync();
        }

        public async Task UpdateContacto(Contacto contacto)
        {
            var contactoItem = await _context.Contactos.FirstOrDefaultAsync(x => x.Id == contacto.Id);
            if(contactoItem != null)
            {
                contactoItem.Nombre = contacto.Nombre;
                contactoItem.CelularNumber = contacto.CelularNumber;
                contactoItem.Email = contacto.Email;

                await _context.SaveChangesAsync();
            }
            
        }
    }
}
