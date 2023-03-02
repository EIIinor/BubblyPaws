using BubblyPaws.Contexts;
using BubblyPaws.MVVM.Models;
using BubblyPaws.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace BubblyPaws.Services;

internal class CustomerService
{
    private static DataContext _context = new DataContext();


        public static async Task SaveAsync(CustomerModel customer, AnimalEntity animal, BookingEntity booking)
        {
            var _customerEntity = new CustomerEntity
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
            };

            var _animalEntity = new AnimalEntity
            {
                Name = animal.Name,
                Breed = animal.Breed,
                Age = animal.Age,
            };

            var _bookingEntity = new BookingEntity
            {
                DateTime = booking.DateTime,
                Booking = booking.Booking,
            };

            var _addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == customer.StreetName && x.PostalCode == customer.PostalCode && x.City == customer.City);
            if (_addressEntity != null)
                _customerEntity.Address.Id = _addressEntity.Id;
            else
                _customerEntity.Address = new AddressEntity
                {
                    StreetName = customer.StreetName,
                    PostalCode = customer.PostalCode,
                    City = customer.City,
                };
         
            _context.Add(_customerEntity);
            await _context.SaveChangesAsync();
        }




    public static async Task<IEnumerable<CustomerModel>> GetAllAsync()
    {
        var _customers = new List<CustomerModel>();

        foreach (var _customer in await _context.Customers.Include(x => x.Address)
                                                         .Include(x => x.Animal)
                                                         .Include(x => x.Booking)
                                                         .ToListAsync())
            _customers.Add(new CustomerModel
            {
                FirstName = _customer.FirstName,
                LastName = _customer.LastName,
                PhoneNumber = _customer.PhoneNumber,
                Email = _customer.Email,

                StreetName = _customer.Address.StreetName,
                PostalCode = _customer.Address.PostalCode,
                City = _customer.Address.City,

                Name = _customer.Animal.Name,
                Age = _customer.Animal.Age,
                Breed = _customer.Animal.Breed,

                DateTime = _customer.Booking.DateTime,
                Text = _customer.Booking.Booking

            });

        return _customers;
    }




    public static async Task<CustomerModel> GetAsync(string email)
    {
        var _customer = await _context.Customers.Include(x => x.Address)
                                               .Include(x => x.Animal)
                                               .Include(x => x.Booking)
                                               .FirstOrDefaultAsync(x => x.Email == email);
        if (_customer != null)
            return new CustomerModel
            {
                FirstName = _customer.FirstName,
                LastName = _customer.LastName,
                PhoneNumber = _customer.PhoneNumber,
                Email = _customer.Email,
                StreetName = _customer.Address.StreetName,
                PostalCode = _customer.Address.PostalCode,
                City = _customer.Address.City,

                Name = _customer.Animal.Name,
                Age = _customer.Animal.Age,
                Breed = _customer.Animal.Breed,

                DateTime = _customer.Booking.DateTime,
                Text = _customer.Booking.Booking,
            };

          else
            return null!;
    }


    public static async Task UpdateAsync(CustomerModel customer)
    {
        var _modified = false;

        var _customerEntity = await _context.Customers.Include(x => x.Address)
                                                      .Include(x => x.Animal)
                                                      .Include(x => x.Booking)
                                                      .FirstOrDefaultAsync(x => x.Id == customer.Id);
        if (_customerEntity != null)
        {
            if (!string.IsNullOrEmpty(customer.FirstName))
            {
                _customerEntity.FirstName = customer.FirstName;
                _modified = true;
            }

            if (!string.IsNullOrEmpty(customer.LastName))
            {
                _customerEntity.LastName = customer.LastName;
                _modified = true;
            }

            if (!string.IsNullOrEmpty(customer.PhoneNumber))
            {
                _customerEntity.PhoneNumber = customer.PhoneNumber;
                _modified = true;
            }

            if (!string.IsNullOrEmpty(customer.Email))
            {
                _customerEntity.Email = customer.Email;
                _modified = true;
            }


            if (!string.IsNullOrEmpty(customer.Name))
            {
                _customerEntity.Animal.Name = customer.Name;
                _modified = true;
            }
            if (customer.Age > 0)
            {
                _customerEntity.Animal.Age = customer.Age;
                _modified = true;
            }
            if (!string.IsNullOrEmpty(customer.Breed))
            {
                _customerEntity.Animal.Breed = customer.Breed;
                _modified = true;
            }

            if (!string.IsNullOrEmpty(customer.Breed))
            {
                _customerEntity.Animal.Breed = customer.Breed;
                _modified = true;
            }

            if (!string.IsNullOrEmpty(customer.Text))
            {
                _customerEntity.Booking.Booking = customer.Text;
                _modified = true;
            }


            if (!string.IsNullOrEmpty(customer.StreetName) || !string.IsNullOrEmpty(customer.PostalCode) || !string.IsNullOrEmpty(customer.City))
                {
                var _addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == customer.StreetName && x.PostalCode == customer.PostalCode && x.City == customer.City);
                    if (_addressEntity != null)
                    _customerEntity.AddressId = _addressEntity.Id;
                else
                    _customerEntity.Address = new AddressEntity
                    {
                        StreetName = customer.StreetName,
                        PostalCode = customer.PostalCode,
                        City = customer.City
                    };
                }

            _context.Entry(_customerEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }




    public static async Task DeleteAsync(string email)
    {
        var customer = await _context.Customers.Include(x => x.Address)
                                               .Include(x => x.Animal)
                                               .Include(x => x.Booking)
                                               .FirstOrDefaultAsync(x => x.Email == email);
        if (customer != null)
        {
            _context.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }


}


