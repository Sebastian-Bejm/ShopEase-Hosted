using System.Collections.Generic;
using System.Linq;
using ShopEase.Shared.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using System;

namespace ShopEase.Shared.Services
{
    public class CartItemDto
    {
        public int ProductID { get; set; }
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
    }

    public class CartService {
        private Dictionary<int, (Product Product, int Quantity)> cartItems = new();

        public IEnumerable<(int ProductID, Product Product, int Quantity)> CartItems =>
        cartItems.Select(kvp => (kvp.Key, kvp.Value.Product, kvp.Value.Quantity));

        private readonly IJSRuntime js;
        private readonly string userId;
        private string StorageKey => $"cartItems_{userId}";

        public CartService(IJSRuntime jsRuntime, string userId)
        {
            js = jsRuntime;
            this.userId = userId;
            LoadCartFromStorage();
        }

        private async Task SaveCartToStorageAsync()
        {
            var cartDtoList = cartItems.Select(kvp => new CartItemDto
            {
                ProductID = kvp.Key,
                Product = kvp.Value.Product,
                Quantity = kvp.Value.Quantity
            }).ToList();

            await js.InvokeVoidAsync("localStorage.setItem", StorageKey,
                System.Text.Json.JsonSerializer.Serialize(cartDtoList));
        }

        private async void LoadCartFromStorage()
        {
            try
            {
                var json = await js.InvokeAsync<string>("localStorage.getItem", StorageKey);
                if (!string.IsNullOrEmpty(json))
                {
                    var items = System.Text.Json.JsonSerializer.Deserialize<List<CartItemDto>>(json);
                    if (items != null)
                    {
                        cartItems = items.ToDictionary(
                            item => item.ProductID,
                            item => (item.Product, item.Quantity)
                        );
                    }
                }
            }
            catch { /* handle errors if needed */ }
        }


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
            _ = SaveCartToStorageAsync();
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
            _ = SaveCartToStorageAsync();
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
            _ = SaveCartToStorageAsync();
        }

        public decimal CalculateTotal()
        {
            return cartItems.Values.Sum(item => item.Product.Price * item.Quantity);
        }
    }

}
