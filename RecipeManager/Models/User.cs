namespace RecipeManager.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<Recipe> Recepes { get; } = new List<Recipe>();
    }
}
