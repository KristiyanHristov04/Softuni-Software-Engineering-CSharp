function solve() {
    class Person {
        constructor(firstName, lastName, age, email) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.email = email;
        }
    
        toString() {
            return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`;
        }
    }

    const person01 = new Person('Anna', 'Simpson', 22, 'anna@yahoo.com');
    const person02 = new Person('SoftUni');
    const person03 = new Person('Stephan', 'Johnson', 25);
    const person04 = new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com');
    let people = [person01, person02, person03, person04];
    return people;
}

console.log(solve());