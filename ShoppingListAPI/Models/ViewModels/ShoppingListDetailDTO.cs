namespace ShoppingListAPI.Models.ViewModels
{
    public class ShoppingListDetailDTO
    {
        public int ShoppingListId { get; set; }
        public int ItemId { get; set; }
        public int? Quantity { get; set; }

        public ItemDTO Item { get; set; }
    }
}
