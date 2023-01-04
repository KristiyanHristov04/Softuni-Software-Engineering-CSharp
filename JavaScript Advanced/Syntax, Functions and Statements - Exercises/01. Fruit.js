function solve(fruit, weight, price){
    let fruitWeightInKilograms = Number(weight) / 1000;
    let neededMoney = fruitWeightInKilograms * Number(price);
    console.log(`I need $${neededMoney.toFixed(2)} to buy ${fruitWeightInKilograms.toFixed(2)} kilograms ${fruit}.`);
}

solve('orange', 2500, 1.80);