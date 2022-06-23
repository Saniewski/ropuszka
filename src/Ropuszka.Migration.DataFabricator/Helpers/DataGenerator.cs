using Bogus;
using Ropuszka.Migration.DataFabricator.Models;
using Ropuszka.Migration.DataFabricator.Services;

namespace Ropuszka.Migration.DataFabricator.Helpers;

public class DataGenerator
{
    private readonly RopuszkaService _ropuszkaService;
    private readonly Faker _faker;
    
    public DataGenerator()
    {
        _ropuszkaService = new RopuszkaService();
        _faker = new Faker();
        Randomizer.Seed = new Random(123);
    }

    public ClientDto GenerateFakeClient()
    {
        var nextId = _ropuszkaService.GetNextIdForTable("client");
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
        var nextId = _ropuszkaService.GetNextIdForTable("discount");
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
        var nextId = _ropuszkaService.GetNextIdForTable("product");
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
        var nextId = _ropuszkaService.GetNextIdForTable("product_discount");
        var idProduct = _faker.Random.Int(1, _ropuszkaService.GetNextIdForTable("product") - 1);
        var idDiscount = _faker.Random.Int(1, _ropuszkaService.GetNextIdForTable("discount") - 1);
        return new ProductDiscountDto
        {
            Id = nextId,
            IdProduct = idProduct,
            IdDiscount = idDiscount
        };
    }
    
    public ProductPurchaseDto GenerateFakeProductPurchase()
    {
        var nextId = _ropuszkaService.GetNextIdForTable("product_purchase");
        var idProduct = _faker.Random.Int(1, _ropuszkaService.GetNextIdForTable("product") - 1);
        var idPurchase = _faker.Random.Int(1, _ropuszkaService.GetNextIdForTable("purchase") - 1);
        return new ProductPurchaseDto
        {
            Id = nextId,
            IdProduct = idProduct,
            IdPurchase = idPurchase
        };
    }
    
    public PurchaseDto GenerateFakePurchase()
    {
        var nextId = _ropuszkaService.GetNextIdForTable("purchase");
        var date = _faker.Date.Between(new DateTime(2019, 01, 01), new DateTime(2022, 12, 31));
        var idShop = _faker.Random.Int(1, _ropuszkaService.GetNextIdForTable("shop") - 1);
        var idClient = _faker.Random.Int(1, _ropuszkaService.GetNextIdForTable("client") - 1);
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
        var nextId = _ropuszkaService.GetNextIdForTable("shop");
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
