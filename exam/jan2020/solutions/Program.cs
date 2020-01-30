using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public static class Solutions
    {
        public static bool EnoughIngredients(IDictionary<string, int> recipeIngredients, IDictionary<string, int> stock)
        {
            return recipeIngredients.All( pair => stock.ContainsKey(pair.Key) ? stock[pair.Key] >= pair.Value : pair.Value == 0 );
        }

        public static IEnumerable<string> CookableRecipes(IDictionary<string, IDictionary<string, int>> recipes, IDictionary<string, int> stock)
        {
            return recipes.Keys.Where(name => EnoughIngredients(recipes[name], stock)).OrderBy(x => x);
        }

        public static int DishCount(IDictionary<string, int> recipe, IDictionary<string, int> stock)
        {
            return recipe.Select( pair => (stock.ContainsKey(pair.Key) ? stock[pair.Key] : 0) / pair.Value ).Min();
        }

        public static int RecipeCost(IDictionary<string, int> recipe, IDictionary<string, int> ingredientCosts)
        {
            return recipe.Select(pair => ingredientCosts[pair.Key] * pair.Value).Sum();
        }

        public static string MostExpensiveRecipe(IDictionary<string, IDictionary<string, int>> recipes, IDictionary<string, int> ingredientCosts)
        {
            return recipes.OrderByDescending(pair => RecipeCost(pair.Value, ingredientCosts)).First().Key;
        }

        public static string MostUsedIngredient(IDictionary<string, IDictionary<string, int>> recipes)
        {
            var ingredients = new HashSet<string>(from recipe in recipes.Values
                                                  from ing in recipe.Keys
                                                  select ing);

            return ingredients.OrderByDescending(i => recipes.Count(pair => pair.Value.ContainsKey(i))).First();
        }

        public static IEnumerable<string> UselessIngredients(IDictionary<string, IDictionary<string, int>> recipes, IDictionary<string, int> stock)
        {
            var ingredients = new HashSet<string>(from recipe in recipes.Values
                                                  from ing in recipe.Keys
                                                  select ing);

            return stock.Keys.Where(i => !ingredients.Contains(i)).OrderBy(x => x);
        }

        public static IEnumerable<string> VegetarianRecipes(IDictionary<string, IDictionary<string, int>> recipes, IList<string> vegetarianIngredients)
        {
            return recipes.Keys.Where(name => recipes[name].Keys.All(i => vegetarianIngredients.Contains(i))).OrderBy(x => x);
        }
    }
}
