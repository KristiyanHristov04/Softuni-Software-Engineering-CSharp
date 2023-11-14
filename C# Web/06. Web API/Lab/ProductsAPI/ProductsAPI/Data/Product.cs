namespace ProductsAPI.Data
{
    public class Product
    {
        public int Id { get; init; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

    }
}
