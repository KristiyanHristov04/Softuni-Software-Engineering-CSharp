function solve(input) {
    let sectors = [];

    let flightsArray = input.shift();
    for (let index = 0; index < flightsArray.length; index++) {
        let [sector, destination] = flightsArray[index].split(' ');
        let sectorObject = {name: sector, destination, status: 'Ready to fly'};
        sectors.push(sectorObject);
    }

    let changedStatusesArray = input.shift();
    for (let i = 0; i < changedStatusesArray.length; i++) {
        let [sector, status] = changedStatusesArray[i].split(' ');
        for (let j = 0; j < sectors.length; j++) {
            if (sectors[j].name == sector) {
                sectors[j].status = status;
                break;
            }
        }
    }

    let flightStatusToCheck = input.shift();
    if (flightStatusToCheck[0] === 'Ready to fly') {
        for (let index = 0; index < sectors.length; index++) {
            let currentObjectStatus = sectors[index].status;
            if (currentObjectStatus == 'Ready to fly') {
                console.log(`{ Destination: '${sectors[index].destination}', Status: '${sectors[index].status}' }`);
            }
        }
    } else {
        for (let index = 0; index < sectors.length; index++) {
            let currentObjectStatus = sectors[index].status;
            if (currentObjectStatus == 'Cancelled') {
                console.log(`{ Destination: '${sectors[index].destination}', Status: '${sectors[index].status}' }`);
            }
        }
    }
}

solve([['WN269 Delaware',
       'FL2269 Oregon',
       'WN498 Las Vegas',
       'WN3145 Ohio',
       'WN612 Alabama',
       'WN4010 New York',
       'WN1173 California',
       'DL2120 Texas',
       'KL5744 Illinois',
       'WN678 Pennsylvania'],
       ['DL2120 Cancelled',
       'WN612 Cancelled',
       'WN1173 Cancelled',
       'SK330 Cancelled'],
       ['Ready to fly']]);
