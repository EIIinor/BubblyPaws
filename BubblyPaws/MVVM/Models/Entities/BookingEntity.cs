using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BubblyPaws.MVVM.Models.Entities;

public class BookingEntity
{
    [Key]
    public int Id { get; set; }

    public DateTime DateTime { get; set; }


    [Column(TypeName = "nvarchar(300)")]
    public string Booking { get; set; } = null!;

    public CustomerEntity Customer { get; set; } = new CustomerEntity();
}
