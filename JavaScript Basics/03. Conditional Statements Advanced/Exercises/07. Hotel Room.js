function solve(input) {
    let month = input[0];
    let nightStays = Number(input[1]);

    let studioNightStayPrice = 0;
    let apartmentNightStayPrice = 0;

    let studioTotalPrice = 0;
    let apartmentTotalPrice = 0;

    switch (month) {
        case 'May':
        case 'October':
            studioNightStayPrice = 50;
            apartmentNightStayPrice = 65;

            if(nightStays > 7 && nightStays <= 14){
                studioNightStayPrice *= 0.95;
            }
            else if(nightStays > 14){
                studioNightStayPrice *= 0.70;
                apartmentNightStayPrice *= 0.90;
            }

            break;
        case 'June':
        case 'September':
            studioNightStayPrice = 75.20;
            apartmentNightStayPrice = 68.70;

            if(nightStays > 14){
                studioNightStayPrice *= 0.80;
                apartmentNightStayPrice *= 0.90;
            }
            break;
        case 'July':
        case 'August':
            studioNightStayPrice = 76;
            apartmentNightStayPrice = 77;

            if(nightStays > 14){
                apartmentNightStayPrice *= 0.90;
            }
            break;
    }

    studioTotalPrice = nightStays * studioNightStayPrice;
    apartmentTotalPrice = nightStays * apartmentNightStayPrice;

    console.log(`Apartment: ${apartmentTotalPrice.toFixed(2)} lv.`);
    console.log(`Studio: ${studioTotalPrice.toFixed(2)} lv.`);
}

// solve(['May', '15']);