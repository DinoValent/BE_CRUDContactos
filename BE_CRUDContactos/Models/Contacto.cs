using System.Data;

namespace BE_CRUDContactos.Models
{
    public class Contacto
    {
       public int Id { get; set; }
       public string Nombre { get; set; }
       public string Email { get; set; }
        public int CelularNumber { get; set; }
        public bool Favorito { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
