using Hrms.Repository.Models;
using Hrms.Repository.RepositoryInterfaces;
using Hrms.Repository.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Repository.Implementations
{
  public  class IOrderRepository : IOrderRepoInterface
    {

        private readonly MyContext _myContext;

        public IOrderRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public Task<OrderDetails> EditOrderDetails(OrderDetails model)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Item>> getAllItems()
        {
            var result = await _myContext.Items.ToListAsync();
            return result;
        }

        public async Task<IList<Order>> getAllOrders()
        {
            var result = await _myContext.Orders.ToListAsync();
            return result;
        }

        public async Task<IList<OrderDetails>> getOrdersOfUser(string id)
        {
            var result = await _myContext.OrderDetails.FromSqlRaw("exec usp_getOrderDetails {0}", id).ToListAsync();
            return result;

        }

        public async Task<Item> postItems(Item item)
        {
            var result = await _myContext.Items.AddAsync(item);
            await _myContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Order> postOrder(Order order)
        {
            var result = await _myContext.Orders.AddAsync(order);
            await _myContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
