namespace ShoppingListAPI.Models.ViewModels
{
    public class ItemDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
    }

    public class CategoryDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
