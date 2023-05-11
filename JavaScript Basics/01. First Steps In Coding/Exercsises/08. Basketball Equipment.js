function solve(input){
    let taxPerYear = Number(input[0]);
    let shoesPrice = taxPerYear - (taxPerYear * (40 / 100));
    let basketballTeamPrice = shoesPrice - (shoesPrice * (20 / 100));
    let ballPrice = basketballTeamPrice / 4;
    let basketballAccessories = ballPrice / 5;

    let totalEquipmentPrice = shoesPrice + basketballTeamPrice + ballPrice + basketballAccessories + taxPerYear;
    console.log(totalEquipmentPrice);
}

solve(['550']);