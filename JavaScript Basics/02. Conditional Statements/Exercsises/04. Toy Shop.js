function solve(input){
    const puzzelPrice = 2.60;
    const speakingDollPrice = 3;
    const teddyBearPrice = 4.10;
    const minionPrice = 8.20;
    const truckPrice = 2;

    let tripPrice = Number(input[0]);
    let puzzelsCount = Number(input[1]);
    let dollsCount = Number(input[2]);
    let teddyBearsCount = Number(input[3]);
    let minionsCount = Number(input[4]);
    let trucksCount = Number(input[5]);

    let totalToysCount = puzzelsCount + dollsCount +
        teddyBearsCount + minionsCount + trucksCount;

    let totalPrice = puzzelsCount * puzzelPrice + dollsCount * speakingDollPrice +
        teddyBearsCount * teddyBearPrice + minionsCount * minionPrice +
        trucksCount * truckPrice;

    if(totalToysCount >= 50){
        let discount = totalPrice * 0.25;
        totalPrice -= discount;
    }

    let moneyForRent = totalPrice * 0.10;
    totalPrice -= moneyForRent;

    let leftMoney = totalPrice - tripPrice;
    if(leftMoney >= 0){
        console.log(`Yes! ${leftMoney.toFixed(2)} lv left.`);
    }
    else{
        console.log(`Not enough money! ${(Math.abs(leftMoney)).toFixed(2)} lv needed.`);
    }
}

solve(['40.8','20','25','30','50','10']);
solve(['320','8','2','5','5','1']);