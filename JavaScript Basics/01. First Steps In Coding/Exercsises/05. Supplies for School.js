function solve(input){
    const packetOfPensPrice = 5.80;
    const packetOfMarkersPrice = 7.20;
    const preparationPerLiterPrice = 1.20;

    let numberOfPens = Number(input[0]);
    let numberOfMarkers = Number(input[1]);
    let numberOfPreparationLiters = Number(input[2]);
    let discount = Number(input[3]);

    let pensTotalSum = numberOfPens * packetOfPensPrice;
    let markersTotalSum = numberOfMarkers * packetOfMarkersPrice;
    let preparationTotalSum = numberOfPreparationLiters * preparationPerLiterPrice;

    let allProductsSum = pensTotalSum + markersTotalSum + preparationTotalSum;
    let discountPrice = allProductsSum * (discount / 100);
    let allProductsSumWithDiscount = allProductsSum - discountPrice;
    console.log(allProductsSumWithDiscount);
}

solve(['2', '3', '4', '25']);
solve(['4', '2', '5', '13']);