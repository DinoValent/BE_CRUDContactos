namespace BE_CRUDContactos.Models.DTO
{
    public class InputUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }

    public class UserDTO : InputUserDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }

}

