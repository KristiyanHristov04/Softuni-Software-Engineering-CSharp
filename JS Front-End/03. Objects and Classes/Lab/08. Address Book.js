function addressBookFunction(input) {
    let addressBook = {};
    for (const iterator of input) {
        let [name, address] = iterator.split(':');
        addressBook[name] = address;
    }

    let entries = Object.entries(addressBook);
    let sortedEntries = [...entries].sort((a, b) => a[0].localeCompare(b[0]));

    for (const iterator of sortedEntries) {
        console.log(`${iterator[0]} -> ${iterator[1]}`);
    }
}

addressBookFunction(['Bob:Huxley Rd',
'John:Milwaukee Crossing',
'Peter:Fordem Ave',
'Bob:Redwing Ave',
'George:Mesta Crossing',
'Ted:Gateway Way',
'Bill:Gateway Way',
'John:Grover Rd',
'Peter:Huxley Rd',
'Jeff:Gateway Way',
'Jeff:Huxley Rd']
);