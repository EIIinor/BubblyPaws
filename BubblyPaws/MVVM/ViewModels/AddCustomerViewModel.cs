using BubblyPaws.MVVM.Models;
using BubblyPaws.MVVM.Models.Entities;
using BubblyPaws.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;

namespace BubblyPaws.MVVM.ViewModels;

public partial class AddCustomerViewModel : ObservableObject
{

    [ObservableProperty]
    private string pageTitle = "Add Customer";



    [ObservableProperty]
    private CustomerModel customer = new CustomerModel();



    [RelayCommand]
    private async Task Add()
    {
        var animal = new AnimalEntity
        {
            Name = "Fluffy",
            Breed = "Poodle",
            Age = 5
        };

        var booking = new BookingEntity
        {
            DateTime = DateTime.Now,
            Booking = "Large Grooming"
        };

        await CustomerService.SaveAsync(customer, animal, booking);
    }



    //[ObservableProperty]
    ////private AnimalModel animal = new AnimalModel();

    ////[ObservableProperty]
    ////private BookingModel booking = new BookingModel();
}
