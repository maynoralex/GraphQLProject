using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services;

public class MenuRepository(GraphQLDbContext dbContext): IMenuRepository
{
    // This is a mock implementation of the IMenuRepository interface.
    // private static List<Menu> MenuList = new List<Menu>()
    //     {
    //         new Menu() { Id = 1, Name = "Classic Burger", Description="A juicy chicken burger with lettuce and cheese" , Price = 8.99},
    //         new Menu() { Id = 2, Name = "Margherita Pizza", Description = "Tomato, mozzarella, and basil pizza", Price = 10.50 },
    //         new Menu() { Id = 3, Name = "Grilled Chicken Salad", Description = "Fresh garden salad with grilled chicken", Price = 7.95 },
    //         new Menu() { Id = 4, Name = "Pasta Alfredo", Description = "Creamy Alfredo sauce with fettuccine pasta", Price = 12.75 },
    //         new Menu() { Id = 5, Name = "Chocolate Brownie Sundae", Description = "Warm chocolate brownie with ice cream and fudge", Price = 6.99 },

    //     };

    public List<Menu> GetAllMenu()
    {
        return dbContext.Menus.ToList();
    }

    public Menu GetMenuById(int id)
    {
        return dbContext.Menus.Find(id);
    }
    public Menu AddMenu(Menu menu)
    {
        dbContext.Menus.Add(menu);
        dbContext.SaveChanges();
        return menu;
    }
    public Menu UpdateMenu(int id, Menu menu)
    {
        var menuitem = dbContext.Menus.Find(id);
        menuitem.Name = menu.Name;
        menuitem.Description = menu.Description;
        menuitem.Price = menu.Price;
        dbContext.SaveChanges();
        return menuitem;
    }
    public void DeleteMenu(int id)
    {
        var menuitem = dbContext.Menus.Find(id);
        dbContext.Menus.Remove(menuitem);
        dbContext.SaveChanges();
    }


}
