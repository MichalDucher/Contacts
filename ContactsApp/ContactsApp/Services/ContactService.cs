using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ContactsApp.DAL;
using ContactsApp.DAL.Entities;
using ContactsApp.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ContactsApp.Services
{
    public class ContactService
    {
        private readonly ContactDbContext _context;
        private readonly string URLbase = @"https://localhost:7192/api/Contacts";

        public ContactService(ContactDbContext context)
        {
            this._context = context;
        }

        public async Task<List<ContactsListModel>> GetAllContacts()
        {

            List<ContactsListModel> List = new List<ContactsListModel>();
            using (var httpClient = new HttpClient())
            {
                string URL = URLbase + "/GetContacts";
                HttpResponseMessage response = await httpClient.GetAsync(URL);
                string apiResponse = await response.Content.ReadAsStringAsync();
                List = JsonConvert.DeserializeObject<List<ContactsListModel>>(apiResponse).Select(
                    c => new ContactsListModel
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName
                    }
                    ).ToList();
            }
            return List;
        }

        public async Task<ContactDetailModel> GetContactById(int Id)
        {
            string URL = URLbase + "/GetContactById?id=" + Id;
            ContactDetailModel contact = new ContactDetailModel();

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(URL);
                string apiResponse = await response.Content.ReadAsStringAsync();
                contact = JsonConvert.DeserializeObject<ContactDetailModel>(apiResponse);
            }
            return contact;
        }

        public async Task UpdateContact(ContactDetailModel contact)
        {
            string URL = URLbase + "/UpdateContact";

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PutAsync(URL, content);
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task InsertContact(ContactDetailModel contact)
        {
            string URL = URLbase + "/InsertContact";

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(URL, content);
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }


        public async Task DeleteContact(int Id)
        {
            string URL = URLbase + "/DeleteContact/" + Id;

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(URL);
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }

    }
}
