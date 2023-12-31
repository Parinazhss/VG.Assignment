

using Addressbook.Shared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace Addressbook.Shared.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableObject? _currentViewModel;

    private readonly IServiceProvider _sp;
      
    public MainViewModel(IServiceProvider sp)
    {  
        _sp = sp;
        CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }

    [ObservableProperty]
    private Contact _contactForm = new();


    [ObservableProperty]
    public ObservableCollection<Contact> _contactList = [];

    public Contact? Contact { get; private set; }

    [RelayCommand]
    public void AddContactToList()
    {
        if (!string.IsNullOrWhiteSpace(ContactForm.FirstName) && !string.IsNullOrWhiteSpace(ContactForm.LastName))
        {
            ContactList.Add(ContactForm);
            ContactForm = new();

        }
    }
    [RelayCommand]
    public void RemoveContactFromList(Contact contact)
    {
        if (contact != null)
        {
            ContactList.Remove(contact);

        }
    }
    [RelayCommand]
    public void EditContactFromList(Contact contact)
    {
        ContactForm = contact;
    }





}
