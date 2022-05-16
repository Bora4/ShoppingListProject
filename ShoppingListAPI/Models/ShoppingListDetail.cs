using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingListAPI.Models
{
    public partial class ShoppingListDetail
    {
        public int ShoppingListId { get; set; }
        public int ItemId { get; set; }
        public int? Quantity { get; set; }

        public virtual Item Item { get; set; }
        public virtual ShoppingList ShoppingList { get; set; }
    }
}
