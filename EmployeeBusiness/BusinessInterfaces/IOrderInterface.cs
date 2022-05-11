using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Hrms.Business.BusinessInterfaces
{
   public  interface IOrderInterface
    {

        Task<IList<ItemsViewModel>> getAllItems();

        Task<IList<OrdersViewModel>> getAllOrders();

        Task<ItemsViewModel> postItems(ItemsViewModel items);

        Task<OrdersViewModel> postOrders(OrdersViewModel orders);

        Task<IList<OrderDetailsViewModel>> getOrdersOfuser(string id);


    }
}
