

using Addressbook.Shared.Intefaces;
using Addressbook.Shared.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Addressbook.Shared.Service;

public class ContactService : IContactService
{
    private readonly IFileService fileService = new FileService(@"C:\projects\myList.json");
    private IFileService _fileService;
    private  List<IContact> _contacts;
    private string json;

    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
        _contacts = new List<IContact>();
    }

    public bool Add(IContact contact)
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects
        };

         json = JsonConvert.SerializeObject(_contacts, settings);

        return true;
    }

    public bool Delete(IContact contact)
    {
        _contacts.Remove(contact);
        return true;    
    }

    public IContact Get(string email)
    {
        var contact = _contacts.FirstOrDefault(x => x.Email == email);
        return contact ?? null!;
    }

    public IEnumerable<IContact> GetAll()
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        json = JsonConvert.SerializeObject(_contacts, settings);

        return _contacts;
    }

    public bool Update(IContact contact)
    {
        var current = _contacts.FirstOrDefault(x => x.Email == contact.Email);

        if (current != null)
        {
            // Update properties of the existing contact
            current.FirstName = contact.FirstName;
            current.LastName = contact.LastName;
            current.Email = contact.Email;
            current.Phone = contact.Phone;
            current.Address = contact.Address;

            return true;
        }

        return false; // Return false if the contact with the given email is not found
    }
}
