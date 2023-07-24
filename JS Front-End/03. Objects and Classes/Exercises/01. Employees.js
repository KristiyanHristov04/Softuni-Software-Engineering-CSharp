function solve(input) {
    let employees = {};

    for (const iterator of input) {
        let name = iterator;
        let personalNumber = name.length;
        employees[name] = personalNumber;
    }

    for (const key in employees) {
        console.log(`Name: ${key} -- Personal Number: ${employees[key]}`);
    }
}

solve([
'Silas Butler',
'Adnaan Buckley',
'Juan Peterson',
'Brendan Villarreal'
]);