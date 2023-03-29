using System;

namespace ContactsApp.DAL.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Category { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
    }
}
