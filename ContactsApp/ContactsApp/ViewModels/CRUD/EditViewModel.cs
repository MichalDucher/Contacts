using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using ContactsApp.Models;
using ContactsApp.Services;

namespace ContactsApp.ViewModels.CRUD
{
    public class EditViewModel : MasterPageViewModel
    {
        private readonly ContactService contactService;

        public ContactDetailModel Contact { get; set; }

        [FromRoute("Id")]
        public int Id { get; private set; }

        public EditViewModel(ContactService contactService)
        {
            this.contactService = contactService;
        }

        public override async Task Init()
        {
            /*await Context.Authorize();*/
            await base.Init();
        }

        public override async Task PreRender()
        {
            if (Id != 0)
            {
                Contact = await contactService.GetContactById(Id);
            }
            await base.PreRender();
        }

        public async Task EditContact()
        {
            await contactService.UpdateContact(Contact);
            Context.RedirectToRoute("CRUD_Detail", new { Id = Id });
        }
    }
}

