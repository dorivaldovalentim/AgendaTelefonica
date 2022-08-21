using AgendaTelefonica.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaTelefonica.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
             
        }

        public DbSet<ContactModel> Contacts { get; set; }
    }
}
