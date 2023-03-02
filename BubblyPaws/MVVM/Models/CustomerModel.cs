using System;

namespace BubblyPaws.MVVM.Models;

public class CustomerModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;

    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;

    public string DisplayName => $"{FirstName} {LastName}";


    public Guid AnimalId { get; set; }
    public string Name { get; set; } = null!;
    public string Breed { get; set; } = null!;
    public int Age { get; set; }


    public int BookingId { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public string Text { get; set; } = null!;


    //public ICollection<AnimalModel> Animal { get; set; } = null!;
    //public ICollection<BookingModel> Booking { get; set; } = null!;

}
