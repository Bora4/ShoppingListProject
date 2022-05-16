using ShoppingListAPI.Models;
using System.Collections.Generic;

namespace ShoppingList.Models.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            ShoppingList = new List<ViewItem>();
            ItemList = new List<Item>();
        }

        public string CategoryName { get; set; }
        public List<ViewItem> ShoppingList { get; set; }
        public List<Item> ItemList { get; set; }
    }
}
