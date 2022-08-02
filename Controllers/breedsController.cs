using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using CatsMVC.Models;
using System.Text.Json;

namespace CatsMVC.Controllers
{
    public class breedsController : Controller
    {
        private readonly HttpClient _httpClient;
        public breedsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("catsapi");

        }
        public async Task<IActionResult> Index(string page)
        {

            // sets variable route to catsapi in program/breeds?page= whatever number we are at
            string route = $"breeds?page={page ?? "1"}";
            HttpResponseMessage response = await _httpClient.GetAsync(route);

                var responseString = await response.Content.ReadAsStringAsync();
                var breeds = JsonSerializer.Deserialize<ResultsViewModel<BreedsViewModel>>(responseString);
                return View(breeds);
            
        }
    }
}