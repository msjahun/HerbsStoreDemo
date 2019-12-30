using System.Collections.Generic;

namespace HerbsStore.Libraries.HS.Services.OrdersServices
{
    public interface IOrderService
    {
        //long OrderAdd(OrderCrudVm vm);
        //OrderCrudVm GetOrderById(long id);
        bool OrderConfirmationToggle(long vm);
        //bool OrderUpdate(OrderCrudVm vm);
        void DeleteOrder(long id);
        List<OrderCrudVm> GetOrders();
    }
}