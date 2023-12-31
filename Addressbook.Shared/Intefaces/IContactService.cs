

namespace Addressbook.Shared.Intefaces;


public interface IContactService
{
    bool Add(IContact contact);

    IEnumerable<IContact> GetAll();

    IContact Get(string email);

    bool Update(IContact contact);

    bool Delete(IContact contact);
}
