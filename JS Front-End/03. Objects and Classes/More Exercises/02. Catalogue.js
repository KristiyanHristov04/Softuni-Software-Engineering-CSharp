function solve(input) {
    let products = {};
    for (let index = 0; index < input.length; index++) {
        let [productName, productPrice] = input[index].split(' : ');
        productPrice = Number(productPrice);
        products[productName] = productPrice;
    }

    let productsSorted = Object.entries(products).sort((a, b) => a[0].localeCompare(b[0]));

    let lastChar = '';
    let didPrintGroup = false;
    for (let index = 0; index < productsSorted.length; index++) {
        let currentChar = productsSorted[index][0][0];
        if (lastChar === '') {
            lastChar = currentChar;
        }

        if (currentChar === lastChar && !didPrintGroup) {
            console.log(currentChar);
            didPrintGroup = true;
        }

        if (currentChar === lastChar) {
            console.log(`  ${productsSorted[index][0]}: ${productsSorted[index][1]}`);
        }

        if (currentChar !== lastChar) {
            lastChar = currentChar;
            console.log(currentChar);
            console.log(`  ${productsSorted[index][0]}: ${productsSorted[index][1]}`);
        }
    }
}

solve([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
    ]
    );