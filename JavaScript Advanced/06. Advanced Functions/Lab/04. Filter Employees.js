function solve(data, criteria) {
    let dataFromJSON = JSON.parse(data);
    let [criteriaKey, criteriaValue] = criteria.split('-');
    let index = 0;
    let validData = [];
    for (let index = 0; index < dataFromJSON.length; index++) {
        let currentData = dataFromJSON[index];       
        if (criteriaKey !== 'all') {
            for (const prop in currentData) {
                if (prop === criteriaKey && currentData[prop] === criteriaValue) {
                    validData.push(currentData);
                }
            }
        } else {
            validData.push(currentData);
        }
    }

    for (let index = 0; index < validData.length; index++) {
        console.log(`${index}. ${validData[index].first_name} ${validData[index].last_name} - ${validData[index].email}`);
    }
}

solve(`[{
    "id": "1",
    "first_name": "Kaylee",
    "last_name": "Johnson",
    "email": "k0@cnn.com",
    "gender": "Female"
    }, {"id": "2",
    "first_name": "Kizzee",
    "last_name": "Johnson",
    "email": "kjost1@forbes.com",
    "gender": "Female"
    }, {
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
    }, {
    "id": "4",
    "first_name": "Evanne",
    "last_name": "Johnson",
    "email": "ev2@hostgator.com",
    "gender": "Male"
    }]`,
   'last_name-Johnson'   
);