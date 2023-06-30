function solve(peopleCount, groupType, dayOfWeek) {
    let totalPrice = 0;
    switch (dayOfWeek) {
        case 'Friday':
            if(groupType == 'Students'){
                totalPrice = 8.45 * peopleCount;
                if(peopleCount >= 30){
                    totalPrice *= 0.85;
                }
            } else if(groupType == 'Business'){
                if(peopleCount >= 100){
                    totalPrice = (peopleCount - 10) * 10.90;
                } else{
                    totalPrice = peopleCount * 10.90;
                }
            } else{
                totalPrice = 15 * peopleCount;
                if(peopleCount >= 10 && peopleCount <= 20){
                    totalPrice *= 0.95;
                }
            }
            break;
        case 'Saturday':
            if(groupType == 'Students'){
                totalPrice = 9.80 * peopleCount;
                if(peopleCount >= 30){
                    totalPrice *= 0.85;
                }
            } else if(groupType == 'Business'){
                if(peopleCount >= 100){
                    totalPrice = (peopleCount - 10) * 15.60;
                } else{
                    totalPrice = peopleCount * 15.60;
                }
            } else{
                totalPrice = 20 * peopleCount;
                if(peopleCount >= 10 && peopleCount <= 20){
                    totalPrice *= 0.95;
                }
            }
            break;
        case 'Sunday':
            if(groupType == 'Students'){
                totalPrice = 10.46 * peopleCount;
                if(peopleCount >= 30){
                    totalPrice *= 0.85;
                }
            } else if(groupType == 'Business'){
                if(peopleCount >= 100){
                    totalPrice = (peopleCount - 10) * 16;
                } else{
                    totalPrice = peopleCount * 16;
                }
            } else{
                totalPrice = 22.50 * peopleCount;
                if(peopleCount >= 10 && peopleCount <= 20){
                    totalPrice *= 0.95;
                }
            }
            break;
    }
    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

solve(40, "Regular", "Saturday");