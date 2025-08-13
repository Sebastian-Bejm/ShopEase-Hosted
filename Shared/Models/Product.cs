namespace ShopEase.Shared.Models
{
    public class Product {
        public int ProductID {get; init;}
        public string Name {get; init;} = string.Empty;
        public decimal Price {get; init;}
        public string Category {get; init;} = string.Empty;

        public string GetProductDetails() {
            return "Product: " + Name + " | Price: " + Price.ToString("0.##") + " | Category: " + Category;
        }
    }
}
