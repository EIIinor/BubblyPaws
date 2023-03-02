using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BubblyPaws.MVVM.Models.Entities;

public class AddressEntity
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName ="nvarchar(50)")]
    public string StreetName { get; set; } = null!;


    [Column(TypeName = "char(6)")]
    public string PostalCode { get; set; } = null!;


    [Column(TypeName = "nvarchar(50)")]
    public string City { get; set; } = null!;

    public ICollection<CustomerEntity> Customers = new HashSet<CustomerEntity>();
}
