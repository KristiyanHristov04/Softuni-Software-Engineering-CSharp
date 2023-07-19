function carWash(commands) {
    let cleanProgress = 0;
    for (let index = 0; index < commands.length; index++) {
        let currentCommand = commands[index];
        switch (currentCommand) {
            case 'soap':
                cleanProgress += 10;
                break;
            case 'water':
                cleanProgress *= 1.20;
                break;
            case 'vacuum cleaner':
                cleanProgress *= 1.25;
                break;
            case 'mud':
                cleanProgress *= 0.90;
                break;
        }
    }

    console.log(`The car is ${cleanProgress.toFixed(2)}% clean.`);
}

carWash(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']);