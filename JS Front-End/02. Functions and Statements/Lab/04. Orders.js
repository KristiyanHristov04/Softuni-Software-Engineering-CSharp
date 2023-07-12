function solve(product, quantity) {
    const COFFEE_PRICE = 1.50;
    const WATER_PRICE = 1.00;
    const COKE_PRICE = 1.40;
    const SNACKS_PRICE = 2.00;
    let totalPrice = 0;
    switch (product) {
        case 'coffee':
            totalPrice = COFFEE_PRICE * quantity;
            break;
        case 'water':
            totalPrice = WATER_PRICE * quantity;
            break;
        case 'coke':
            totalPrice = COKE_PRICE * quantity;
            break;
        case 'snacks':
            totalPrice = SNACKS_PRICE * quantity;
            break;
    }
    console.log(totalPrice.toFixed(2));
}

solve('water', 5);