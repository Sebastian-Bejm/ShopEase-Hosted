using System.Collections.Generic;
using System.Linq;
using ShopEase.Shared.Models;
using Microsoft.JSInterop;

namespace ShopEase.Shared.Services
{
    public class CartService {
        private Dictionary<int, (Product Product, int Quantity)> cartItems = new();

        public IEnumerable<(int ProductID, Product Product, int Quantity)> CartItems =>
        cartItems.Select(kvp => (kvp.Key, kvp.Value.Product, kvp.Value.Quantity));

        public void AddProduct(Product product)
        {
            if (cartItems.ContainsKey(product.ProductID))
            {
                var (existingProduct, quantity) = cartItems[product.ProductID];
                cartItems[product.ProductID] = (existingProduct, quantity + 1);
            }
            else
            {
                cartItems[product.ProductID] = (product, 1);
            }
        }

        public void RemoveProduct(int productId) {
            if (cartItems.ContainsKey(productId))
            {
                var (product, quantity) = cartItems[productId];
                if (quantity > 1)
                {
                    cartItems[productId] = (product, quantity - 1);
                }
                else
                {
                    cartItems.Remove(productId);
                }
            }
        }

        public void SetProductQuantity(int productId, int quantity)
        {
            if (cartItems.ContainsKey(productId))
            {
                var existing = cartItems[productId].Product;
                if (quantity <= 0)
                {
                    cartItems.Remove(productId);
                }
                else
                {
                    cartItems[productId] = (existing, quantity);
                }
            }
        }


        public decimal CalculateTotal()
        {
            return cartItems.Values.Sum(item => item.Product.Price * item.Quantity);
        }
    }
}
