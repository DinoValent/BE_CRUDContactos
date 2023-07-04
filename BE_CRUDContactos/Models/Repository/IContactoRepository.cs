namespace BE_CRUDContactos.Models.Repository
{
    public interface IContactoRepository //La interfaz me dice que tengo que hacer y la clase lo hace.
    {
        Task<List<Contacto>> GetListContactos();
        Task<Contacto> GetContacto(int id);
        Task DeleteContacto(Contacto contacto);

        Task<Contacto>AddContacto(Contacto contacto);
        Task UpdateContacto(Contacto contacto); 
    }
}
