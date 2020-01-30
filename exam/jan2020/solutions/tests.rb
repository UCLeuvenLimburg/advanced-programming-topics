# Are there enough ingredients for the recipe?
def enough_ingredients?(recipe, stock)
    recipe.all? do |ingredient, necessary|
        (stock[ingredient] || 0) >= necessary
    end
end

# Return list of recipes that can be made with ingredients
def cookable_recipes(recipes, stock)
    recipes.select do |name, ingredients|
        enough_ingredients?(ingredients, stock)
    end.keys.sort
end

def dish_count(recipe, stock)
    recipe.map do |ingredient, amount|
        (stock[ingredient] || 0) / amount
    end.min
end

# Compute cost of a recipe
def recipe_cost(recipe, ingredient_costs)
    recipe.map do |ingredient, amount|
        ingredient_costs[ingredient] * amount
    end.sum
end

# Most expensive recipe
def most_expensive_recipe(recipes, ingredient_costs)
    max_costs = recipes.keys.map do |recipe|
        recipe_cost(recipes[recipe], ingredient_costs)
    end

    if max_costs.count(max_costs.max) > 1
        abort 'Ambiguity in most_expensive_recipe'
    end

    recipes.keys.max_by do |recipe|
        recipe_cost(recipes[recipe], ingredient_costs)
    end
end

def most_used_ingredient(recipes)
    ingredients = recipes.flat_map do |name, ingredients|
        ingredients.keys
    end.uniq

    max_uses = ingredients.map do |ingredient|
        recipes.count do |_, req_ingredients|
            req_ingredients.has_key? ingredient
        end
    end

    if max_uses.count(max_uses.max) > 1
        abort "Ambiguity in most_used_ingredient: #{recipes}"
    end

    ingredients.max_by do |ingredient|
        recipes.count do |_, req_ingredients|
            req_ingredients.has_key? ingredient
        end
    end
end

def useless_ingredients(recipes, stock)
    ingredients = stock.keys

    ingredients.select do |ingredient|
        not recipes.any? do |name, recipe|
            recipe.has_key? ingredient
        end
    end.sort
end

def vegetarian_recipes(recipes, vegetarian_ingredients)
    recipes.select do |name, ingredients|
        ingredients.keys.all? do |ingredient|
            vegetarian_ingredients.include? ingredient
        end
    end.map do |name, ingredients|
        name
    end.sort
end
