using PlatformService.Models;
namespace PlatformService.Data
{
    public interface IContactRepo
    {
        bool SaveChanges();
        Task<IEnumerable<Contacts>>GetAll(CancellationToken cancellationToken);
        Task<IEnumerable<Contacts>> GetContactsByName(string name, CancellationToken cancellationToken);
        void AddContacts(Contacts plat);    
    }
}