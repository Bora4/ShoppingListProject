using System.Collections.Generic;

namespace ShoppingList.Models.ViewModels
{
    public class Cart
    {
        public Cart()
        {
            Items = new();
        }

        public List<ViewItem> Items { get; set; }
        public string? Title { get; set; }
        public int? Id { get; set; }
    }
}
