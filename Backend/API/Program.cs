using API.GraphQL;
using GraphQL.Server.Ui.Voyager;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var AllowSpecificOrigns = "_allowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<OMAContext>(options => {
    options.UseInMemoryDatabase("InMemoryDB");
});

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
