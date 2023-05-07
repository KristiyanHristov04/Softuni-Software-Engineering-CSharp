function neededMoney(input){
    let totalPrice = Number(input[0]) * 7.61;
    let discount = totalPrice * 0.18;
    let totalPriceWithDiscount = totalPrice - discount;
    console.log(`The final price is: ${totalPriceWithDiscount} lv.`);
    console.log(`The discount is: ${discount} lv.`);
}

neededMoney(['550']);