using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BubblyPaws.MVVM.Models.Entities;

[Index(nameof(Email), IsUnique = true)]
public class CustomerEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; } = null!;


    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; } = null!;


    [Column(TypeName = "nvarchar(50)")]
    public string Email { get; set; } = null!;


    [Column(TypeName = "char(13)")]
    public string PhoneNumber { get; set; } = null!;

    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;

    public Guid AnimalId { get; set; }
    public AnimalEntity Animal { get; set; } = null!;

    public int BookingId { get; set; }
    public BookingEntity Booking { get; set;} = null!;
}