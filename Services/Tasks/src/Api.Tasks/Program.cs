using Infrastructure.Tasks;
using Logic.Tasks;

var builder = WebApplication.CreateBuilder(args);
builder.AddInfrastructure();
builder.AddLogic();

var app = builder.Build();
app.UseInfrastructure();

app.Run();
