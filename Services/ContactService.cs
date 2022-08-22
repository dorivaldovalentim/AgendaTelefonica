using AgendaTelefonica.Data;
using AgendaTelefonica.Models;

namespace AgendaTelefonica.Services
{
    public interface IContact
    {
        List<ContactModel> GetAll();

        ContactModel? GetById(int id);

        ContactModel Store(ContactModel contact);

        ContactModel? Update(ContactModel data);
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

        public ContactModel? GetById(int id)
        {
            return _dbContext.Contacts.FirstOrDefault(x => x.Id == id);
        }

        public ContactModel Store(ContactModel contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
            return contact;
        }

        public ContactModel? Update(ContactModel data)
        {
            ContactModel? contact = this.GetById(data.Id);
            
            if (contact == null) throw new System.Exception("Erro ao editar contacto");

            contact.Id = data.Id;
            contact.Name = data.Name;
            contact.Email = data.Email;
            contact.Phone = data.Phone;

            _dbContext.Contacts.Update(contact);
            _dbContext.SaveChanges();

            return contact;
        }
    }
}
