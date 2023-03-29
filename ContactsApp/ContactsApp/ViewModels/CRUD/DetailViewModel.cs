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
    public class DetailViewModel : MasterPageViewModel
    {
        private readonly ContactService contactService;

        public ContactDetailModel Contact { get; set; }

        [FromRoute("Id")]
        public int Id { get; private set; }

        public DetailViewModel(ContactService contactService)
        {
            this.contactService = contactService;
        }

        public override async Task PreRender()
        {
            Contact = await contactService.GetContactById(Id);
            await base.PreRender();
        }

        public async Task DeleteContact()
        {
            /*await Context.Authorize();*/
            await contactService.DeleteContact(Id);
            Context.RedirectToRoute("Default", replaceInHistory: true);
        }
    }
}
