namespace BE_CRUDContactos.Models.DTO
{
    public class InputContactDTO
    {
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsFavourite { get; set; }
    }

    public class ContactDTO : InputContactDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
    }
}