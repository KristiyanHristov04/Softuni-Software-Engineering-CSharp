function solve(fruit, grams, pricePerKg){
    let gramsToKilos = grams / 1000;
    let neededMoney = gramsToKilos * pricePerKg;
    console.log(`I need $${neededMoney.toFixed(2)} to buy ${gramsToKilos.toFixed(2)} kilograms ${fruit}.`);
}

solve('apple', 1563, 2.35);