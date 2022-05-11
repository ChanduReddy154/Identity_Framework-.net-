using Hrms.Repository.Models;
using Hrms.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Repository.RepositoryInterfaces
{
   public  interface IOrderRepoInterface
    {

        Task<IList<Item>> getAllItems();

        Task<IList<Order>> getAllOrders();

        Task<Item> postItems(Item item);
        
        Task<Order> postOrder(Order order);

        Task<IList<OrderDetails>> getOrdersOfUser(string id);

      //  Task<OrderDetails> EditOrderDetails(OrderDetails model);


    }
}
