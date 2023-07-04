namespace BE_CRUDContactos.Models.DTO
{
    public class ContactoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int CelularNumber { get; set; }
        public bool Favorito { get; set; }
    }
}
