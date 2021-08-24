using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using blazor_store.Models;

namespace blazor_store.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var apiResponse = await _httpClient.GetStreamAsync($"/products");
            return await JsonSerializer.DeserializeAsync<IEnumerable<Product>>(apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Product> GetProductDetails(string _Id)
        {
            var apiResponse = await _httpClient.GetStreamAsync($"/products/{_Id}");
            return await JsonSerializer.DeserializeAsync<Product>(apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                var productJson = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/products", productJson);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();

                    return await JsonSerializer.DeserializeAsync<Product>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public async Task DeleteProduct(string _Id)
        {
            try
            {
                await _httpClient.DeleteAsync($"/products/{_Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateProduct(Product product)
        {
            try
            {
                var productJson = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

                var url = $"/products/{product._Id}";

                var response = await _httpClient.PatchAsync(url, productJson);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Successfully updated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}