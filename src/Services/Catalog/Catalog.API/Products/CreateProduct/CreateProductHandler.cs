

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateComandResult>;
    public record CreateComandResult(Guid Id);

    //fluent validation
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.ImageFile).NotEmpty().GreaterThan("Price must be greater than 0");
        }

        internal class CreateProductCommandHandler(IDocumentSession session)
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
                session.Store(product);
                await session.SaveChangesAsync(cancellationToken);

                //return CreateComandResult result
                return new CreateComandResult(product.Id);
            }
        }
    }
}
