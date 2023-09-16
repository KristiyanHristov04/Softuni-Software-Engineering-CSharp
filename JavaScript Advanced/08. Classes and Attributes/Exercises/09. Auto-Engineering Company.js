function solve(input) {
    let carCompany = {};
    for (let i = 0; i < input.length; i++) {
        let [carBrand, carModel, producedCars] = input[i].split(' | ');
        producedCars = Number(producedCars);

        if (!carCompany.hasOwnProperty(carBrand)) {
            carCompany[carBrand] = [{carModel, producedCars}];
        } else {
            let isExisting = false;
            for (let j = 0; j < carCompany[carBrand].length; j++) {
                if (carCompany[carBrand][j].carModel === carModel) {
                    isExisting = true;
                    carCompany[carBrand][j].producedCars += producedCars;
                    break;
                }
            }

            if (!isExisting) {
                carCompany[carBrand].push({carModel, producedCars});
            }
        }
    }

    let cars = Object.entries(carCompany);
    for (let i = 0; i < cars.length; i++) {
        console.log(cars[i][0]);
        for (let j = 0; j < cars[i][1].length; j++) {
            console.log(`###${cars[i][1][j].carModel} -> ${cars[i][1][j].producedCars}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
);