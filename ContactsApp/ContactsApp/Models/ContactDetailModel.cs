using System;
using System.ComponentModel.DataAnnotations;

namespace ContactsApp.Models
{
    public class ContactDetailModel
    {

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

    }
}
