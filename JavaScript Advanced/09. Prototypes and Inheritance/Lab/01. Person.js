// class Person {
//     constructor(firstName, lastName) {
//         this.firstName = firstName,
//         this.lastName = lastName,
//         this.fullName = this.firstName + ' ' + this.lastName;
//     }

//     get fullName() {
//         return this.firstName + ' ' + this.lastName;
//     }

//     set fullName(value) {
//         let personInfo = value.split(' ');
//         if (personInfo.length === 2) {
//             this.firstName = personInfo[0];
//             this.lastName = personInfo[1];
//         }
//     }
// }

function Person(firstName, lastName) {
    const result = {
        firstName,
        lastName
    };

    Object.defineProperty(result, 'fullName', {
        get() {
            return this.firstName + ' ' + this.lastName;
        },
        set(value) {
            let personInfo = value.split(' ');
            if (personInfo.length === 2) {
                this.firstName = personInfo[0];
                this.lastName = personInfo[1];
            }
        }
    });

    return result;
}

let person = new Person("Peter", "Ivanov");
console.log(person.fullName); //Peter Ivanov
person.firstName = "George";
console.log(person.fullName); //George Ivanov
person.lastName = "Peterson";
console.log(person.fullName); //George Peterson
person.fullName = "Nikola Tesla";
console.log(person.firstName); //Nikola
console.log(person.lastName); //Tesla