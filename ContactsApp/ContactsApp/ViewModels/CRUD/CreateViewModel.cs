using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using ContactsApp.Models;
using ContactsApp.Services;

namespace ContactsApp.ViewModels.CRUD
{
    public class CreateViewModel : MasterPageViewModel
    {
        private readonly ContactService contactService;

        public ContactDetailModel Contact { get; set; } = new ContactDetailModel { };

        public CreateViewModel(ContactService contactService)
        {
            this.contactService = contactService;
        }

        public override async Task Init()
        {
            /*await Context.Authorize();*/
            await base.Init();
        }

        public async Task AddContact()
        {
            await contactService.InsertContact(Contact);
            Context.RedirectToRoute("Default");
        }
    }
}
