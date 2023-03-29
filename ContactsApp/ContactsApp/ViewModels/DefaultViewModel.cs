using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using ContactsApp.Models;
using ContactsApp.Services;

namespace ContactsApp.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {

        private readonly ContactService contactService;

        [Bind(Direction.ServerToClient)]
        public List<ContactsListModel> Contacts { get; set; }

		public DefaultViewModel(ContactService contactService)
        {
            this.contactService = contactService;
        }
        public override async Task PreRender()
        {
            Contacts =  await contactService.GetAllContacts();
            await base.PreRender();
        }

    }
}
