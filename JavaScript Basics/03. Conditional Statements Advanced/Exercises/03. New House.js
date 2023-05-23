function solve(input){
    const rosePrice = 5;
    const dahliaPrice = 3.80;
    const tulipPrice = 2.80;
    const narcissusPrice = 3;
    const gladiolusPrice = 2.50;

    let flowersType = input[0];
    let numberOfFlowers = Number(input[1]);
    let budget = Number(input[2]);

    let totalPrice = 0;

    switch (flowersType) {
        case 'Roses':
            totalPrice = numberOfFlowers * rosePrice;
            if(numberOfFlowers > 80){
                totalPrice *= 0.90;
            }
            break;
            case 'Dahlias':
                totalPrice = numberOfFlowers * dahliaPrice;
                if(numberOfFlowers > 90){
                    totalPrice *= 0.85;
                }
            break;
            case 'Tulips':
                totalPrice = numberOfFlowers * tulipPrice;
                if(numberOfFlowers > 80){
                    totalPrice *= 0.85;
                }
            break;
            case 'Narcissus':
                totalPrice = numberOfFlowers * narcissusPrice;
                if(numberOfFlowers < 120){
                    totalPrice *= 1.15;
                }
            break;
            case 'Gladiolus':
                totalPrice = numberOfFlowers * gladiolusPrice;
                if(numberOfFlowers < 80){
                    totalPrice *= 1.20;
                }
            break;
    }

    let leftMoney = budget - totalPrice;
    if(leftMoney >= 0){
        console.log(`Hey, you have a great garden with ${numberOfFlowers} ${flowersType} and ${leftMoney.toFixed(2)} leva left.`);
    }
    else{
        let neededMoney = Math.abs(leftMoney);
        console.log(`Not enough money, you need ${neededMoney.toFixed(2)} leva more.`);
    }
}

// solve(['Tulips', '88', '260']);