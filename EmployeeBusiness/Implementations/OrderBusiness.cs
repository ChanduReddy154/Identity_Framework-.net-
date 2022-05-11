using AutoMapper;
using Hrms.Business.BusinessInterfaces;
using Hrms.Repository.Models;
using Hrms.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Hrms.Business.Implementations
{
   public class OrderBusiness : IOrderInterface
    {

        private readonly IOrderRepoInterface _orderRepoInterface;
        private readonly IMapper _mapper;

        public OrderBusiness(IOrderRepoInterface orderRepoInterface, IMapper mapper)
        {
            _orderRepoInterface = orderRepoInterface;
            _mapper = mapper;
        }

        public async Task<IList<ItemsViewModel>> getAllItems()
        {
            var result = await _orderRepoInterface.getAllItems();
            return _mapper.Map<IList<ItemsViewModel>>(result);
        }

        public async Task<IList<OrdersViewModel>> getAllOrders()
        {
            var result = await _orderRepoInterface.getAllOrders();
            return _mapper.Map<IList<OrdersViewModel>>(result);
        }

        public async Task<IList<OrderDetailsViewModel>> getOrdersOfuser(string id)
        {
            var result = await _orderRepoInterface.getOrdersOfUser(id);
            return _mapper.Map<IList<OrderDetailsViewModel>>(result);
        }

        public async Task<ItemsViewModel> postItems(ItemsViewModel items)
        {
            var result = await _orderRepoInterface.postItems(_mapper.Map<Item>(items));
            return _mapper.Map<ItemsViewModel>(result);
        }

        public async Task<OrdersViewModel> postOrders(OrdersViewModel orders)
        {
            var result = await _orderRepoInterface.postOrder(_mapper.Map<Order>(orders));
            return _mapper.Map<OrdersViewModel>(result);
        }
    }
}
