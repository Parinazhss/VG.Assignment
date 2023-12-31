 

namespace Addressbook.Shared.Intefaces;

public interface IFileService 
{
    
    bool SaveContentToFile(string content);

    string GetContentFromFile();
}
