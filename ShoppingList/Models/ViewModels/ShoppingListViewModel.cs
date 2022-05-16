using ShoppingListAPI.Models;
using System.Collections.Generic;

namespace ShoppingList.Models.ViewModels
{
    public class ShoppingListViewModel
    {
        public ShoppingListViewModel()
        {
            allshoppinglists = new List<ShoppingListAPI.Models.ShoppingList>();
            allshoppinglistdetails = new List<ShoppingListDetail>();
        }

        public List<ShoppingListAPI.Models.ShoppingList> allshoppinglists { get; set; }
        public List<ShoppingListDetail> allshoppinglistdetails { get; set; }    
    }
}
