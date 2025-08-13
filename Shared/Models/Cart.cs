/*using System;
using System.Collections.Generic;
using System.Linq;
using ShopEase.Shared.Models;
using MySql.Data.MySqlClient;

namespace ShopEaseApp.Models
{
    public class Cart {
        //private List<Product> cart = new List<Product>();
        private string connectionString = "Server=localhost;Database=Shop;Uid=root;Pwd=funnySQLmen125!;";

        public void AddProduct(Product product) {
            //cart.Add(product);
            using (var connection = new MySqlConnection(connectionString)) {
                connection.Open();
                string query = "INSERT INTO Products (ProductID, Name, Price, Category) VALUES (@ProductID, @Name, @Price, @Category)";
                using (var cmd = new MySqlCommand(query, connection)) {
                    cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@Category", product.Category);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RemoveProduct(int productId) {
            //cart.RemoveAll(p => p.ProductID == productId);
            using (var connection = new MySqlConnection(connectionString)) {
                connection.Open();
                string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                using (var cmd = new MySqlCommand(query, connection)) {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DisplayCartItems() {
            //for (int i = 0; i < cart.Count; i++) {
            //    Console.WriteLine(cart[i].GetProductDetails());
            //}
            using (var connection = new MySqlConnection(connectionString)) {
                try {
                    connection.Open();
                    string query = "SELECT ProductID, Name, Price, Category FROM Products";

                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader()) {
                        Console.WriteLine("Cart Items:");
                        while (reader.Read()) {
                            int id = reader.GetInt32("ProductID");
                            string name = reader.GetString("Name");
                            decimal price = reader.GetDecimal("Price");
                            string category = reader.GetString("Category");

                            Console.WriteLine($"- {name} (ID: {id}) | ${price} | Category: {category}");
                        }
                    }
                } catch (Exception ex) {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public decimal CalculateTotal() {
            decimal total = 0m;

            using (var connection = new MySqlConnection(connectionString)) {
                try {
                    connection.Open();
                    string query = "SELECT SUM(Price) AS TotalPrice FROM Products";

                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader()) {
                        if (reader.Read() && !reader.IsDBNull(0)) {
                            total = reader.GetDecimal("TotalPrice");
                        }
                    }
                } catch (Exception ex) {
                    Console.WriteLine($"Error calculating total: {ex.Message}");
                }
            }
            return total;
        }
    }
}*/
