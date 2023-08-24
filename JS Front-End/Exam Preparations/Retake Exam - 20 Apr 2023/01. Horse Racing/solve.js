function solve(input) {
    let horses = input.shift().split('|');

    while (true) {
        let action = input.shift().split(' ');
        if (action[0] === 'Retake') {
            let overtakingHorseName = action[1];
            let overtakenHorseName = action[2];
            let overtakingHorseIndex = -1;
            let overtakenHorseIndex = -1;

            for (let index = 0; index < horses.length; index++) {
                if (horses[index] === overtakingHorseName) {
                    overtakingHorseIndex = index;
                } else if (horses[index] === overtakenHorseName) {
                    overtakenHorseIndex = index;
                }
            }

            if (overtakingHorseIndex < overtakenHorseIndex) {
                horses[overtakenHorseIndex] = overtakingHorseName;
                horses[overtakingHorseIndex] = overtakenHorseName;
                console.log(`${overtakingHorseName} retakes ${overtakenHorseName}.`);
            }
        } else if (action[0] === 'Trouble') {
            let horseName = action[1];
            for (let index = 0; index < horses.length; index++) {
                if (horses[index] === horseName && index !== 0) {
                    let previousHorseName = horses[index - 1];
                    horses[index] = previousHorseName;
                    horses[index - 1] = horseName;
                    console.log(`Trouble for ${horseName} - drops one position.`);
                    break;
                }
            }
        } else if (action[0] === 'Rage') {
            let horseName = action[1];
            let horseIndex = -1;

            for (let index = 0; index < horses.length; index++) {
                if (horses[index] === horseName) {
                    horseIndex = index;
                    break;
                }
            }


            if (horseIndex === horses.length - 2) {
                let moveToFirst = horses.splice(horseIndex, 1);
                horses.push(horseName);
                console.log(`${horseName} rages 2 positions ahead.`);
            } else {
                let restFrontHorses = horses.splice(horseIndex + 3);
                let moveHorseName = horses.splice(horseIndex, 1);
                horses.push(moveHorseName[0]);
                for (const restHorse of restFrontHorses) {
                    horses.push(restHorse);
                }
                console.log(`${horseName} rages 2 positions ahead.`);
            }
        } else if (action[0] === 'Miracle') {
            let lastHorseName = horses.shift();
            horses.push(lastHorseName);
            console.log(`What a miracle - ${lastHorseName} becomes first.`);
        } else {
            break;
        }
    }

    console.log(horses.join('->'));
    console.log(`The winner is: ${horses[horses.length - 1]}`)
}

// solve((['Bella|Alexia|Sugar',
//     'Retake Alexia Sugar',
//     'Rage Bella',
//     'Trouble Bella',
//     'Finish'])
// );

solve((['Onyx|Domino|Sugar|Fiona',
'Trouble Onyx',
'Retake Onyx Sugar',
'Rage Domino',
'Miracle',
'Finish'])
);

// solve((['Fancy|Lilly',
// 'Retake Lilly Fancy',
// 'Trouble Lilly',
// 'Trouble Lilly',
// 'Finish',
// 'Rage Lilly'])
// );