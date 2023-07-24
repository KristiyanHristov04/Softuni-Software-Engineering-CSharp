function solve(stockArray, orderedArray) {
    let allProductsAndQuantity = {};
    for (let index = 0; index < stockArray.length; index += 2) {
        let product = stockArray[index];
        let productQuantity = Number(stockArray[index + 1]);
        allProductsAndQuantity[product] = productQuantity;
    }

    for (let index = 0; index < orderedArray.length; index += 2) {
        let product = orderedArray[index];
        let productQuantity = Number(orderedArray[index + 1]);
        if (allProductsAndQuantity.hasOwnProperty(product)) {
            allProductsAndQuantity[product] += productQuantity;
        } else {
            allProductsAndQuantity[product] = productQuantity;
        }
    }

    for (const key in allProductsAndQuantity) {
        console.log(`${key} -> ${allProductsAndQuantity[key]}`);
    }
}

solve([
    'Chips', '5', 'CocaCola', '9', 'Bananas',
    '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7',
    'Tomatoes', '70', 'Bananas', '30'
    ]
    );