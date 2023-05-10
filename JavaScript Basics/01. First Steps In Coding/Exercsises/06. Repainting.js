function solve(input){
    const nylonPricePerSquareMeter = 1.50;
    const paintPricePerLiter = 14.50;
    const paintThinnerPricePerLiter = 5.00;

    let neededNylon = Number(input[0]) + 2;
    let neededPaint = Number(input[1]) + (Number(input[1]) * (10 / 100));
    let neededPaintThinner = Number(input[2]);
    let hoursForFinishTheWork = Number(input[3]);

    let nylonTotalPrice = neededNylon * nylonPricePerSquareMeter;
    let paintTotalPrice = neededPaint * paintPricePerLiter;
    let paintThinnerPrice = neededPaintThinner * paintThinnerPricePerLiter;
    let bagPrice = 0.40;

    let totalMaterialsPrice = nylonTotalPrice + paintTotalPrice + paintThinnerPrice + bagPrice;
    let workersPrice = (totalMaterialsPrice * 30 / 100) * hoursForFinishTheWork;

    let totalSum = totalMaterialsPrice + workersPrice;
    console.log(totalSum);
}

solve(['10', '11', '4', '8']);
solve(['5', '10', '10', '1']);