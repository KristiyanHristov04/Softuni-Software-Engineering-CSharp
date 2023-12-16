function solve(array) {
    let baristas = {};
    let baristasCount = Number(array.shift());

    for (let index = 0; index < baristasCount; index++) {
        let [baristaName, baristaShift, baristaCoffeeTypes] = array.shift().split(' ');
        let coffeeTypesArray = baristaCoffeeTypes.split(',');
        baristas[baristaName] = {
            baristaName,
            shift: baristaShift,
            coffeeTypes: coffeeTypesArray
        };
    }

    while (true) {
        let input = array.shift();

        if (input === 'Closed') {
            break;
        }

        let commands = input.split(' / ');
        let mainCommand = commands[0];

        if (mainCommand === 'Prepare') {
            let baristaName = commands[1];
            let shift = commands[2];
            let coffeeType = commands[3];

            if (baristas[baristaName].coffeeTypes.includes(coffeeType) &&
                baristas[baristaName].shift === shift) {
                console.log(`${baristaName} has prepared a ${coffeeType} for you!`);
            } else {
                console.log(`${baristaName} is not available to prepare a ${coffeeType}.`);
            }
        } else if (mainCommand === 'Change Shift') {
            let baristaName = commands[1];
            let newShift = commands[2];

            baristas[baristaName].shift = newShift;
            console.log(`${baristaName} has updated his shift to: ${newShift}`);
        } else if (mainCommand === 'Learn') {
            let baristaName = commands[1];
            let newCoffeeType = commands[2];

            if(baristas[baristaName].coffeeTypes.includes(newCoffeeType)) {
                console.log(`${baristaName} knows how to make ${newCoffeeType}.`);
            } else {
                baristas[baristaName].coffeeTypes.push(newCoffeeType);
                console.log(`${baristaName} has learned a new coffee type: ${newCoffeeType}.`);
            }
        }
    }

    for (const key in baristas) {
        console.log(`Barista: ${key}, Shift: ${baristas[key].shift}, Drinks: ${baristas[key].coffeeTypes.join(', ')}`);
    }
}

// solve([
//     '3',
//     'Alice day Espresso,Cappuccino',
//     'Bob night Latte,Mocha',
//     'Carol day Americano,Mocha',
//     'Prepare / Alice / day / Espresso',
//     'Change Shift / Bob / night',
//     'Learn / Carol / Latte',
//     'Learn / Bob / Latte',
//     'Prepare / Bob / night / Latte',
//     'Closed']
// );

solve(['4',
'Alice day Espresso,Cappuccino',
'Bob night Latte,Mocha',
'Carol day Americano,Mocha',
'David night Espresso',
'Prepare / Alice / day / Espresso',
'Change Shift / Bob / day',
'Learn / Carol / Latte',
'Prepare / Bob / night / Latte',
'Learn / David / Cappuccino',
'Prepare / Carol / day / Cappuccino',
'Change Shift / Alice / night',
 'Learn / Bob / Mocha',
'Prepare / David / night / Espresso',
'Closed']
);