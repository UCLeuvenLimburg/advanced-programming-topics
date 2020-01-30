# Exercises

Different data structures have different names in different languages.
Below is a quick overview of the terminology used in this text and the corresponding terms in the different programming languages.

| Term | C# | Ruby | Python | JavaScript |
|-|-|-|-|-|
|`list<T>`| `IEnumerable<T>`/`IList<T>` | Array | List | Array |
|`map<K, V>`| `IDictionary<K, V>` | Hash | Dict | Object |

## Exercise "enough ingredients"

Check if there are enough ingredients for a given recipe.

### Parameters

* `recipe`: a `map<string, int>` that associates ingredients with amounts, for example, `{egg => 5, sugar => 100}`. It expresses which and how many ingredients are required.
* `stock`: a `map<string, int>` that associates ingredients with amounts. It expresses which and how many ingredients are available in stock.

### Return Value

A boolean value that indicates whether there are enough ingredients in stock to make the recipe.

### Examples

```text
recipe = { egg => 5, sugar => 100, flour => 200 }
stock = { egg => 20, sugar => 500, flour => 200 }
result = true
```

```text
recipe = { egg => 5, sugar => 100, flour => 200 }
stock = { egg => 1, sugar => 100, flour => 200 }
result = false (insufficient eggs)
```

```text
recipe = { egg => 5, sugar => 100, flour => 200 }
stock = { egg => 5, sugar => 100 }
result = false (missing flour)
```

## Exercise "cookable recipes"

Find out for which recipes you have enough ingredients in stock.

### Parameters

* `recipes`: a `map<string, map<string, int>>`, for example

  ```text
  {
     cake => { egg => 4, sugar => 250, flour => 250, butter => 250 },
     pasta => { egg => 2, flour => 100 }
  }
  ```

  This parameter represents different recipes and their ingredient requirements. For example, `recipes[cake][egg]` tells you how many eggs you need for cake.
* `stock`: a `map<string, int>` expressing how much of each ingredient is in stock.

### Return Value

An *alphabetically sorted* `list<string>` of recipe names for which there are enough ingredients in stock.

### Examples

```text
recipes = {
    cake => { egg => 4, sugar => 250, flour => 250, butter => 250 },
    pasta => { egg => 2, flour => 100 }
}

stock = {
    egg => 10, sugar => 500, flour => 300, butter => 400
}

result = [ cake, pasta ]
```

```text
recipes = {
    cake => { egg => 4, sugar => 250, flour => 250, butter => 250 },
    pasta => { egg => 2, flour => 100 }
}

stock = {
    egg => 10, sugar => 500, flour => 300
}

result = [ pasta ]   (because no butter in stock)
```

## Exercise "dish count"

Given a stock of ingredients, count how many dishes of a particular recipe you can cook.

### Parameters

* `recipe`: a `map<string, int>` expressing how much of each ingredient is required for the recipe. For example, `{ butter => 100, beef => 250 }`.
* `stock`: a `map<string, int>` expressing how much of each ingredient is in stock.

### Return Value

An integer expressing how many times the dish can be made.

### Examples

```text
recipe = { egg => 1 }
stock = { egg => 5 }
result = 5
```

```text
recipe = { egg => 1, butter => 20 }
stock = { egg => 5, butter => 40 }
result = 2    (butter is limiting ingredient)
```

```text
recipe = { egg => 1, butter => 20 }
stock = { egg => 99999 }
result = 0    (no butter)
```

## Exercise "recipe cost"

Compute the cost of a recipe.

### Parameters

* `recipe`: a `map<string, int>` expressing how much of each ingredient is required for the recipe. For example, `{ butter => 100, beef => 250 }`.
* `ingredientCosts`: a `map<string, int>` expressing how much each ingredient costs.

### Return Value

An integer that expresses the cost of the given recipe.

### Examples

```text
recipe = { egg =>  1 }
ingredientCosts = { egg => 2 }
result = 2
```

```text
recipe = { egg =>  5 }
ingredientCosts = { egg => 2 }
result = 10
```

```text
recipe = { egg =>  1, chicken: 1 }
ingredientCosts = { egg => 1, chicken: 10 }
result = 11
```

### Exercise "most expensive recipe"

Find the most expensive recipe.

### Parameters

* `recipes`: a `map<string, map<string, int>>`, for example

  ```text
  {
     cake => { egg => 4, sugar => 250, flour => 250, butter => 250 },
     pasta => { egg => 2, flour => 100 }
  }
  ```

  This parameter represents different recipes and their ingredient requirements. For example, `recipes[cake][egg]` tells you how many eggs you need for cake.
* `ingredientCosts`: a `map<string, int>` expressing how much each ingredient costs.

### Return Value

A string designating the most expensive recipe. It is guaranteed that there is only one such recipe.

### Examples

```text
recipes = {
    cake => { egg => 4, sugar => 250, flour => 250, butter => 250 },
    pasta => { egg => 1, flour => 100 }
}
ingredientCosts = { egg: 1, flour: 2 }
result = cake
```

## Exercise "most used ingredient"

Find out which ingredient is used most in recipes. Important note: even though ingredient amounts are provided, they have no influence. See examples below. It is guaranteed there is exactly one most used ingredient, i.e., there are no ties.

### Parameters

* `recipes`: a `map<string, map<string, int>>`, for example

  ```text
  {
     cake => { egg => 4, sugar => 250, flour => 250, butter => 250 },
     pasta => { egg => 2, flour => 100 }
  }
  ```

  This parameter represents different recipes and their ingredient requirements. For example, `recipes[cake][egg]` tells you how many eggs you need for cake.

### Return Value

A string denoting the ingredient used the most frequently in the given recipes.

### Examples

```text
recipes = {
    cake: { egg => 2, flour => 100, sugar => 200, butter => 150 },
    omellete: { egg => 2 }
}
result = egg   (mentioned in two recipes)


recipes = {
    recipe1: { egg => 1 },
    recipe2: { egg => 1 },
    recipe3: { egg => 1 },
    recipe4: { chicken => 500 }
}
result = egg   (ingredient amounts don't matter - eggs are used in three recipes, chicken in only one)
```

## Exercise "useless ingredients"

Find out which ingredients in stock are useless, i.e., not used in any recipe.

### Parameters

* `recipes`: a `map<string, map<string, int>>`, for example

  ```text
  {
     cake => { egg => 4, sugar => 250, flour => 250, butter => 250 },
     pasta => { egg => 2, flour => 100 }
  }
  ```

  This parameter represents different recipes and their ingredient requirements. For example, `recipes[cake][egg]` tells you how many eggs you need for cake.
* `stock`: a `map<string, int>` that associates ingredients with amounts. It expresses which and how many ingredients are available in stock.

### Return Value

A *alphabetically sorted* `List<string>` with the names of all ingredients in stock that are not mentioned in any recipe.

### Examples

```text
recipes = {
    cake => { egg => 4 },
}

stock = {
    egg => 100
}

result = [ ]
```

```text
recipes = {
    cake => { egg => 4 },
}

stock = {
    egg => 100,
    sugar => 200
}

result = [ sugar ]
```

```text
recipes = {
    cake => { egg => 4, sugar => 250, flour => 250, butter => 250 },
    pasta => { egg => 1, flour => 100 }
}

stock = {
    chicken => 1,
    egg => 100
}

result = [ chicken ]
```

```text
recipes = {
    cake => { egg => 4, sugar => 250, flour => 250, butter => 250 },
    pasta => { egg => 1, flour => 100 }
}

stock = {
    chicken => 1,
    egg => 100,
    garlic => 5
}

result = [ chicken, garlic ]
```

## Exercise "vegetarian recipes"

Find out which recipes only use vegetarian ingredients.

### Parameters

* `recipes`: a `map<string, map<string, int>>`, for example

  ```text
  {
     cake => { egg => 4, sugar => 250, flour => 250, butter => 250 },
     pasta => { egg => 2, flour => 100 }
  }
  ```

  This parameter represents different recipes and their ingredient requirements. For example, `recipes[cake][egg]` tells you how many eggs you need for cake.
* `vegetarianIngredients`: a `list<string>` containing vegetarian ingredients. Ingredients not in this list must automatically be considered non-vegetarian.

### Return Value

An *alphabetically sorted* `list<string>` of recipe names whose ingredients are all vegetarian.

### Example

```text
recipes = {
    cake => { egg => 4 }
}

vegetarianIngredients = [ egg ]

result = [ cake ]
```

```text
recipes = {
    meatloaf => { beef => 500 }
}

vegetarianIngredients = [ egg ]

result = [ ]
```

```text
recipes = {
    cake => { egg => 4, flour => 250, sugar => 250, butter => 250 },
    meatloaf => { beef => 500 }
}

vegetarianIngredients = [ egg, flour, sugar, butter ]

result = [ cake ]
```

```text
recipes = {
    cake => { egg => 4, flour => 250, sugar => 250, butter => 250 },
    pie => { egg => 3, flour => 250, sugar => 250, butter => 100 },
    meatloaf => { beef => 500 }
}

vegetarianIngredients = [ egg, flour, sugar, butter ]

result = [ cake, pie ]
```
