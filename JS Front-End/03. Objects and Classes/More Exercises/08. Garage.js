function solve(input) {
    let garages = {};
    for (let i = 0; i < input.length; i++) {
        let line = input[i].split(' - ');
        let garageNumber = Number(line.shift());
        let carInfoArray = line[0].split(', ');
        if (garages.hasOwnProperty(garageNumber)) {
            let currentCarObjInfo = {};
            for (let j = 0; j < carInfoArray.length; j++) {
                let [key, value] = carInfoArray[j].split(': ');
                currentCarObjInfo[key] = value;
            }
            garages[garageNumber].push(currentCarObjInfo);
        } else {
            let currentCarObjInfo = {};
            for (let j = 0; j < carInfoArray.length; j++) {
                let [key, value] = carInfoArray[j].split(': ');
                currentCarObjInfo[key] = value;
            }
            garages[garageNumber] = [currentCarObjInfo];
        }
    }

    let entries = Object.entries(garages);
    for (let i = 0; i < entries.length; i++) {
        console.log(`Garage № ${entries[i][0]}`);
        let carsArray = entries[i][1];
        for (let j = 0; j < carsArray.length; j++) {
            let allKeys = Object.keys(carsArray[j]);
            let allValues = Object.values(carsArray[j]);
            let combinedInfo = [];
            for (let k = 0; k < allKeys.length; k++) {
                let info = allKeys[k] + ' - ' + allValues[k];
                combinedInfo.push(info);
            }
            console.log(`--- ${combinedInfo.join(', ')}`);
        }
    }
}

solve(['1 - color: blue, fuel type: diesel',
    '1 - color: red, manufacture: Audi',
    '2 - fuel type: petrol',
    '4 - color: dark blue, fuel type: diesel, manufacture: Fiat']
);