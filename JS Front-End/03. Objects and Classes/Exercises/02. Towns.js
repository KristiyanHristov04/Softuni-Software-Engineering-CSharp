function solve(input) {
    let towns = [];

    for (const iterator of input) {
        let [townName, townLatitude, townLongitude] = iterator.split(' | ');
        townLatitude = Number(townLatitude);
        townLongitude = Number(townLongitude);
        let newTown = {
            town: townName,
            latitude: townLatitude.toFixed(2),
            longitude: townLongitude.toFixed(2)
        }
        towns.push(newTown);
    }

    for (const town of towns) {
        console.log(town);
    }
}

solve(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']);