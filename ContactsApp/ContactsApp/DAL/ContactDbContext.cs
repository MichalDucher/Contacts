using Microsoft.EntityFrameworkCore;
using ContactsApp.DAL.Entities;

namespace ContactsApp.DAL
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Contact> Conatcts { get; set; }
    }
}
