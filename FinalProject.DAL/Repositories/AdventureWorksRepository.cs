using FinalProject.DAL.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FinalProject.DAL.Repositories
{
	/// <summary>
	/// Needs Microsoft.extensions.Http
	/// </summary>
	public class AdventureWorksRepository
	{
		private readonly IHttpClientFactory clientFactory;
		ILogger<AdventureWorksRepository> logger;
		AdventureWorksSettings settings;

		public AdventureWorksRepository(IOptions<AdventureWorksSettings> settings, IHttpClientFactory clientFactory, ILogger<AdventureWorksRepository> logger)
		{
			this.clientFactory = clientFactory;
			this.logger = logger;
			this.settings = settings.Value;
		}

		public IEnumerable<Category> GetAllCategories()
		{
			string url = settings.categoryUrl;
			var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, new Uri(url))
			{
				Headers =
				{
					{ "Accept", "application/json" },
					{ "User-Agent", "Group-99" }
				}
			};

			var httpclient = clientFactory.CreateClient();

			var httpResponseMessage = httpclient.SendAsync(httpRequestMessage).Result;
			
			httpResponseMessage.EnsureSuccessStatusCode();

			logger.LogDebug("Got categories");

			var result = httpResponseMessage.Content.ReadAsStringAsync().Result;

			IEnumerable<Category>  data = JsonConvert.DeserializeObject<IEnumerable<Category>>(result) ?? new List<Category>();

			return data;

		}
		public Product GetProductById(int productId)
    	{
        	string productUrl = $"{settings.productsUrl}/{productId}"; // Assuming a URL for getting a product by ID
        	var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, new Uri(productUrl))
        	{
            Headers =
            {
                { "Accept", "application/json" },
                { "User-Agent", "Group-99" }
            }
        	};
        	var httpClient = clientFactory.CreateClient();
        	var httpResponseMessage = httpClient.SendAsync(httpRequestMessage).Result;
        	if (httpResponseMessage.IsSuccessStatusCode)
        	{
            	var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
            	Product product = JsonConvert.DeserializeObject<Product>(result);
            	return product;
        	}
        	else
        	{
            // Handle scenario when product is not found or request fails
            logger.LogError($"Failed to retrieve product with ID: {productId}. Status code: {httpResponseMessage.StatusCode}");
            return null; // Or throw an exception or handle the error accordingly
        	}
    	}
		public IEnumerable<Product> GetAllProducts()
    	{
        string productsUrl = settings.productsUrl; // Assuming a URL for getting all products
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, new Uri(productsUrl))
        {
            Headers =
            {
                { "Accept", "application/json" },
                { "User-Agent", "Group-99" }
            }
        };
		
        var httpClient = clientFactory.CreateClient();
        var httpResponseMessage = httpClient.SendAsync(httpRequestMessage).Result;
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
            IEnumerable<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
            return products;
        }
        else
        {
            // Handle scenario when products are not retrieved or request fails
            logger.LogError($"Failed to retrieve products. Status code: {httpResponseMessage.StatusCode}");
            return Enumerable.Empty<Product>(); // Or throw an exception or handle the error accordingly
        }
    }
	}
}