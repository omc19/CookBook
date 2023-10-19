using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Models
{
	public class RecipeIngredientRelationship
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int RecipeIngredientRelationshipId { get; set; }

		public int IngredientId { get; set; }

		public int RecipeId { get; set; }

		public string Amount { get; set; }

		public string? Measurement { get; set; }
	}
}
