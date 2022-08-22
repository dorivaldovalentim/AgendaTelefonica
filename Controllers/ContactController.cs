using AgendaTelefonica.Models;
using AgendaTelefonica.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgendaTelefonica.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContact _contactServices;

        public ContactController(IContact contactServices)
        {
            _contactServices = contactServices;
        }

        public IActionResult Index()
        {
            List<ContactModel> contacts = _contactServices.GetAll();
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Store(ContactModel contact)
        {
            _contactServices.Store(contact);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ContactModel? contact = _contactServices.GetById(id);
            return View(contact);
        }
    }
}
