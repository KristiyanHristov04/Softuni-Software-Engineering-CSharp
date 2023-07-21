function city(city) {
    for (const key in city) {
        console.log(`${key} -> ${city[key]}`)
    }
}

let cityObject = {
    name: 'Sofia',
    area: 492,
    population: 1238438,
    country: 'Bulgaria',
    poscode: 1000
};

city(cityObject);