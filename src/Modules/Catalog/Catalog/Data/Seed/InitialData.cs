namespace Catalog.Data.Seed;

public static class InitialData
{
    public static List<Product> Products => new List<Product>
    {
        Product.Create(Guid.NewGuid(), "Product1", new List<string> { "category1" }, "Description for Product 1", "imagefile1", 100),
        Product.Create(Guid.NewGuid(), "Product2", new List<string> { "category1" }, "Description for Product 2", "imagefile2", 200),
        Product.Create(Guid.NewGuid(), "Product3", new List<string> { "category2" }, "Description for Product 3", "imagefile3", 300),
        Product.Create(Guid.NewGuid(), "Product4", new List<string> { "category2" }, "Description for Product 4", "imagefile4", 400),
        Product.Create(Guid.NewGuid(), "Product5", new List<string> { "category2" }, "Description for Product 5", "imagefile5", 500)
    };
}
