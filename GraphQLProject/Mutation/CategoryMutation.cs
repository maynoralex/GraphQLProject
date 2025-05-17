using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;

namespace GraphQLProject.Mutation;

public class CategoryMutation : ObjectGraphType
{
    public CategoryMutation(ICategoryRepository categoryRepository)
    {
        Field<CategoryType>("AddCategory").Arguments(new QueryArguments(new QueryArgument<CategoryInputType> { Name = "category" })).Resolve( context =>
        {
            return categoryRepository.AddCategory(context.GetArgument<Category>("category"));
        });
        Field<CategoryType>("UpdateCategory").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryId" },
            new QueryArgument<CategoryInputType> { Name = "category" })).Resolve( context =>
        {
            
            return categoryRepository.UpdateCategory(context.GetArgument<int>("categoryId"), context.GetArgument<Category>("category"));
        });
        Field<StringGraphType>("DeleteCategory").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryId" })).Resolve( context =>
        {
            var categoryId = context.GetArgument<int>("categoryId");
            categoryRepository.DeleteCategory(categoryId);
            return $"The category with Id: {categoryId} has been Deleted";
        });
    }
}
