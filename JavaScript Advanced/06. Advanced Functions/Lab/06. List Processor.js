function solve(input) {
    let collection = [];

    for (let index = 0; index < input.length; index++) {
        let [command01, command02] = input[index].split(' ');
        if (command01 === 'add') {
            collection.push(command02);
        } else if (command01 === 'remove') {
            collection = collection.filter(element => element !== command02);
        } else {
            console.log(collection.join(','));
        }
    }
}

solve(['add pesho', 'add george', 'add peter', 'remove peter','print']);