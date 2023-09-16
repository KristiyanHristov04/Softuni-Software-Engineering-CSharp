function solve(input) {
    let juiceQuantities = {};
    let juiceBottles = new Map();
    for (let index = 0; index < input.length; index++) {
        let [flavour, quantity] = input[index].split(' => ');
        quantity = Number(quantity);

        if (!juiceQuantities.hasOwnProperty(flavour)) {
            juiceQuantities[flavour] = quantity;
            if (juiceQuantities[flavour] >= 1000) {
                while (juiceQuantities[flavour] >= 1000) {
                    juiceQuantities[flavour] -= 1000;
                    if (!juiceBottles.has(flavour)) {
                        juiceBottles.set(flavour, 1);
                    } else {
                        let previousBottles = juiceBottles.get(flavour);
                        juiceBottles.set(flavour, previousBottles + 1);
                    }
                }
            }
        } else {
            juiceQuantities[flavour] += quantity;
            if (juiceQuantities[flavour] >= 1000) {
                while (juiceQuantities[flavour] >= 1000) {
                    juiceQuantities[flavour] -= 1000;
                    if (!juiceBottles.has(flavour)) {
                        juiceBottles.set(flavour, 1);
                    } else {
                        let previousBottles = juiceBottles.get(flavour);
                        juiceBottles.set(flavour, previousBottles + 1);
                    }
                }
            }
        }
    }
    
    let bottles = Array.from(juiceBottles);
    for (let index = 0; index < bottles.length; index++) {
        console.log(`${bottles[index][0]} => ${bottles[index][1]}`);
    }
}

solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']);


solve(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']);