using System.Collections.Generic;

namespace ShoppingListAPI.Models
{
    public partial class User
    {
        public User()
        {
            ShoppingLists = new HashSet<ShoppingList>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
