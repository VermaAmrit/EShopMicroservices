using BuildingBocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
//add services to container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
})
.UseLightweightSessions();

var app = builder.Build();

//confgigure HTTP request pipeline
app.MapCarter();


app.Run();
