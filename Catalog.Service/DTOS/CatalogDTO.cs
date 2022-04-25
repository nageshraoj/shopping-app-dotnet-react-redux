namespace Catalog.Service.DTOS;

public class CatalogDTO
{
#nullable disable
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Brand { get; set; }
    public double Rating { get; set; }
    public string Type { get; set; }
    public string PictureUrl { get; set; }
    public int QuantityInStock { get; set; }



}