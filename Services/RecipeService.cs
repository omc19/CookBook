using CookBook.Models;
using CookBook.Models.DTO;
using CookBook.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Services
{
	public class RecipeService : IRecipeService
	{
		public readonly IRecipeRepository _recipeRepository;

		public RecipeService(IRecipeRepository recipeRepository)
		{
			_recipeRepository = recipeRepository;
		}

		public async Task<ActionResult<Recipe>> PostRecipeAsync(RecipeDto recipeDto)
		{
			var recipe = new Recipe 
			{ 
				Name = recipeDto.Name 
			};

			var createdRecipe = await _recipeRepository.PostRecipeAsync(recipe);
			Console.WriteLine(recipe.RecipeId);

			foreach (var ingredientItem in recipeDto.Ingredients)
			{
				var ingredient = new Ingredient { Name = ingredientItem.Key };
				var ingredientRecord = await _recipeRepository.CheckIngredientExistAsnyc(ingredient);

				var recipeIngredient = new RecipeIngredientRelationship
				{
					//IngredientId = ingredientRecord.Value.IngredientId,
					RecipeId = recipe.RecipeId,
					Amount = ingredientItem.Value.Amount,
					Measurement = ingredientItem.Value.UnitOfMeasurement
				};

				if (ingredientRecord.Value == null) 
				{
					await _recipeRepository.PostIngredientAsync(ingredient);
					recipeIngredient.IngredientId = ingredient.IngredientId;
					await _recipeRepository.PostRecipeIngredientAsync(recipeIngredient);
				}

				else
				{
					recipeIngredient.IngredientId = ingredientRecord.Value.IngredientId;
					await _recipeRepository.PostRecipeIngredientAsync(recipeIngredient);
				}

				//await _recipeRepository.PostRecipeIngredientAsync(recipeIngredient);
			}

			return createdRecipe;
		}
	}

	public interface IRecipeService
	{
		Task<ActionResult<Recipe>> PostRecipeAsync(RecipeDto recipeDto);
	}
}
