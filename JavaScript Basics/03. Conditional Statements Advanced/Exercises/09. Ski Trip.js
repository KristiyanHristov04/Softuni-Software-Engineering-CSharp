function solve(input){
    const roomForOnePersonPrice = 18;
    const apartmentPrice = 25;
    const presidentApartmentPrice = 35;

    let stayDays = Number(input[0]) - 1;
    let typeOfStay = input[1];
    let feedback = input[2];

    let totalPrice = 0;

    switch (typeOfStay) {
        case 'room for one person':
            if(stayDays < 10){
                totalPrice = stayDays * roomForOnePersonPrice;
            }
            else if(stayDays >= 10 && stayDays <= 15){
                totalPrice = stayDays * roomForOnePersonPrice;
            }
            else{
                totalPrice = stayDays * roomForOnePersonPrice;
            }
            break;

        case 'apartment':
            if(stayDays < 10){
                totalPrice = (stayDays * apartmentPrice) * 0.70;
            }
            else if(stayDays >= 10 && stayDays <= 15){
                totalPrice = (stayDays * apartmentPrice) * 0.65;
            }
            else{
                totalPrice = (stayDays * apartmentPrice) * 0.50;
            }
            break;
        
        case 'president apartment':
            if(stayDays < 10){
                totalPrice = (stayDays * presidentApartmentPrice) * 0.90;
            }
            else if(stayDays >= 10 && stayDays <= 15){
                totalPrice = (stayDays * presidentApartmentPrice) * 0.85;
            }
            else{
                totalPrice = (stayDays * presidentApartmentPrice) * 0.80;
            }
            break;
    }

    if(feedback == 'positive'){
        totalPrice += totalPrice * 25 / 100;
    }
    else{
        totalPrice *= 0.90;
    }

    console.log(totalPrice.toFixed(2));
}

// solve(['14','apartment','positive']);