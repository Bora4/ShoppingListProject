using System.Collections.Generic;

namespace ShoppingListAPI.Models.ViewModels
{
    public class ShoppingListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

    }

    public class UserDTO
    {
        public int Id { get; set; }
    }
}
