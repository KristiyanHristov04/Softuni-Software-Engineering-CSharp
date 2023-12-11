function solve(array) {
    let racers = {};
    let racersCount = Number(array.shift());

    while (racersCount > 0) {
        let [racerName, racerFuel, racerPosition] = array.shift().split('|');
        racers[racerName] = { fuelCapacity: Number(racerFuel), position: Number(racerPosition) };
        racersCount--;
    }

    while (true) {
        let input = array.shift();
        if (input === 'Finish') {
            break;
        } else {
            let currentCommandData = input.split(' - ');
            let mainCommand = currentCommandData[0];
            switch (mainCommand) {
                case 'StopForFuel':
                    let rider = currentCommandData[1];
                    let minimumFuel = Number(currentCommandData[2]);
                    let changedPosition = Number(currentCommandData[3]);

                    if (racers[rider].fuelCapacity < minimumFuel) {
                        racers[rider].position = changedPosition;
                        console.log(`${rider} stopped to refuel but lost his position, now he is ${changedPosition}.`);
                    } else {
                        console.log(`${rider} does not need to stop for fuel!`);
                    }
                    break;
                case 'Overtaking':
                    let rider1Name = currentCommandData[1];
                    let rider2Name = currentCommandData[2];

                    if (racers[rider1Name].position < racers[rider2Name].position) {
                        let firstRiderPosition = racers[rider1Name].position;
                        racers[rider1Name].position = racers[rider2Name].position;
                        racers[rider2Name].position = firstRiderPosition;
                        console.log(`${rider1Name} overtook ${rider2Name}!`);
                    }
                    break;
                case 'EngineFail':
                    let _rider = currentCommandData[1];
                    let lapsLeft = currentCommandData[2];
                    delete racers[_rider];
                    console.log(`${_rider} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`);
                    break;
            }
        }
    }

    for (const key in racers) {
        console.log(`${key}`)
        console.log(`  Final position: ${racers[key].position}`);
    }
}

// solve(["3",
//     "Valentino Rossi|100|1",
//     "Marc Marquez|90|2",
//     "Jorge Lorenzo|80|3",
//     "StopForFuel - Valentino Rossi - 50 - 1",
//     "Overtaking - Marc Marquez - Jorge Lorenzo",
//     "EngineFail - Marc Marquez - 10",
//     "Finish"]
// );

solve((["4",
"Valentino Rossi|100|1",
"Marc Marquez|90|3",
"Jorge Lorenzo|80|4",
"Johann Zarco|80|2",
"StopForFuel - Johann Zarco - 90 - 5",
"Overtaking - Marc Marquez - Jorge Lorenzo",
"EngineFail - Marc Marquez - 10",
"Finish"])
);