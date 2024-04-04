using BuildingBocks.CQRS;
using Catalog.API.Models;
using MediatR;
using System.Windows.Input;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateComandResult>;
    public record CreateComandResult(Guid Id);

    internal class CreateProductCommandHandler
        : ICommandHandler<CreateProductCommand, CreateComandResult>
    {
        public async Task<CreateComandResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //create product entity from command object
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };
            //save to database

            //return CreateComandResult result
            return new CreateComandResult(Guid.NewGuid());
        }
    }
}
