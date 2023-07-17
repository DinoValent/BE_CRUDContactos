using BE_CRUDContactos.Models.DTO;

namespace BE_CRUDContactos.Models.Repository
{
    public interface IContactRepository
    {
        Task<List<ContactDTO>> GetAllContacts();
        Task<ContactDTO> GetContactById(int contactId);
        Task<Contact> AddContact(InputContactDTO contact);
        Task DeleteContact(int contactId);

        Task<List<ContactDTO>> GetFavouriteContacts();
        Task<ContactDTO> GetFavouriteContactByContactId(int contactId);
        Task AddToFavouriteContacts(int contactId);
        Task RemoveFromFavouriteContacts(int contactId);

        Task<IEnumerable<ContactDTO>> GetContactsByUserId(int userId);
        Task<IEnumerable<ContactDTO>> GetFavouriteContactsByUserId(int userId);
        Task<ContactDTO> GetContactByUserIdAndContactId(int userId, int contactId);
        Task<ContactDTO> GetFavouriteContactByUserIdAndContactId(int userId, int contactId);
    }
}