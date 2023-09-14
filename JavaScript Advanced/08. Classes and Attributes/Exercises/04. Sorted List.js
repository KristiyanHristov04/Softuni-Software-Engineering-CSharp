class List {
    constructor() {
        this.collection = [];
        this.size = 0;
    }

    add(element) {
        this.collection.push(element);
        this.size++;
        this.collection = this.collection.sort((a, b) => a - b);
    }

    remove(index) {
        if (index < 0 || index > this.size - 1) {
            throw new Error('Outside the bounds of the array!');
        }

        this.collection.splice(index, 1);
        this.size--;
    }

    get(index) {
        if (index < 0 || index > this.size - 1) {
            throw new Error('Outside the bounds of the array!');
        }

        return this.collection[index];
    }
}


let list = new List();
list.add(6);
list.add(4);
list.add(1);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));