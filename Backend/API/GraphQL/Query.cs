using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.GraphQL
{
    public class Query
    {

        public IQueryable<Customer> GetCustomers([Service] OMAContext context){

            context.Database.EnsureCreated();
            return context.Customers
                .Include(o => o.Orders)
                .Include(a => a.Address);
        }

        public IQueryable<Order> GetOrders([Service] OMAContext context){
            context.Database.EnsureCreated();
            return context.Orders.Include(c=>c.Customer);
        }
    }
}