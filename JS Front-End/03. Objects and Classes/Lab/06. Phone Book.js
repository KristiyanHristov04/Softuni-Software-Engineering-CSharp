function phoneBookFunction(input) {
    let phoneBook = {};

    for (let index = 0; index < input.length; index++) {
        let [ name, phoneNumber ] = input[index].split(' ');
        phoneBook[name] = phoneNumber;
    }

    for (const key in phoneBook) {
        console.log(`${key} -> ${phoneBook[key]}`);
    }
}

phoneBookFunction(['Tim 0834212554',
'Peter 0877547887',
'Bill 0896543112',
'Tim 0876566344']
);