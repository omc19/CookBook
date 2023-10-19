namespace CookBook.Models
{
	public class RecipeInstruction
	{
		public int RecipeInstructionId { get; set; }

		public int RecipeId { get; set; }

		public int Order { get; set; }

		public string Instruction { get; set; }
	}
}
