using BuildingBocks.CQRS;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    
    public record CreateComandReponse(Guid Id);

    public class CreateProductEndpoint
    {
    }
}
