namespace HerbsStore.Libraries.HS.Services.OrdersServices
{
    public interface ICartService
    {
        bool AddProductToCart(long productId);
        bool AddQuantityToCart(long productId);
        bool SubtractQuantityToCart(long productId);
        bool RemoveItemFromCart(long productId);
        bool CompleteCartOrder(CartCrudVm vm);
        CartCrudVm GetCart();
    }
}