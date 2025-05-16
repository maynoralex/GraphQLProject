using System;
using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services;

public class CategoryRepository(GraphQLDbContext dbContext) : ICategoryRepository
{
    public Category AddCategory(Category category)
    {
        dbContext.Categories.Add(category);
        dbContext.SaveChanges();
        return category;
    }

    public void DeleteCategory(int id)
    {
        var category = dbContext.Categories.Find(id);
        if (category != null)
        {
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
        }
    }

    public List<Category> GetAllCategories()
    {
        return dbContext.Categories.ToList();
    }

    public Category UpdateCategory(int id, Category category)
    {
        var existingCategory = dbContext.Categories.Find(id);
        if (existingCategory != null)
        {
            existingCategory.Name = category.Name;
            existingCategory.ImageUrl = category.ImageUrl;
            dbContext.SaveChanges();
        }
        return existingCategory;
    }
}
