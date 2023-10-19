namespace CookBook.Models.DTO
{
    public class RecipeDto
    {
        public string Name { get; set; }

        public Dictionary<string, Measurement> Ingredients { get; set; }

        public List<string> Instructions { get; set; }
    }
}
