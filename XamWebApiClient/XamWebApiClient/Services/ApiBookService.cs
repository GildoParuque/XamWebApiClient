using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XamWebApiClient.Models;

namespace XamWebApiClient.Services
{
    public class ApiBookService : IBookService
    {
        private readonly HttpClient _httpClient;
        public ApiBookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddBook(Book book)
        {
            var response = await _httpClient.PostAsync("Book",
                new StringContent(JsonSerializer.Serialize(book), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteBook(Book book)
        {
            var respoonse = await _httpClient.DeleteAsync($"Book/{book.Id}");

            respoonse.EnsureSuccessStatusCode();
        }

        public async Task<Book> GetBook(int id)
        {
            var response = await _httpClient.GetAsync($"Book/{id}");

            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Book>(responseAsString);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var response = await _httpClient.GetAsync("Book");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<Book>>(responseAsString);
        }

        public async Task SaveBook(Book book)
        {
            var response = await _httpClient.PutAsync($"Book?id={book.Id}",
                new StringContent(JsonSerializer.Serialize(book), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            
        }
    }
}
