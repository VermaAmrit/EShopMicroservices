var builder = WebApplication.CreateBuilder(args);

//add services to container

var app = builder.Build();

//confgigure HTTP request pipeline



app.Run();
