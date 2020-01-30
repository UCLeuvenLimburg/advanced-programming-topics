from textwrap import dedent
import functools
from traceback import format_exc


# Write your solutions here
def enough_ingredients(recipe, stock):
    return all( stock.get(ingredient, 0) >= recipe[ingredient] for ingredient in recipe.keys()  )

def cookable_recipes(recipes, stock):
    return sorted([ name for (name, ingr) in recipes.items() if enough_ingredients(ingr, stock) ])

def dish_count(recipe, stock):
    return min( stock.get(i, 0) // amount for (i, amount) in recipe.items() )

def recipe_cost(recipe, ingredient_costs):
    return sum( ingredient_costs[i] * amount for (i, amount) in recipe.items() )

def most_expensive_recipe(recipes, ingredient_costs):
    return max( [ id for id in recipes.keys() ], key=lambda id: recipe_cost(recipes[id], ingredient_costs) )

def most_used_ingredient(recipes):
    ingredients = set( ingredient for recipe in recipes.values() for ingredient in recipe.keys() )
    return max( [ ingredient for ingredient in ingredients ], key=lambda i: sum(1 for r in recipes.values() if i in r ) )

def useless_ingredients(recipes, stock):
    ingredients = stock.keys()
    return sorted([ i for i in ingredients if not any( i in r for r in recipes.values() ) ])

def vegetarian_recipes(recipes, vegetarian_ingredients):
    return sorted([ id for (id, r) in recipes.items() if all(i in vegetarian_ingredients for i in r ) ])
