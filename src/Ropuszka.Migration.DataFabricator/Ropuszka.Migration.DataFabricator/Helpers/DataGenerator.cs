using Bogus;
using Ropuszka.Migration.Core.Models.Postgres;
using Ropuszka.Migration.Core.Services.Postgres;

namespace Ropuszka.Migration.DataFabricator.Helpers;

public class DataGenerator
{
    private readonly ClientService _clientService;
    private readonly DiscountService _discountService;
    private readonly ProductDiscountService _productDiscountService;
    private readonly ProductPurchaseService _productPurchaseService;
    private readonly ProductService _productService;
    private readonly PurchaseService _purchaseService;
    private readonly ShopService _shopService;
    private readonly Faker _faker;
    
    public DataGenerator(
        ClientService clientService,
        DiscountService discountService,
        ProductDiscountService productDiscountService,
        ProductPurchaseService productPurchaseService,
        ProductService productService,
        PurchaseService purchaseService,
        ShopService shopService
        )
    {
        _clientService = clientService;
        _discountService = discountService;
        _productDiscountService = productDiscountService;
        _productPurchaseService = productPurchaseService;
        _productService = productService;
        _purchaseService = purchaseService;
        _shopService = shopService;
        _faker = new Faker();
        Randomizer.Seed = new Random(123);
    }

    public ClientDto GenerateFakeClient()
    {
        var nextId = _clientService.GetNextId();
        var name = $"{_faker.Name.FirstName()} {_faker.Name.LastName()}";
        var dateOfBirth = _faker.Date.Between(new DateTime(1940, 01, 01), new DateTime(2003, 12, 31));
        var emailAddress = _faker.Internet.Email();
        return new ClientDto
        {
            Id = nextId,
            Name = name,
            DateOfBirth = dateOfBirth,
            EmailAddress = emailAddress
        };
    }

    public DiscountDto GenerateFakeDiscount()
    {
        var nextId = _discountService.GetNextId();
        var name = _faker.Lorem.Word();
        var percentage = Math.Round(_faker.Random.Double(0.00, 0.99), 2);
        var dateFrom = _faker.Date.Between(new DateTime(2019, 01, 01), new DateTime(2022, 12, 31));
        var dateTo = dateFrom.Add(TimeSpan.FromDays(_faker.Random.Int(1, 30)));
        return new DiscountDto
        {
            Id = nextId,
            Name = name,
            Percentage = percentage,
            DateFrom = dateFrom,
            DateTo = dateTo
        };
    }

    public ProductDto GenerateFakeProduct()
    {
        var nextId = _productService.GetNextId();
        var name = _faker.Commerce.ProductName();
        var price = Math.Round(_faker.Random.Double(1, 200), 2);
        var producerName = _faker.Company.CompanyName();
        return new ProductDto
        {
            Id = nextId,
            Name = name,
            Price = price,
            ProducerName = producerName
        };
    }
    
    public ProductDiscountDto GenerateFakeProductDiscount()
    {
        var nextId = _productDiscountService.GetNextId();
        var idProduct = _faker.Random.Int(1, _productService.GetNextId() - 1);
        var idDiscount = _faker.Random.Int(1, _discountService.GetNextId() - 1);
        return new ProductDiscountDto
        {
            Id = nextId,
            IdProduct = idProduct,
            IdDiscount = idDiscount
        };
    }
    
    public ProductPurchaseDto GenerateFakeProductPurchase()
    {
        var nextId = _productPurchaseService.GetNextId();
        var idProduct = _faker.Random.Int(1, _productService.GetNextId() - 1);
        var idPurchase = _faker.Random.Int(1, _purchaseService.GetNextId() - 1);
        var quantity = Math.Round(_faker.Random.Double(0.00, 99.99), 2);
        return new ProductPurchaseDto
        {
            Id = nextId,
            IdProduct = idProduct,
            IdPurchase = idPurchase,
            Quantity = quantity
        };
    }
    
    public PurchaseDto GenerateFakePurchase()
    {
        var nextId = _purchaseService.GetNextId();
        var date = _faker.Date.Between(new DateTime(2019, 01, 01), new DateTime(2022, 12, 31));
        var idShop = _faker.Random.Int(1, _shopService.GetNextId() - 1);
        var idClient = _faker.Random.Int(1, _clientService.GetNextId() - 1);
        return new PurchaseDto
        {
            Id = nextId,
            Date = date,
            IdShop = idShop,
            IdClient = idClient
        };
    }

    public ShopDto GenerateFakeShop()
    {
        var nextId = _shopService.GetNextId();
        var address = _faker.Address.StreetAddress();
        var phoneNumber = _faker.Phone.PhoneNumber("###-###-###");
        var emailAddress = _faker.Internet.Email();
        return new ShopDto
        {
            Id = nextId,
            Address = address,
            PhoneNumber = phoneNumber,
            EmailAddress = emailAddress
        };
    }
}
