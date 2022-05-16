using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingListAPI.Models
{
    public partial class ShoppingList
    {
        public ShoppingList()
        {
            ShoppingListDetails = new HashSet<ShoppingListDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ShoppingListDetail> ShoppingListDetails { get; set; }
    }
}
