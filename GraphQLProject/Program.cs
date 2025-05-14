using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Mutation;
using GraphQLProject.Query;
using GraphQLProject.Schema;
using GraphQLProject.Services;
using GraphQLProject.Type;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddTransient<IMenuRepository, MenuRepository>();
builder.Services.AddTransient<MenuType>();
builder.Services.AddTransient<MenuQuery>();
builder.Services.AddTransient<MenuMutation>();
builder.Services.AddTransient<MenuInputType>();
builder.Services.AddTransient<ISchema, MenuSchema>();

builder.Services.AddGraphQL( options => options.AddAutoSchema<ISchema>().AddSystemTextJson() );


var app = builder.Build();

app.UseHttpsRedirection();

app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();

app.Run();


