# Write your solutions here
def enough_ingredients?(recipe, stock)
    # TODO
end

def cookable_recipes(recipes, stock)
    # TODO
end

def dish_count(recipe, stock)
    # TODO
end

def recipe_cost(recipe, ingredient_costs)
    # TODO
end

def most_expensive_recipe(recipes, ingredient_costs)
    # TODO
end

def most_used_ingredient(recipes)
    # TODO
end

def useless_ingredients(recipes, stock)
    # TODO
end

def vegetarian_recipes(recipes, vegetarian_ingredients)
    # TODO
end


# You can choose which tests to run here
def tests
    [
        EnoughIngredientsTests.new,
        CookableRecipesTests.new,
        DishCountTests.new,
        RecipeCostTests.new,
        MostExpensiveRecipeTests.new,
        MostUsedIngredientTests.new,
        UselessIngredientsTests.new,
        VegetarianRecipesTests.new,
    ]
end



class TestFailed < StandardError
end

def run_tests(tests)
    tests.each(&:run_tests)
end

class Tests
    def read
        while (line = @in.gets).start_with? '#'
        end

        line.chomp
    end

    def read_recipe_ingredients
        n = read.to_i
        (1..n).each_with_object({}) do |_, h|
            ingredient = read
            amount = read.to_i

            h[ingredient] = amount
        end
    end

    def read_recipes
        n = read.to_i

        (1..n).each_with_object({}) do |_, hash|
            name = read
            ingredients = read_recipe_ingredients
            hash[name] = ingredients
        end
    end

    def read_stock
        read_recipe_ingredients
    end

    def read_ingredient_costs
        read_recipe_ingredients
    end

    def read_bool
        read == 'true'
    end

    def read_strings
        n = read.to_i
        (1..n).map { read }
    end

    def assert_equal(expected, actual)
        if expected != actual
            raise TestFailed, "Expected #{expected}, received #{actual}"
        end
    end

    def run_tests
        puts "Running tests for #{tested_function}"

        open(filename) do |input|
            @in = input

            while (line = read) == 'testcase'
                perform_test
            end
        end
    end
end


class EnoughIngredientsTests < Tests
    def tested_function
        'enough_ingredients?'
    end

    def filename
        'enough-ingredients.txt'
    end

    def perform_test()
        recipe_ingredients = read_recipe_ingredients
        stock = read_stock
        expected = read_bool

        begin
            assert_equal(expected, enough_ingredients?(recipe_ingredients, stock))
            puts "PASS"
        rescue StandardError => e
            puts <<~END
            FAILURE
            Recipe: #{recipe_ingredients}
            Stock: #{stock}
            Expected: #{expected}
            Error: #{e.message}
            END
        end
    end
end


class CookableRecipesTests < Tests
    def tested_function
        'cookable_recipes'
    end

    def filename
        'cookable-recipes.txt'
    end

    def perform_test()
        recipes = read_recipes
        stock = read_stock
        expected = read_strings

        begin
            assert_equal(expected, cookable_recipes(recipes, stock))
            puts "PASS"
        rescue StandardError => e
            puts <<~END
            FAILURE
            Recipes: #{recipes}
            Stock: #{stock}
            Expected: #{expected}
            Error: #{e.message}
            END
        end
    end
end


class DishCountTests < Tests
    def tested_function
        'dish_count'
    end

    def filename
        'dish-count.txt'
    end

    def perform_test()
        recipe_ingredients = read_recipe_ingredients
        stock = read_stock
        expected = read.to_i

        begin
            assert_equal(expected, dish_count(recipe_ingredients, stock))
            puts "PASS"
        rescue StandardError => e
            puts <<~END
            FAILURE
            Recipe: #{recipe_ingredients}
            Stock: #{stock}
            Expected: #{expected}
            Error: #{e.message}
            END
        end
    end
end

class RecipeCostTests < Tests
    def tested_function
        'recipe_cost'
    end

    def filename
        'recipe-cost.txt'
    end

    def perform_test()
        recipe_ingredients = read_recipe_ingredients
        ingredient_costs = read_ingredient_costs
        expected = read.to_i

        begin
            assert_equal(expected, recipe_cost(recipe_ingredients, ingredient_costs))
            puts "PASS"
        rescue StandardError => e
            puts <<~END
            FAILURE
            Recipe: #{recipe_ingredients}
            Ingredient costs: #{ingredient_costs}
            Expected: #{expected}
            Error: #{e.message}
            END
        end
    end
end

class MostExpensiveRecipeTests < Tests
    def tested_function
        'most_expensive_recipe'
    end

    def filename
        'most-expensive-recipe.txt'
    end

    def perform_test()
        recipes = read_recipes
        ingredient_costs = read_ingredient_costs
        expected = read

        begin
            assert_equal(expected, most_expensive_recipe(recipes, ingredient_costs))
            puts "PASS"
        rescue StandardError => e
            puts <<~END
            FAILURE
            Recipes: #{recipes}
            Ingredient costs: #{ingredient_costs}
            Expected: #{expected}
            Error: #{e.message}
            END
        end
    end
end

class MostUsedIngredientTests < Tests
    def tested_function
        'most_used_ingredient'
    end

    def filename
        'most-used-ingredient.txt'
    end

    def perform_test()
        recipes = read_recipes
        expected = read

        begin
            assert_equal(expected, most_used_ingredient(recipes))
            puts "PASS"
        rescue StandardError => e
            puts <<~END
            FAILURE
            Recipes: #{recipes}
            Expected: #{expected}
            Error: #{e.message}
            END
        end
    end
end

class UselessIngredientsTests < Tests
    def tested_function
        'useless_ingredients'
    end

    def filename
        'useless-ingredients.txt'
    end

    def perform_test()
        recipes = read_recipes
        stock = read_stock
        expected = read_strings

        begin
            assert_equal(expected, useless_ingredients(recipes, stock))
            puts "PASS"
        rescue StandardError => e
            puts <<~END
            FAILURE
            Recipes: #{recipes}
            Stock: #{stock}
            Expected: #{expected}
            Error: #{e.message}
            END
        end
    end
end

class VegetarianRecipesTests < Tests
    def tested_function
        'vegetarian_recipes'
    end

    def filename
        'vegetarian-recipes.txt'
    end

    def perform_test()
        recipes = read_recipes
        vegetarian_ingredients = read_strings
        expected = read_strings

        begin
            assert_equal(expected, vegetarian_recipes(recipes, vegetarian_ingredients))
            puts "PASS"
        rescue StandardError => e
            puts <<~END
            FAILURE
            Recipes: #{recipes}
            Vegetarian ingredients: #{vegetarian_ingredients}
            Expected: #{expected}
            Error: #{e.message}
            END
        end
    end
end



run_tests(tests)