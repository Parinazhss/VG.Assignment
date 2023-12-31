

namespace Addressbook.Shared.Intefaces;

public interface IContact
{
    string Id { get; set; }

    string FirstName { get; set; }

    string LastName { get; set; }

    string Email { get; set; }

    string Phone { get; set; }

    string Address { get; set; }
}
