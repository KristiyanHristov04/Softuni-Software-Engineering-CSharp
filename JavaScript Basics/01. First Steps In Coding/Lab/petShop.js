function calculateExpenses(input){
    let dogFoodCount = Number(input[0]);
    let catFoodCount = Number(input[1]);
    const dogFoodPricePerCount = 2.50;
    const catFoodPricePerCount = 4.00;
    let totalSum = dogFoodCount * dogFoodPricePerCount + catFoodCount * catFoodPricePerCount;
    console.log(`${totalSum} lv.`);
}

calculateExpenses(['5', '4'])