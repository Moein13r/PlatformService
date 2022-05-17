using PlatformService.Models;

namespace PlatformService.Data
{
    public class ContactRepo : IContactRepo
    {
        private readonly AppDbContext _context;

        public ContactRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddContacts(Contacts? contact)
        {
            _context.Contacts.Add(contact);
        }

        public IEnumerable<Contacts> GetAll()
        {
            return _context.Contacts.ToList<Contacts>();
        }

        public IEnumerable<Contacts> GetContactsByName(string name)
        {
            return _context.Contacts.Where(item=>item.Name.Contains(name)).ToList<Contacts>();
        }
        
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
