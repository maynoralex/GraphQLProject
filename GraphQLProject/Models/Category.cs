using System;
using System.Collections.ObjectModel;

namespace GraphQLProject.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    ICollection<Menu> Menus { get; set; }

}
