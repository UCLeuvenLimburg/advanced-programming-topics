from textwrap import dedent
import functools
from traceback import format_exc


# Write your solutions here
def enough_ingredients(recipe, stock):
    # TODO
    pass

def cookable_recipes(recipes, stock):
    # TODO
    pass

def dish_count(recipe, stock):
    # TODO
    pass

def recipe_cost(recipe, ingredient_costs):
    # TODO
    pass

def most_expensive_recipe(recipes, ingredient_costs):
    # TODO
    pass

def most_used_ingredient(recipes):
    # TODO
    pass

def useless_ingredients(recipes, stock):
    # TODO
    pass

def vegetarian_recipes(recipes, vegetarian_ingredients):
    # TODO
    pass


def tests():
    # You can select which tests to run here
    return [
        EnoughIngredientsTests(),
        CookableRecipesTests(),
        DishCountTests(),
        RecipeCostTests(),
        MostExpensiveRecipeTests(),
        MostUsedIngredientTests(),
        UselessIngredientsTests(),
        VegetarianRecipesTests(),
    ]


class TestException(Exception):
    def __init__(self, message):
        self.message = message

def asserteq(expected, actual):
    if expected != actual:
        raise TestException(f"Expected {expected}, received {actual}")

class Tests:
    def read(self):
        line = self.__file.readline()
        while line.startswith('#'):
            line = self.__file.readline()
        return line.rstrip()

    def read_int(self):
        return int(self.read())

    def read_recipes(self):
        n = self.read_int()
        result = {}
        for _ in range(n):
            name = self.read()
            ingredients = self.read_recipe_ingredients()
            result[name] = ingredients
        return result

    def read_recipe_ingredients(self):
        n = self.read_int()
        result = {}
        for _ in range(n):
            ingredient = self.read()
            amount = self.read_int()
            result[ingredient] = amount
        return result

    def read_stock(self):
        return self.read_recipe_ingredients()

    def read_ingredient_costs(self):
        return self.read_recipe_ingredients()

    def read_bool(self):
        return self.read() == 'true'

    def read_strings(self):
        n = self.read_int()
        return [ self.read() for _ in range(n) ]

    def run_tests(self):
        print(f"Testing {self.description}")
        with open(self.filename) as file:
            self.__file = file
            line = self.read()
            while line == 'testcase':
                self.perform_testcase()
                line = self.read()

class EnoughIngredientsTests(Tests):
    @property
    def description(self):
        return 'enough_ingredients'

    @property
    def filename(self):
        return 'enough-ingredients.txt'

    def perform_testcase(self):
        recipe_ingredients = self.read_recipe_ingredients()
        stock = self.read_stock()
        expected = self.read_bool()

        try:
            asserteq(expected, enough_ingredients(recipe_ingredients, stock))
            print('PASS')
        except Exception as e:
            print(dedent(f'''
            FAILURE
            Recipe: {recipe_ingredients}
            Stock: {stock}
            Expected: {expected}
            Error: {e}
            ''').rstrip())

class CookableRecipesTests(Tests):
    @property
    def description(self):
        return 'cookable_recipes'

    @property
    def filename(self):
        return 'cookable-recipes.txt'

    def perform_testcase(self):
        recipes = self.read_recipes()
        stock = self.read_stock()
        expected = self.read_strings()

        try:
            asserteq(expected, cookable_recipes(recipes, stock))
            print('PASS')
        except Exception as e:
            print(dedent(f'''
            FAILURE
            Recipes: {recipes}
            Stock: {stock}
            Expected: {expected}
            Error: {e}
            ''').rstrip())

class DishCountTests(Tests):
    @property
    def description(self):
        return 'dish_count'

    @property
    def filename(self):
        return 'dish-count.txt'

    def perform_testcase(self):
        recipe = self.read_recipe_ingredients()
        stock = self.read_stock()
        expected = self.read_int()

        try:
            asserteq(expected, dish_count(recipe, stock))
            print('PASS')
        except Exception as e:
            print(dedent(f'''
            FAILURE
            Recipe: {recipe}
            Stock: {stock}
            Expected: {expected}
            Error: {e}
            ''').rstrip())


class RecipeCostTests(Tests):
    @property
    def description(self):
        return 'recipe_cost'

    @property
    def filename(self):
        return 'recipe-cost.txt'

    def perform_testcase(self):
        recipe = self.read_recipe_ingredients()
        ingredient_costs = self.read_ingredient_costs()
        expected = self.read_int()

        try:
            asserteq(expected, recipe_cost(recipe, ingredient_costs))
            print('PASS')
        except Exception as e:
            print(dedent(f'''
            FAILURE
            Recipe: {recipe}
            Ingredient costs: {ingredient_costs}
            Expected: {expected}
            Error: {e}
            ''').rstrip())


class MostExpensiveRecipeTests(Tests):
    @property
    def description(self):
        return 'most_expensive_recipe'

    @property
    def filename(self):
        return 'most-expensive-recipe.txt'

    def perform_testcase(self):
        recipes = self.read_recipes()
        ingredient_costs = self.read_ingredient_costs()
        expected = self.read()

        try:
            asserteq(expected, most_expensive_recipe(recipes, ingredient_costs))
            print('PASS')
        except Exception as e:
            print(dedent(f'''
            FAILURE
            Recipes: {recipes}
            Ingredient costs: {ingredient_costs}
            Expected: {expected}
            Error: {e}
            ''').rstrip())

class MostUsedIngredientTests(Tests):
    @property
    def description(self):
        return 'most_used_ingredient'

    @property
    def filename(self):
        return 'most-used-ingredient.txt'

    def perform_testcase(self):
        recipes = self.read_recipes()
        expected = self.read()

        try:
            asserteq(expected, most_used_ingredient(recipes))
            print('PASS')
        except Exception as e:
            print(dedent(f'''
            FAILURE
            Recipes: {recipes}
            Expected: {expected}
            Error: {e}
            ''').rstrip())


class UselessIngredientsTests(Tests):
    @property
    def description(self):
        return 'useless_ingredients'

    @property
    def filename(self):
        return 'useless-ingredients.txt'

    def perform_testcase(self):
        recipes = self.read_recipes()
        stock = self.read_stock()
        expected = self.read_strings()

        try:
            asserteq(expected, useless_ingredients(recipes, stock))
            print('PASS')
        except Exception as e:
            print(dedent(f'''
            FAILURE
            Recipes: {recipes}
            Stock: {stock}
            Expected: {expected}
            Error: {e}
            ''').rstrip())

class VegetarianRecipesTests(Tests):
    @property
    def description(self):
        return 'vegetarian_recipes'

    @property
    def filename(self):
        return 'vegetarian-recipes.txt'

    def perform_testcase(self):
        recipes = self.read_recipes()
        vegetarian_ingredients = self.read_strings()
        expected = self.read_strings()

        try:
            asserteq(expected, vegetarian_recipes(recipes, vegetarian_ingredients))
            print('PASS')
        except Exception as e:
            print(dedent(f'''
            FAILURE
            Recipes: {recipes}
            Vegetarian ingredients: {vegetarian_ingredients}
            Expected: {expected}
            Error: {e}
            ''').rstrip())


for test in tests():
    test.run_tests()