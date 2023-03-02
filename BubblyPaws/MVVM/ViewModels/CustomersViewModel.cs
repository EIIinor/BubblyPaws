using BubblyPaws.MVVM.Models;
using BubblyPaws.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace BubblyPaws.MVVM.ViewModels;

public partial class CustomersViewModel : ObservableObject
{

    public CustomersViewModel()
    {
        LoadCustomers();
    }

    [ObservableProperty]
    private ObservableCollection<CustomerModel> customers = null!;

    private async void LoadCustomers()
    {
        var customers = await CustomerService.GetAllAsync();
        Customers = new ObservableCollection<CustomerModel>(customers);
    }


    [ObservableProperty]
    private ObservableCollection<CustomerModel> customer = new ObservableCollection<CustomerModel>();


    [ObservableProperty]
    private string pageTitle = "List Of Customers";


    [ObservableProperty]
    private CustomerModel selectedCustomer = null!;

}
