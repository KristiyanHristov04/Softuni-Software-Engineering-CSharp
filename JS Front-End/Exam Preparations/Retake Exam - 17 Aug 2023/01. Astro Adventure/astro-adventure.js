function solve(array) {
    let astronauts = {};
    let astronautsCount = Number(array.shift());
    while (astronautsCount > 0) {
        let currentAstronaut = array.shift();
        let [name, oxygen, energy] = currentAstronaut.split(' ');
        oxygen = Number(oxygen);
        energy = Number(energy);
        astronauts[name] = { oxygen, energy };
        astronautsCount--;
    }

    while (true) {
        let input = array.shift();
        if (input === 'End') {
            break;
        } else {
            let [command, name, value] = input.split(' - ');
            value = Number(value);

            switch (command) {
                case 'Explore':
                    if (astronauts[name].energy >= value) {
                        astronauts[name].energy -= value;
                        console.log(`${name} has successfully explored a new area and now has ${astronauts[name].energy} energy!`);
                    } else {
                        console.log(`${name} does not have enough energy to explore!`);
                    }
                    break;
                case 'Refuel':
                    if (astronauts[name].energy + value > 200) {
                        let amountRecovered = 200 - astronauts[name].energy;
                        astronauts[name].energy += amountRecovered;
                        console.log(`${name} refueled their energy by ${amountRecovered}!`);
                    } else {
                        astronauts[name].energy += value;
                        console.log(`${name} refueled their energy by ${value}!`);
                    }
                    break;
                case 'Breathe':
                    if (astronauts[name].oxygen + value > 100) {
                        let amountRecovered = 100 - astronauts[name].oxygen;
                        astronauts[name].oxygen += amountRecovered;
                        console.log(`${name} took a breath and recovered ${amountRecovered} oxygen!`);
                    } else {
                        astronauts[name].oxygen += value;
                        console.log(`${name} took a breath and recovered ${value} oxygen!`);
                    }
                    break;
            }
        }
    }

    for (const key in astronauts) {
        console.log(`Astronaut: ${key}, Oxygen: ${astronauts[key].oxygen}, Energy: ${astronauts[key].energy}`);
    }
}

// solve(['3',
//     'John 50 120',
//     'Kate 80 180',
//     'Rob 70 150',
//     'Explore - John - 50',
//     'Refuel - Kate - 30',
//     'Breathe - Rob - 20',
//     'End']
// );

solve([    '4',
'Alice 60 100',
'Bob 40 80',
'Charlie 70 150',
'Dave 80 180',
'Explore - Bob - 60',
'Refuel - Alice - 30',
'Breathe - Charlie - 50',
'Refuel - Dave - 40',
'Explore - Bob - 40',
'Breathe - Charlie - 30',
'Explore - Alice - 40',
'End']
);