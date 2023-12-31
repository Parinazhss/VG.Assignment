

using Addressbook.Shared.Intefaces;
using System.Diagnostics;

namespace Addressbook.Shared.Service;

public class FileService(string filePath) : IFileService
{
    private readonly string _filePath = filePath;
    IFileService fileService = new FileService(@"C:\projects\myList.json");

    public string GetContentFromFile()
    {
        try
        {
            if (File.Exists(_filePath)) 
            {
                using var sr = new StreamReader(_filePath);
                return sr.ReadToEnd();
            }
            
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }



    public bool SaveContentToFile(string content)
    {
       try 
        {
            using (var sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(content);
            }

                return true;
        }
        catch (Exception ex){ Debug.WriteLine(ex.Message); }
        return false;
    }
}
