using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Business.Common;
using TeamProject.Business.Contracts;
using TeamProject.Business.Entities;
using TeamProject.Data.Contracts;

namespace TeamProject.Business.Managers
{
    public class ContactManager : IContactService
    {
        IContactRepository _ContactRepository;
        IContactEngine _ContactEngine;

        public ContactManager()
        {
        }

        public ContactManager(IContactEngine contactEngine)
        {
            _ContactEngine = contactEngine;
        }

        public ContactManager(IContactRepository contactRepository, IContactEngine contactEngine)
        {
            _ContactRepository = contactRepository;
            _ContactEngine = contactEngine;
        }

        public IEnumerable<Contact> GetContacts()
        {   
           IEnumerable<Contact> contactList= _ContactRepository.Get();
           return contactList;
        }

        public Contact GetContact(int id)
        {
             Contact contact = _ContactRepository.Get(id);
             return contact;
        }

    }
}
