using AgendaTelefonica.Data;
using AgendaTelefonica.Models;

namespace AgendaTelefonica.Services
{
    public interface IContact
    {
        List<ContactModel> GetAll();
        ContactModel Store(ContactModel contact);
    }

    public class ContactService : IContact
    {
        private readonly DatabaseContext _dbContext;

        public ContactService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ContactModel> GetAll()
        {
            return _dbContext.Contacts.ToList();
        }

        public ContactModel Store(ContactModel contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
            return contact;
        }
    }
}
