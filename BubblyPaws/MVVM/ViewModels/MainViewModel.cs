using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BubblyPaws.MVVM.ViewModels;

public partial class MainViewModel : ObservableObject
{
    //[ObservableProperty]
    //private ContactModel selectedContact;


    [ObservableProperty]
    private ObservableObject currentViewModel;



    [RelayCommand]
    private void GoToAddCustomer() => CurrentViewModel = new AddCustomerViewModel();


    [RelayCommand]
    public void GoToEditCustomer() => CurrentViewModel = new EditCustomerViewModel();



    [RelayCommand]
    private void GoToCustomers() => CurrentViewModel = new CustomersViewModel();
    


    public MainViewModel()
    {
        CurrentViewModel = new CustomersViewModel();
    }
}
