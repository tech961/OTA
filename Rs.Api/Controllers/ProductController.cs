using System.Net.Http.Headers;
using Newtonsoft.Json;
using Rs.Application.Common.Models;
using Rs.Application.Features.Products.CommandHandlers.AddProduct;
using Rs.Application.Features.Products.QueryHandlers.GetProducts;

namespace Rs.Api.Controllers;

public class ProductController : BaseController
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    
    [HttpGet]
    public async Task<ActionResult<PaginatedList<GetProductsResponse>>> GetProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20, CancellationToken cancellationToken = default)
    {
        var query = new GetProductsQuery(pageNumber, pageSize);
        var result = await Mediator.Send(query, cancellationToken);
        return result.ToActionResult();
    }

    [HttpPost]
    public async Task<ActionResult<AddProductResponse>> AddProduct([FromBody] AddProductCommand command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);
        return result.ToActionResult();
    }
    
    /// <summary>
    /// همگام‌سازی محصولات از Shopify
    /// </summary>
    [HttpGet("shopify-sync")]
    public async Task<IActionResult> SyncFromShopify(CancellationToken cancellationToken)
    {
        string shopUrl = "https://ccyuxz-vm.myshopify.com";
        string accessToken = "shpat_xxxxxxxxxxxxx"; // توکن Shopify

        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri($"{shopUrl}/admin/api/2023-10/");
        client.DefaultRequestHeaders.Add("X-Shopify-Access-Token", accessToken);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await client.GetAsync("products.json?limit=10", cancellationToken);

        if (!response.IsSuccessStatusCode)
            return BadRequest(await response.Content.ReadAsStringAsync(cancellationToken));

        var json = await response.Content.ReadAsStringAsync(cancellationToken);

        var shopifyProducts = JsonConvert.DeserializeObject<ShopifyProductResponse>(json);

        return Ok(shopifyProducts);
    }
}

// مدل موقت برای گرفتن داده از Shopify
public class ShopifyProductResponse
{
    public List<ShopifyProduct> Products { get; set; } = new();
}

public class ShopifyProduct
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Body_Html { get; set; }
    public string Vendor { get; set; }
    public string Product_Type { get; set; }
    public List<ShopifyVariant> Variants { get; set; } = new();
    public List<ShopifyImage> Images { get; set; } = new();
}

public class ShopifyVariant
{
    public long Id { get; set; }
    public string Price { get; set; }
    public string Sku { get; set; }
    public int Inventory_Quantity { get; set; }
}

public class ShopifyImage
{
    public string Src { get; set; }
}