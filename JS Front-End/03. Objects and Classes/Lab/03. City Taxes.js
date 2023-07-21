function cityTaxes(cityName, cityPopulation, cityTreasury) {
    let cityObject = { 
        name: cityName,
        population: cityPopulation,
        treasury: cityTreasury,
        taxRate: 10,
        collectTaxes: function() {
            this.treasury += Math.floor(this.population * this.taxRate);
        },
        applyGrowth: function (percentage) {
            this.population += Math.floor(this.population * (percentage / 100));
        },
        applyRecession: function (percentage) {
            this.treasury -= Math.floor(this.treasury * (percentage / 100));
        }
    };

    return cityObject;
}

const city = cityTaxes('Tortuga', 7000, 15000);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population);
