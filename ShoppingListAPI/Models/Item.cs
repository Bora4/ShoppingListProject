using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingListAPI.Models
{
    public partial class Item
    {
        public Item()
        {
            ShoppingListDetails = new HashSet<ShoppingListDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ShoppingListDetail> ShoppingListDetails { get; set; }
    }
}
