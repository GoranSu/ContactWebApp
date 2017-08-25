using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactWebApp.Models;
using System.Net;
using System.Data.Entity;
using System.IO;
using PagedList;

namespace ContactWebApp.Controllers
{
    public class HomeController : Controller
    {  
        ContactsDB _db = new ContactsDB();
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            IQueryable<Contact> contactQueryable = _db.Contacts.AsQueryable();

            if(!String.IsNullOrEmpty(searchString))
            {
                contactQueryable = contactQueryable
                    .Where(s => s.FirstName.Contains(searchString)
                    || s.LastName.Contains(searchString)
                    || s.City.Contains(searchString)
                    || s.Description.Contains(searchString)
                    || s.HomePhone.Contains(searchString)
                    || s.WorkPhone.Contains(searchString)
                    || s.MobilePhone.Contains(searchString));
            }
            
            List<Contact> contact = contactQueryable.ToList();

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(contact.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            ContactsViewModel newContact = new ContactsViewModel();
        
            return View(newContact);
        }

        [HttpPost]
        public ActionResult Create(ContactsViewModel newContact, HttpPostedFileBase image)
        {
            Contact contact = new Contact();
            contact.FirstName = newContact.FirstName;
            contact.LastName = newContact.LastName;
            contact.City = newContact.City;
            contact.Description = newContact.Description;
            contact.HomePhone = newContact.HomePhone;
            contact.MobilePhone = newContact.MobilePhone;
            contact.WorkPhone = newContact.WorkPhone;

            if (image != null)
            {
                contact.Image = new byte[image.ContentLength];
                image.InputStream.Read(contact.Image, 0, image.ContentLength);
            }

            if (ModelState.IsValid)
            {
                _db.Contacts.Add(contact);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contact contact = _db.Contacts.Find(id);

            if (contact == null)
            {
                return HttpNotFound();
            }

            ContactsViewModel editContact = new ContactsViewModel();
            editContact.FirstName = contact.FirstName;
            editContact.LastName = contact.LastName;
            editContact.City = contact.City;
            editContact.Description = contact.Description;
            editContact.HomePhone = contact.HomePhone;
            editContact.WorkPhone = contact.WorkPhone;
            editContact.MobilePhone = contact.WorkPhone;

            if (contact.Image != null)
            {
                editContact.ImageBase64Encoded = Convert.ToBase64String(contact.Image);
            }

            return View(editContact);
        }

        [HttpPost]
        public ActionResult Edit(ContactsViewModel editContact, HttpPostedFileBase image)
        {
            if(ModelState.IsValid)
            {
                Contact existingContact = _db.Contacts.Find(editContact.Id);

                existingContact.Id = editContact.Id;
                existingContact.FirstName = editContact.FirstName;
                existingContact.LastName = editContact.LastName;
                existingContact.City = editContact.City;
                existingContact.Description = editContact.Description;
                existingContact.HomePhone = editContact.HomePhone;
                existingContact.WorkPhone = editContact.WorkPhone;
                existingContact.MobilePhone = editContact.MobilePhone;

                if(image != null)
                {
                    existingContact.Image = new byte[image.ContentLength];
                    image.InputStream.Read(existingContact.Image, 0, image.ContentLength); 
                }

                _db.Entry(existingContact).State = EntityState.Modified;
                _db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}