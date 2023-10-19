using CookBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Repositories
{
	public class RecipeRepository : IRecipeRepository
	{
		private readonly RecipeContext _dbContext;

		public RecipeRepository(RecipeContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<ActionResult<Recipe>> PostRecipeAsync(Recipe recipe)
		{
			await _dbContext.AddAsync(recipe);
			await _dbContext.SaveChangesAsync();

			return recipe;
		}
		public async Task PostIngredientAsync (Ingredient ingredient)
		{
			await _dbContext.AddAsync(ingredient);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<ActionResult<Ingredient>> CheckIngredientExistAsnyc(Ingredient ingredient)
		{
			//var ingredientResult = await _dbContext.Ingredients.FindAsync(ingredient);
			var ingredientResult = await _dbContext.Ingredients.FirstOrDefaultAsync(ingredientRecord => ingredientRecord.Name == ingredient.Name ,new CancellationToken());

			return ingredientResult;
		}

		public async Task PostRecipeIngredientAsync(RecipeIngredientRelationship recipeIngredient)
		{
			await _dbContext.AddAsync(recipeIngredient);
			await _dbContext.SaveChangesAsync();
		}

		public async Task PostRecipeInstructionsAsync()
		{
			throw new NotImplementedException();
		}

	}

	public interface IRecipeRepository 
	{
		Task<ActionResult<Recipe>> PostRecipeAsync(Recipe recipe);


		Task PostIngredientAsync(Ingredient ingredient);

		Task<ActionResult<Ingredient>> CheckIngredientExistAsnyc(Ingredient ingredient);

		Task PostRecipeIngredientAsync(RecipeIngredientRelationship recipeIngredient);

		Task PostRecipeInstructionsAsync();
	}

}
