using AgendaTelefonica.Data;
using AgendaTelefonica.Models;

namespace AgendaTelefonica.Services
{
    public interface IContact
    {
        ContactModel Store(ContactModel contact);
    }

    public class ContactService : IContact
    {
        private readonly DatabaseContext _dbContext;

        public ContactService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ContactModel Store(ContactModel contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
            return contact;
        }
    }
}
