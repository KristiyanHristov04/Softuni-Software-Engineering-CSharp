function solve(input) {
    let tournamentsParticipations = Number(input[0]);
    let startigPoints = Number(input[1]);
    let earnedPointsDuringTournaments = 0;
    let numberOfWonTournaments = 0;

    for (let i = 0; i < input.length; i++) {
        let place = input[i];
        switch (place) {
            case 'W':
                earnedPointsDuringTournaments += 2000;
                numberOfWonTournaments++;
                break;
            case 'F':
                earnedPointsDuringTournaments += 1200;
                break;
            case 'SF':
                earnedPointsDuringTournaments += 720;
                break;
        }
    }

    let totalPointsAfterAllTournaments = startigPoints + earnedPointsDuringTournaments;
    let averagePointsPerTournament = Math.floor(earnedPointsDuringTournaments / tournamentsParticipations);
    let wonTournamentsInPercentage = (numberOfWonTournaments / tournamentsParticipations) * 100;

    console.log(`Final points: ${totalPointsAfterAllTournaments}`);
    console.log(`Average points: ${averagePointsPerTournament}`);
    console.log(`${wonTournamentsInPercentage.toFixed(2)}%`);
}

// solve(['5', '1400', 'F', 'SF', 'W', 'W', 'SF']);
