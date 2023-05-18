function solve(input){
    const graphicsCardPrice = 250;

    let budget = Number(input[0]);
    let graphicsCardQuantity = Number(input[1]);
    let processorQuantity = Number(input[2]);
    let ramQuantity = Number(input[3]);

    let graphicsCardsPrice = graphicsCardQuantity * graphicsCardPrice;
    let processorsPrice = (graphicsCardsPrice * (35 / 100)) * processorQuantity;
    let ramPrice = (graphicsCardsPrice * (10 / 100)) * ramQuantity;

    let totalPrice = graphicsCardsPrice + processorsPrice + ramPrice;

    if(graphicsCardQuantity > processorQuantity){
        totalPrice = totalPrice * 0.85;
    }

    if(budget >= totalPrice){
        let leftMoney = budget - totalPrice;
        console.log(`You have ${leftMoney.toFixed(2)} leva left!`);
    }
    else{
        let neededMoney = totalPrice - budget;
        console.log(`Not enough money! You need ${neededMoney.toFixed(2)} leva more!`);
    }
}

solve(['900','2','1','3'])
solve(['920.45','3','1','1'])
