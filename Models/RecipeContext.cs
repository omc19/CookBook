using Microsoft.EntityFrameworkCore;

namespace CookBook.Models
{
	public class RecipeContext : DbContext
	{
		public RecipeContext(DbContextOptions<RecipeContext> options)
			: base(options)
		{
		}

		public DbSet<Recipe> Recipes { get; set; } = null!;

		public DbSet<Ingredient> Ingredients { get; set; } = null!;

		public DbSet<RecipeIngredientRelationship> RecipeIngredientRelationship { get; set; } = null!;

		public DbSet<RecipeInstruction> RecipeInstructions { get; set; } = null!;
	}
}
