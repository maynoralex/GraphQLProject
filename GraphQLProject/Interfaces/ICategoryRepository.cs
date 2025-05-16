using GraphQLProject.Models;

namespace GraphQLProject.Interfaces;

public interface ICategoryRepository
{
    List<Category> GetAllCategories();

    Category AddCategory(Category category);

    Category UpdateCategory(int id,Category category);

    void DeleteCategory(int id);

}
