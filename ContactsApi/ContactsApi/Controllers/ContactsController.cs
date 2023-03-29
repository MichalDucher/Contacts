using ContactsApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Net;

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsContext _context;

        public ContactsController(ContactsContext context)
        {
            this._context = context;
        }

        [HttpGet("GetContacts")]
        public async Task<ActionResult<List<Contact>>> Get()
        {
            var List = await _context.Contacts.Select(
                s => new Contact
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    Category = s.Category,
                    Password = s.Password,
                    BirthDate = s.BirthDate
                }
            ).ToListAsync();

            if (List.Count < 0)
                return NotFound();

            return List;
            
        }

        [HttpGet("GetContactById")]
        public async Task<ActionResult<Contact>> GetUserById(int Id)
        {
            Contact contact = await _context.Contacts.Select(
                    c => new Contact
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        PhoneNumber = c.PhoneNumber,
                        Category = c.Category,
                        BirthDate = c.BirthDate,
                        Password = c.Password,
                    })
                .FirstOrDefaultAsync(c => c.Id == Id);

            if (User == null)
            
                return NotFound();
        
            return contact;
            
        }

        
        [HttpPost("InsertContact")]
        public async Task<HttpStatusCode> InsertContact(Contact contact)
        {
            var helper = new Contact()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Category = contact.Category,
                BirthDate = contact.BirthDate,
                Password = contact.Password,
            };

            _context.Contacts.Add(helper);
            await _context.SaveChangesAsync();

            return HttpStatusCode.Created;
        }

        [HttpPut("UpdateContact")]
     
        public async Task<HttpStatusCode> UpdateContact(Contact contact)
        {
            var helper = await _context.Contacts.FirstOrDefaultAsync(s => s.Id == contact.Id);

            helper.FirstName = contact.FirstName;
            helper.LastName = contact.LastName;
            helper.Email = contact.Email;
            helper.PhoneNumber = contact.PhoneNumber;
            helper.Category = contact.Category;
            helper.BirthDate = contact.BirthDate;   
            helper.Password = contact.Password;

            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


        [HttpDelete("DeleteContact/{Id}")]
        public async Task<HttpStatusCode> DeleteContact(int Id)
        {
            var helper = new Contact()
            {
                Id = Id
            };
            _context.Contacts.Attach(helper);
            _context.Contacts.Remove(helper);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
