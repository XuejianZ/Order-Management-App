using API.GraphQL;
using GraphQL.Server.Ui.Voyager;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Services;
using Core.Interfaces;

var AllowSpecificOrigns = "_allowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<OMAContext>(options => {
    options.UseInMemoryDatabase("InMemoryDB");
});
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();
//graphql
builder.Services
 .AddGraphQLServer()
 .AddQueryType<Query>()
 .AddFiltering();

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
/*builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
*/
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigns,
        policy => 
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

/* Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())y
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

/*app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();*/

app.UseCors(AllowSpecificOrigns);
app.MapGraphQL();
app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions{GraphQLEndPoint = "/graphql"});
app.Run();
