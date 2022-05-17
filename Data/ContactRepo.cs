using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Contacts>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Contacts.ToListAsync<Contacts>(cancellationToken);
            }
            catch (Exception e)
            {
                throw new TaskCanceledException("Operation Cancelled!");
            }
        }

        public async Task<IEnumerable<Contacts>> GetContactsByName(string name, CancellationToken cancellationToken)
        {
            List<Contacts> items = new List<Contacts>();
            try
            {
                foreach (var item in _context.Contacts.ToArray())
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    if (item.Name.Contains(name))
                    {
                        items.Add(item);
                    }
                }
                return items;
            }
            catch (TaskCanceledException e)
            {
                throw new TaskCanceledException("Operation Cancelled!");
            }
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
