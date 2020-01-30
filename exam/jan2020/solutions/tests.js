const fs = require('fs');
const path = require('path');


// Write your solutions here
function enoughIngredients(recipe, ingredients)
{
    return Object.keys(recipe).every( ingredient => (ingredients[ingredient] || 0) >= recipe[ingredient] );
}

function cookableRecipes(recipes, stock)
{
    return sort(Object.keys(recipes).filter( id => enoughIngredients(recipes[id], stock) ));
}

function dishCount(recipe, stock)
{
    return Math.min(...Object.entries(recipe).map( ([i, n]) => Math.floor((stock[i] || 0) / n) ));
}

function recipeCost(recipe, ingredientCosts)
{
    return sum(Object.entries(recipe).map(([i, n]) => ingredientCosts[i] * n));
}

function mostExpensiveRecipe(recipes, ingredientCosts)
{
    return maxBy(Object.keys(recipes), id => recipeCost(recipes[id], ingredientCosts));
}

function mostUsedIngredient(recipes)
{
    const ingredients = Object.values(recipes).map( ingrs => Object.keys(ingrs) ).flat();

    return maxBy(ingredients, i => Object.values(recipes).filter(r => i in r).length);
}

function uselessIngredients(recipes, stock)
{
    return sort(Object.keys(stock).filter( i => !Object.values(recipes).some(r => i in r) ));
}

function vegetarianRecipes(recipes, vegetarianIngredients)
{
    return sort(Object.keys(recipes).filter((id) => Object.keys(recipes[id]).every(i => vegetarianIngredients.includes(i))));
}
