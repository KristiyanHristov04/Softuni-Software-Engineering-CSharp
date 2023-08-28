function solve(array) {
    let cities = {};
    for (let index = 0; index < array.length; index++) {
        let [city, population] = array[index].split(' <-> ');
        population = Number(population);
        if (!cities.hasOwnProperty(city)) {
            cities[city] = population;
        } else {
            cities[city] += population;
        }
    }

    for (const city in cities) {
        console.log(`${city} : ${cities[city]}`);
    }
}

solve(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']
);