const fs = require('fs');
const path = require('path');


// Write your solutions here
function enoughIngredients(recipe, ingredients)
{
    // TODO
}

function cookableRecipes(recipes, stock)
{
    // TODO
}

function dishCount(recipe, stock)
{
    // TODO
}

function recipeCost(recipe, ingredientCosts)
{
    // TODO
}

function mostExpensiveRecipe(recipes, ingredientCosts)
{
    // TODO
}

function mostUsedIngredient(recipes)
{
    // TODO
}

function uselessIngredients(recipes, stock)
{
    // TODO
}

function vegetarianRecipes(recipes, vegetarianIngredients)
{
    // TODO
}

// You can select tests here
function tests()
{
    return [
        new EnoughIngredientsTests(),
        new CookableRecipesTests(),
        new DishCountTests(),
        new RecipeCostTests(),
        new MostExpensiveRecipeTests(),
        new MostUsedIngredientTests(),
        new UselessIngredientsTests(),
        new VegetarianRecipesTests(),
    ];
}




function sort(xs)
{
    return [...xs].sort();
}

function sum(ns)
{
    return ns.reduce((x, y) => x + y, 0);
}

function maxBy(xs, key)
{
    if ( xs.length === 1 ) return xs[0];

    const [x, y, ...rest] = xs;

    if ( key(x) >= key(y) )
    {
        return maxBy([x, ...rest], key);
    }
    else
    {
        return maxBy([y, ...rest], key);
    }
}

function nodup(xs)
{
    return [...new Set(xs)];
}

function eqarrays(expected, actual)
{
    if ( Array.isArray(actual) )
    {
        if ( expected.length !== actual.length ) return false;

        for ( let i = 0; i !== expected.length; ++i )
        {
            if ( expected[i] !== actual[i] ) return false;
        }

        return true;
    }
    else
    {
        return false;
    }
}

function asserteq(expected, actual)
{
    if ( Array.isArray(expected) )
    {
        if ( !eqarrays(expected, actual) )
        {
            throw new Error(`Expected ${show(expected)}, received ${show(actual)}`);
        }
    }
    else if ( expected !== actual )
    {
        throw new Error(`Expected ${show(expected)}, received ${show(actual)}`);
    }
}

function show(x)
{
    if ( Array.isArray(x) )
    {
        return '[' + x.map(show).join(", ") + ']';
    }
    else if ( typeof x === typeof {} )
    {
        return "{" + Object.entries(x).map( ([key, value]) => `${show(key)}: ${show(value)}` ).join(", ") + "}";
    }
    else
    {
        return x;
    }
}

class Tests
{
    read()
    {
        return this.data.shift();
    }

    readInt()
    {
        return parseInt(this.read());
    }

    readBool()
    {
        return this.read() === 'true';
    }

    readStrings()
    {
        const n = this.readInt();
        const result = [];

        for ( let i = 0; i !== n; ++i )
        {
            result.push( this.read() );
        }

        return result;
    }

    readRecipes()
    {
        const n = this.readInt();
        const result = {};

        for ( let i = 0; i !== n; ++i )
        {
            const name = this.read();
            const ingredients = this.readRecipeIngredients();
            result[name] = ingredients;
        }

        return result;
    }

    readRecipeIngredients()
    {
        const n = this.readInt();
        const result = {};

        for ( let i = 0; i !== n; ++i )
        {
            const ingredient = this.read();
            const amount = this.readInt();
            result[ingredient] = amount;
        }

        return result;
    }

    readStock()
    {
        return this.readRecipeIngredients();
    }

    readIngredientCosts()
    {
        return this.readRecipeIngredients();
    }

    runTests()
    {
        console.log(`Running tests for ${this.description}`);

        const absolutePath = path.join(__dirname, this.filename);
        this.data = fs.readFileSync(absolutePath, 'utf8').split("\n").filter( x => !x.startsWith('#') ).map( x => x.trimRight() );
        let line = this.read();

        while ( line === 'testcase' )
        {
            this.performTest();
            line = this.read();
        }
    }
}

class EnoughIngredientsTests extends Tests
{
    constructor()
    {
        super();
        this.filename = 'enough-ingredients.txt';
        this.description = 'enoughIngredients';
    }

    performTest()
    {
        const recipe = this.readRecipeIngredients();
        const stock = this.readStock();
        const expected = this.readBool();

        try
        {
            asserteq(expected, enoughIngredients(recipe, stock));
            console.log('PASS');
        }
        catch ( e )
        {
            console.log('FAIL');
            console.log(`Recipe: ${show(recipe)}`)
            console.log(`Stock: ${show(stock)}`)
            console.log(e.message);
        }
    }
}

class CookableRecipesTests extends Tests
{
    constructor()
    {
        super();
        this.filename = 'cookable-recipes.txt';
        this.description = 'cookableRecipes';
    }

    performTest()
    {
        const recipes = this.readRecipes();
        const stock = this.readStock();
        const expected = this.readStrings();

        try
        {
            asserteq(expected, cookableRecipes(recipes, stock));
            console.log('PASS');
        }
        catch ( e )
        {
            console.log('FAIL');
            console.log(`Recipes: ${show(recipes)}`)
            console.log(`Stock: ${show(stock)}`)
            console.log(e.message);
        }
    }
}

class DishCountTests extends Tests
{
    constructor()
    {
        super();
        this.filename = 'dish-count.txt';
        this.description = 'dishCount';
    }

    performTest()
    {
        const recipe = this.readRecipeIngredients();
        const stock = this.readStock();
        const expected = this.readInt();

        try
        {
            asserteq(expected, dishCount(recipe, stock));
            console.log('PASS');
        }
        catch ( e )
        {
            console.log('FAIL');
            console.log(`Recipe: ${show(recipe)}`)
            console.log(`Stock: ${show(stock)}`)
            console.log(e.message);
        }
    }
}

class RecipeCostTests extends Tests
{
    constructor()
    {
        super();
        this.filename = 'recipe-cost.txt';
        this.description = 'recipeCost';
    }

    performTest()
    {
        const recipe = this.readRecipeIngredients();
        const ingredientCosts = this.readIngredientCosts();
        const expected = this.readInt();

        try
        {
            asserteq(expected, recipeCost(recipe, ingredientCosts));
            console.log('PASS');
        }
        catch ( e )
        {
            console.log('FAIL');
            console.log(`Recipe: ${show(recipe)}`)
            console.log(`Ingredient costs: ${show(ingredientCosts)}`)
            console.log(e.message);
        }
    }
}

class MostExpensiveRecipeTests extends Tests
{
    constructor()
    {
        super();
        this.filename = 'most-expensive-recipe.txt';
        this.description = 'mostExpensiveRecipe';
    }

    performTest()
    {
        const recipes = this.readRecipes();
        const ingredientCosts = this.readIngredientCosts();
        const expected = this.read();

        try
        {
            asserteq(expected, mostExpensiveRecipe(recipes, ingredientCosts));
            console.log('PASS');
        }
        catch ( e )
        {
            console.log('FAIL');
            console.log(`Recipes: ${show(recipes)}`)
            console.log(`Ingredient costs: ${show(ingredientCosts)}`)
            console.log(e.message);
        }
    }
}

class MostUsedIngredientTests extends Tests
{
    constructor()
    {
        super();
        this.filename = 'most-used-ingredient.txt';
        this.description = 'mostUsedIngredient';
    }

    performTest()
    {
        const recipes = this.readRecipes();
        const expected = this.read();

        try
        {
            asserteq(expected, mostUsedIngredient(recipes));
            console.log('PASS');
        }
        catch ( e )
        {
            console.log('FAIL');
            console.log(`Recipes: ${show(recipes)}`)
            console.log(e.message);
        }
    }
}

class UselessIngredientsTests extends Tests
{
    constructor()
    {
        super();
        this.filename = 'useless-ingredients.txt';
        this.description = 'uselessIngredients';
    }

    performTest()
    {
        const recipes = this.readRecipes();
        const stock = this.readStock();
        const expected = this.readStrings();

        try
        {
            asserteq(expected, uselessIngredients(recipes, stock));
            console.log('PASS');
        }
        catch ( e )
        {
            console.log('FAIL');
            console.log(`Recipes: ${show(recipes)}`)
            console.log(`Stock: ${show(stock)}`)
            console.log(e.message);
        }
    }
}

class VegetarianRecipesTests extends Tests
{
    constructor()
    {
        super();
        this.filename = 'vegetarian-recipes.txt';
        this.description = 'vegetarianRecipes';
    }

    performTest()
    {
        const recipes = this.readRecipes();
        const vegetarianIngredients = this.readStrings();
        const expected = this.readStrings();

        try
        {
            const actual = vegetarianRecipes(recipes, vegetarianIngredients);
            asserteq(expected, actual);
            console.log('PASS');
        }
        catch ( e )
        {
            console.log('FAIL');
            console.log(`Recipes: ${show(recipes)}`)
            console.log(`Vegetarian Ingredients: ${show(vegetarianIngredients)}`)
            console.log(e.message);
        }
    }
}


for ( const test of tests() )
{
    test.runTests();
}
