using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Type;

public class CategoryType : ObjectGraphType<Category>
{
    public CategoryType(IMenuRepository menuRepository)
    {
        Field(x => x.Id);
        Field(x => x.Name);
        Field(x => x.ImageUrl);
        Field<ListGraphType<MenuType>>("Menus").Resolve(context =>
        {
            return menuRepository.GetAllMenu().Where(m => m.CategoryId == context.Source.Id);
        });
    }
}
