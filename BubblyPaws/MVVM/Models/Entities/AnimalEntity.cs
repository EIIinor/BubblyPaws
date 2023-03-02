using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BubblyPaws.MVVM.Models.Entities;

public class AnimalEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; } = null!;

    public int Age { get; set; }


    [Column(TypeName = "nvarchar(20)")]
    public string Breed { get; set; } = null!;

    public ICollection<CustomerEntity> Customers = new HashSet<CustomerEntity>();

}
