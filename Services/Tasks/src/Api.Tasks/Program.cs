using Api.Tasks;
using Infrastructure.Tasks;
using Logic.Tasks;

var builder = WebApplication.CreateBuilder(args) 
    .AddInfrastructure() 
    .AddLogic() 
    .AddApi();

var app = builder.Build();
app.UseApi();

await app.RunAsync();
