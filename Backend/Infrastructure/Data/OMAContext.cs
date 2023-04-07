using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class OMAContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public OMAContext(DbContextOptions options): base(options){           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Customer>().HasData(
                new Customer{
                    Id = 1,
                    FirstName = "Mike",
                    LastName = "Zhou",
                    ContactNumber = "3124838818",
                    IsDeleted = false,
                    Email = "xuejianzhou2012@gmail.com"               
                },
                new Customer{
                    Id = 2,
                    FirstName = "Peter",
                    LastName = "Lee",
                    ContactNumber = "312123321",
                    IsDeleted = false,
                    Email = "peterli@gmail.com"               
                }
            );

            modelBuilder.Entity<Address>().HasData(
                new Address{
                    Id = 1,
                    CustomerId = 1,
                    AddressLine1 = "Someplase",
                    AddressLine2 = "There",
                    City = "Houston",
                    State = "TX",
                    Country = "US"
                },
                new Address{
                    Id = 2,
                    CustomerId = 2,
                    AddressLine1 = "b Someplase",
                    AddressLine2 = "Herer",
                    City = "Houston",
                    State = "TX",
                    Country = "US"
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order{
                    Id = 1,
                    CustomerId = 1,
                    OrderDate = new DateTime(2022,10,20),
                    Description = "New Item",
                    TotalAmount = 500,
                    DepositAmount = 10,
                    IsDelivery = true,
                    Status = Core.Enums.Status.Pedning,
                    OtherNotes = "Something",
                    IsDeleted = false
                },
                new Order{
                    Id = 2,
                    CustomerId = 2,
                    OrderDate = new DateTime(2023,10,20),
                    Description = "New Item2",
                    TotalAmount = 300,
                    DepositAmount = 20,
                    IsDelivery = true,
                    Status = Core.Enums.Status.Pedning,
                    OtherNotes = "Something",
                    IsDeleted = false
                }
            );
        }

        
    }
}