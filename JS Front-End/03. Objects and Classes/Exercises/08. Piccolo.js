function solve(input) {
    let parkingLot = {};
    for (let index = 0; index < input.length; index++) {
        let [direction, carNumber] = input[index].split(', ');
        if (direction == 'IN' && !parkingLot.hasOwnProperty(carNumber)) {
            parkingLot[carNumber] = direction;
        } else if (direction == 'OUT' && parkingLot.hasOwnProperty(carNumber)) {
            delete parkingLot[carNumber];
        }
    }
    
    let allCarsInParking = Object.keys(parkingLot).sort((a, b) => a.localeCompare(b));
    if (allCarsInParking.length > 0) {
        for (const car of allCarsInParking) {
            console.log(car);
        }
    } else {
        console.log(`Parking Lot is Empty`);
    }
}

solve(['IN, CA2844AA',
       'IN, CA1234TA',
       'OUT, CA2844AA',
       'IN, CA9999TT',
       'IN, CA2866HI',
       'OUT, CA1234TA',
       'IN, CA2844AA',
       'OUT, CA2866HI',
       'IN, CA9876HH',
       'IN, CA2822UU']);

solve(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'OUT, CA1234TA']
);