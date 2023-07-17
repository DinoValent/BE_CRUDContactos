namespace BE_CRUDContactos.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsFavourite { get; set; }

        public User User { get; set; }
    }
}