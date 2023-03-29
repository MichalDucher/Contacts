using System;
using System.Collections.Generic;

namespace ContactsApi.Models;

public partial class Contact
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Category { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Password { get; set; } = null!;
}
