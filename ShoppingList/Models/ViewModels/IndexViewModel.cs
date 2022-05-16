using ShoppingListAPI.Models;
using System.Collections.Generic;

namespace ShoppingList.Models.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Categories = new List<Category>();
            Cart = new();
        }

        public List<Category> Categories { get; set; }
        public Cart Cart { get; set; }


    }
}
