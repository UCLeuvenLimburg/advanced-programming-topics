using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    // Write your solutions here
    public static class Solutions
    {
        public static bool EnoughIngredients(IDictionary<string, int> recipeIngredients, IDictionary<string, int> stock)
        {
            // TODO
            throw new NotImplementedException();
        }

        public static IEnumerable<string> CookableRecipes(IDictionary<string, IDictionary<string, int>> recipes, IDictionary<string, int> stock)
        {
            // TODO
            throw new NotImplementedException();
        }

        public static int DishCount(IDictionary<string, int> recipe, IDictionary<string, int> stock)
        {
            // TODO
            throw new NotImplementedException();
        }

        public static int RecipeCost(IDictionary<string, int> recipe, IDictionary<string, int> ingredientCosts)
        {
            // TODO
            throw new NotImplementedException();
        }

        public static string MostExpensiveRecipe(IDictionary<string, IDictionary<string, int>> recipes, IDictionary<string, int> ingredientCosts)
        {
            // TODO
            throw new NotImplementedException();
        }

        public static string MostUsedIngredient(IDictionary<string, IDictionary<string, int>> recipes)
        {
            // TODO
            throw new NotImplementedException();
        }

        public static IEnumerable<string> UselessIngredients(IDictionary<string, IDictionary<string, int>> recipes, IDictionary<string, int> stock)
        {
            // TODO
            throw new NotImplementedException();
        }

        public static IEnumerable<string> VegetarianRecipes(IDictionary<string, IDictionary<string, int>> recipes, IList<string> vegetarianIngredients)
        {
            // TODO
            throw new NotImplementedException();
        }
    }

    class App
    {
        static void Main(string[] args)
        {
            // You can select which tests to run
            var tests = new List<Tests> {
                new EnoughIngredientsTests(),
                new CookableRecipesTests(),
                new DishCountTests(),
                new RecipeCostTests(),
                new MostExpensiveRecipeTests(),
                new MostUsedIngredientTests(),
                new UselessIngredientsTests(),
                new VegetarianRecipesTests(),
            };

            foreach ( var test in tests )
            {
                test.RunTests();
            }
        }
    }

    abstract class Tests
    {
        private StreamReader reader;

        public string Read()
        {
            string line;

            while ( (line = reader.ReadLine()).StartsWith("#") );

            return line.TrimEnd();
        }

        public int ReadInt()
        {
            return int.Parse(Read());
        }

        public IDictionary<string, IDictionary<string, int>> ReadRecipes()
        {
            var n = ReadInt();
            var result = new Dictionary<string, IDictionary<string, int>>();

            for ( var i = 0; i != n; ++i )
            {
                var name = Read();
                var ingredients = ReadRecipeIngredients();

                result[name] = ingredients;
            }

            return result;
        }

        public IDictionary<string, int> ReadRecipeIngredients()
        {
            var n = ReadInt();
            var result = new Dictionary<string, int>();

            for ( var i = 0; i != n; ++i )
            {
                var ingredient = Read();
                var amount = ReadInt();

                result[ingredient] = amount;
            }

            return result;
        }

        public IDictionary<string, int> ReadStock()
        {
            return ReadRecipeIngredients();
        }

        public IDictionary<string, int> ReadIngredientCosts()
        {
            return ReadRecipeIngredients();
        }

        private string FindFile(string filename)
        {
            try
            {
                var directory = Directory.GetCurrentDirectory();

                while (!File.Exists(Path.Combine(directory, filename)))
                {
                    directory = Directory.GetParent(directory).FullName;
                }

                return Path.Combine(directory, filename);
            }
            catch ( Exception e )
            {
                Console.WriteLine($"Error while looking for file {filename}");
                throw e;
            }
        }

        private StreamReader OpenTestFile()
        {
            return File.OpenText(FindFile(this.FileName));
        }

        public void RunTests()
        {
            Console.WriteLine($"Testing {this.Description}");

            using (var reader = OpenTestFile())
            {
                this.reader = reader;
                string line = Read();

                while (line == "testcase")
                {
                    PerformTest();
                    line = Read();
                }
            }
        }

        public bool ReadBool()
        {
            return Read() == "true";
        }

        public IList<string> ReadStrings()
        {
            var n = ReadInt();

            return Enumerable.Range(0, n).Select(_ => Read()).ToList();
        }

        public string Show(int x)
        {
            return x.ToString();
        }

        public string Show(string x)
        {
            return x;
        }

        public string Show<T>(IEnumerable<T> xs)
        {
            return "[" + string.Join(", ", xs.Select(x => x.ToString())) + "]";
        }

        public string Show<K, V>(IDictionary<K, V> dictionary, Func<K, string> showKey = null, Func<V, string> showValue = null)
        {
            showKey = showKey ?? (x => x.ToString());
            showValue = showValue ?? (x => x.ToString());

            return "{" + string.Join(", ", dictionary.Select(pair => $"{showKey(pair.Key)} => {showValue(pair.Value)}" )) + "}";
        }

        public abstract string Description { get; }

        public abstract string FileName { get; }

        public abstract void PerformTest();

        public void Check<T>(T expected, T actual)
        {
            if ( !expected.Equals(actual) )
            {
                throw new TestException($"Expected {expected}, received {actual}");
            }
        }

        public void CheckSequence<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            if ( !expected.SequenceEqual(actual) )
            {
                throw new TestException($"Expected {Show(expected)}, received {Show(actual)}");
            }
        }
    }

    class TestException : Exception
    {
        public TestException(string message) : base(message)
        {

        }
    }

    class EnoughIngredientsTests : Tests
    {
        public override string Description => "EnoughIngredients";

        public override string FileName => "enough-ingredients.txt";

        public override void PerformTest()
        {
            var recipeIngredients = ReadRecipeIngredients();
            var stock = ReadStock();
            var expected = ReadBool();

            try
            {
                var actual = Solutions.EnoughIngredients(recipeIngredients, stock);
                Check(expected, actual);
                Console.WriteLine("PASS");
            }
            catch ( Exception e )
            {
                Console.WriteLine("FAIL");
                Console.WriteLine($"recipeIngredients = {Show(recipeIngredients)}");
                Console.WriteLine($"stock = {Show(stock)}");
                Console.WriteLine($"Expected: {expected}");
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }

    class CookableRecipesTests : Tests
    {
        public override string Description => "CookableRecipes";

        public override string FileName => "cookable-recipes.txt";

        public override void PerformTest()
        {
            var recipes = ReadRecipes();
            var stock = ReadStock();
            var expected = ReadStrings();

            try
            {
                var actual = Solutions.CookableRecipes(recipes, stock);
                CheckSequence(expected, actual);
                Console.WriteLine("PASS");
            }
            catch ( Exception e )
            {
                Console.WriteLine("FAIL");
                Console.WriteLine($"recipes = {Show(recipes, Show, d => Show<string, int>(d))}");
                Console.WriteLine($"stock = {Show(stock)}");
                Console.WriteLine($"Expected: {Show(expected)}");
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }

    class DishCountTests : Tests
    {
        public override string Description => "DishCount";

        public override string FileName => "dish-count.txt";

        public override void PerformTest()
        {
            var recipeIngredients = ReadRecipeIngredients();
            var stock = ReadStock();
            var expected = ReadInt();

            try
            {
                var actual = Solutions.DishCount(recipeIngredients, stock);
                Check(expected, actual);
                Console.WriteLine("PASS");
            }
            catch ( Exception e )
            {
                Console.WriteLine("FAIL");
                Console.WriteLine($"recipeIngredients = {Show(recipeIngredients)}");
                Console.WriteLine($"stock = {Show(stock)}");
                Console.WriteLine($"Expected: {expected}");
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }

    class RecipeCostTests : Tests
    {
        public override string Description => "RecipeCost";

        public override string FileName => "recipe-cost.txt";

        public override void PerformTest()
        {
            var recipeIngredients = ReadRecipeIngredients();
            var ingredientCosts = ReadIngredientCosts();
            var expected = ReadInt();

            try
            {
                var actual = Solutions.RecipeCost(recipeIngredients, ingredientCosts);
                Check(expected, actual);
                Console.WriteLine("PASS");
            }
            catch ( Exception e )
            {
                Console.WriteLine("FAIL");
                Console.WriteLine($"recipeIngredients = {Show(recipeIngredients)}");
                Console.WriteLine($"ingredientCosts = {Show(ingredientCosts)}");
                Console.WriteLine($"Expected: {expected}");
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }

    class MostExpensiveRecipeTests : Tests
    {
        public override string Description => "MostExpensiveRecipe";

        public override string FileName => "most-expensive-recipe.txt";

        public override void PerformTest()
        {
            var recipes = ReadRecipes();
            var ingredientCosts = ReadIngredientCosts();
            var expected = Read();

            try
            {
                var actual = Solutions.MostExpensiveRecipe(recipes, ingredientCosts);
                Check( actual, expected );
                Console.WriteLine("PASS");
            }
            catch ( Exception e )
            {
                Console.WriteLine("FAIL");
                Console.WriteLine($"recipes = {Show(recipes, Show, d => Show<string, int>(d))}");
                Console.WriteLine($"ingredientCosts = {Show(ingredientCosts)}");
                Console.WriteLine($"Expected: {expected}");
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }

    class MostUsedIngredientTests : Tests
    {
        public override string Description => "MostUsedIngredient";

        public override string FileName => "most-used-ingredient.txt";

        public override void PerformTest()
        {
            var recipes = ReadRecipes();
            var expected = Read();

            try
            {
                var actual = Solutions.MostUsedIngredient(recipes);
                Check(expected, actual);
                Console.WriteLine("PASS");
            }
            catch ( Exception e )
            {
                Console.WriteLine("FAIL");
                Console.WriteLine($"recipes = {Show(recipes, Show, d => Show<string, int>(d))}");
                Console.WriteLine($"Expected: {expected}");
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }

    class UselessIngredientsTests : Tests
    {
        public override string Description => "UselessIngredients";

        public override string FileName => "useless-ingredients.txt";

        public override void PerformTest()
        {
            var recipes = ReadRecipes();
            var stock = ReadStock();
            var expected = ReadStrings();

            try
            {
                var actual = Solutions.UselessIngredients(recipes, stock);
                CheckSequence(expected, actual);
                Console.WriteLine("PASS");
            }
            catch ( Exception e )
            {
                Console.WriteLine("FAIL");
                Console.WriteLine($"recipes = {Show(recipes, Show, d => Show<string, int>(d))}");
                Console.WriteLine($"stock = {Show(stock)}");
                Console.WriteLine($"Expected: {Show(expected)}");
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }

    class VegetarianRecipesTests : Tests
    {
        public override string Description => "VegetarianRecipes";

        public override string FileName => "vegetarian-recipes.txt";

        public override void PerformTest()
        {
            var recipes = ReadRecipes();
            var vegetarianIngredients = ReadStrings();
            var expected = ReadStrings();

            try
            {
                var actual = Solutions.VegetarianRecipes(recipes, vegetarianIngredients);
                CheckSequence(expected, actual);
                Console.WriteLine("PASS");
            }
            catch ( Exception e )
            {
                Console.WriteLine("FAIL");
                Console.WriteLine($"recipes = {Show(recipes, Show, d => Show<string, int>(d))}");
                Console.WriteLine($"vegetarianIngredients = {Show(vegetarianIngredients)}");
                Console.WriteLine($"Expected: {Show(expected)}");
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
