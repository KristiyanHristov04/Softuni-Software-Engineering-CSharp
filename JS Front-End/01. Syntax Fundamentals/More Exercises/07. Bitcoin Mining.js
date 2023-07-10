function solve(shift){
    const pricePerOneGramGold = 67.51;
    const pricePerOneBTC = 11949.16;
    let totalMoney = 0;
    let totalBoughtBitcoins = 0;
    let dayWhenBoughtFirstBTC = 0;
    let day = 1;
    let boughtBitcoin = false;

    for (let index = 0; index < shift.length; index++) {
        let currentDiggedGold = Number(shift[index]);
        if(day % 3 == 0){
            currentDiggedGold *= 0.70;
        }
        totalMoney += currentDiggedGold * pricePerOneGramGold;
        if(totalMoney >= pricePerOneBTC && !boughtBitcoin){
            dayWhenBoughtFirstBTC = day;
            boughtBitcoin = true;
            totalBoughtBitcoins++;
            totalMoney -= pricePerOneBTC;
        }
        day++;
    }

    while(totalMoney >= pricePerOneBTC){
        totalMoney -= pricePerOneBTC;
        totalBoughtBitcoins++;
    }

    console.log(`Bought bitcoins: ${totalBoughtBitcoins}`);
    if(boughtBitcoin){
        console.log(`Day of the first purchased bitcoin: ${dayWhenBoughtFirstBTC}`);
    }
    console.log(`Left money: ${totalMoney.toFixed(2)} lv.`);
}

solve([100, 200, 300]);
solve([50, 100]);
solve([3124.15, 504.212, 2511.124]);