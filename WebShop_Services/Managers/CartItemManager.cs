using Microsoft.EntityFrameworkCore;
using WebShop_DataAccess.Context;
using WebShop_DataAccess.Context.Entities;

namespace WebShop_Services.Managers
{
    public class CartItemManager : ICartItemManager
    {
        private readonly WebShopDbContext _context;
        private readonly ICartManager _cartManager;

        public CartItemManager(WebShopDbContext context, ICartManager cartManager)
        {
            _context = context;
            _cartManager = cartManager;
        }

        public void AddNewCartItem(int productId, int userId)
        {
            var cart = _cartManager.GetCartFromDb(userId);

            if (IsItemInCart(productId, userId))
            {
                IncreaseQuantity(productId, userId);
            }
            else
            {
                var cartItem = new CartItem
                {
                    ProductId = productId,
                    Product = _context.Products.First(p => p.Id == productId),
                    Quantity = 1,
                    Cart = cart,
                    CartId = cart.Id
                };

                _context.Cart_Items.Add(cartItem);
                _context.SaveChanges();
            }
            
        }

        public CartItem GetCartItemById(int userId, int productId)
        {
            var selectedItem = GetCartItemsForCart(userId).FirstOrDefault(i => i.ProductId == productId);

            return selectedItem;
        }

        public List<CartItem> GetCartItemsForCart(int userId)
        {
            var cart = _cartManager.GetCartFromDb(userId);

            var cartItems = _context.Cart_Items.Where(ct => ct.CartId == cart.Id)
                                               .Include(ct => ct.Product)
                                               .ToList();
            return cartItems;
        }

        public void IncreaseQuantity(int userId, int productId)
        {
            var selectedItem = GetCartItemById(userId, productId);

            selectedItem.Quantity += 1;

            _context.SaveChanges();
        }

        public bool IsItemInCart(int productId, int userId)
        {
            bool isInCart;

            var cartItem = GetCartItemById(userId, productId);

            isInCart = cartItem != null;

            return isInCart;
        }

        public void RemoveItem(int userId, int productId)
        {
            var selectedItem = GetCartItemById(userId, productId);

            _context.Cart_Items.Remove(selectedItem);
            _context.SaveChanges();
        }

        public void SubtractQuantity(int userId, int productId)
        {
            var selectedItem = GetCartItemById(userId, productId);

            if(selectedItem.Quantity > 1)
            {
                selectedItem.Quantity -= 1;
                _context.SaveChanges();
            }
            else 
            { 
                RemoveItem(userId, productId);
            }

            


        }
    }
}
