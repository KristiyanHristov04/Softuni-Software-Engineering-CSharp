function perfectNumber(number){
    let sumOfPositiveDivisors = 0;
    for (let index = 1; index < number; index++) {
        if (number % index == 0) {
            sumOfPositiveDivisors += index;
        }
    }

    if (sumOfPositiveDivisors == number) {
        console.log('We have a perfect number!')
    } else {
        console.log(`It's not so perfect.`);
    }
}

perfectNumber(6);
perfectNumber(28);
perfectNumber(1236498);