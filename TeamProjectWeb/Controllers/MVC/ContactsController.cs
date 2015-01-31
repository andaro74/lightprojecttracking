using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamProject.Business.Contracts;
using TeamProject.Business.Entities;
using TeamProjectWeb.Models;

namespace TeamProjectWeb.Controllers.MVC
{
    public class ContactsController : Controller
    {

        private IContactService _contactManager;

        public ContactsController(IContactService contactManager)
        {
            _contactManager = contactManager;
        }

        private ViewModelFactory _theModelFactory;
        protected ViewModelFactory TheModelFactory
        {
            get
            {
                if (_theModelFactory == null)
                {
                    _theModelFactory = new ViewModelFactory(_contactManager);
                }
                return _theModelFactory;
            }
        }

        // GET: Contacts
        public ActionResult Index()
        {

            IEnumerable<Contact> contacts= _contactManager.GetContacts();
            return View(contacts);
        }



        // GET: Contacts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult AdminDetails()
        {
            int id = 1; //For now hardcoded but needs to be replaced by the user id logged in
            Contact contact = _contactManager.GetContact(id);
            ContactBasicViewModel contactBasicViewModel = TheModelFactory.Create(contact);
            return PartialView(contactBasicViewModel);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contacts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
