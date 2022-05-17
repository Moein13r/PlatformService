using PlatformService.Models;
namespace PlatformService.Data
{
    public interface IContactRepo
    {
        bool SaveChanges();
        IEnumerable<Contacts>GetAll();
        IEnumerable<Contacts> GetContactsByName(string name);
        void AddContacts(Contacts plat);    
    }
}