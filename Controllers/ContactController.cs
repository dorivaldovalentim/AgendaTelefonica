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
            return View();
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

        public IActionResult Edit()
        {
            return View();
        }
    }
}
