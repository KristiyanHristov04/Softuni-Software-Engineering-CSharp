function solve(input) {
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }

        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    let cats = [];

    for (let index = 0; index < input.length; index++) {
        let [catName, catAge] = input[index].split(' ');
        let newCat = new Cat(catName, catAge);
        cats.push(newCat);
    }

    for (const cat of cats) {
        cat.meow();
    }
}

solve(['Mellow 2', 'Tom 5']);