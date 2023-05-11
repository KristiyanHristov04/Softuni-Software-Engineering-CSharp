function solve(input) {
    const chickenMenuPrice = 10.35;
    const fishMenuPrice = 12.40;
    const vegetarianMenuPrice = 8.15;
    const deliveryPrice = 2.50;

    let numberOfChickenMenus = Number(input[0]);
    let numberOfFishMenus = Number(input[1]);
    let numberOfVegetarianMenus = Number(input[2]);

    let menusTotalPrice = numberOfChickenMenus * chickenMenuPrice +
        numberOfFishMenus * fishMenuPrice +
        numberOfVegetarianMenus * vegetarianMenuPrice;

    let desertPrice = menusTotalPrice * 20 / 100;

    let orderTotalPrice = menusTotalPrice + desertPrice + deliveryPrice;
    console.log(orderTotalPrice);
}

solve(['2', '4', '3']);
solve(['9', '2', '6']);