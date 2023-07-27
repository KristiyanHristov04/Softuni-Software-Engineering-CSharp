function solve() {
    class Storage {
        constructor(capacity) {
            this.capacity = capacity;
            this.storage = [];
            this.totalCost = 0;
        }

        addProduct(product) {
            this.storage.push(product);
            this.capacity -= product.quantity;
            this.totalCost += product.price * product.quantity;
        }

        getProducts() {
            let jsonStringAll = '';
            for (let index = 0; index < this.storage.length; index++) {
                let currentObject = JSON.stringify(this.storage[index]);
                jsonStringAll += currentObject + '\n';
            }
            return jsonStringAll.trimEnd();
        }
    }

    let productOne = {
        name: 'Cucamber',
        price: 1.50, quantity: 15
    };

    let productTwo = {
        name: 'Tomato', price:
            0.90, quantity: 25
    };

    let productThree = {
        name: 'Bread', price:
            1.10, quantity: 8
    };

    let storage = new Storage(50);
    storage.addProduct(productOne);
    storage.addProduct(productTwo);
    storage.addProduct(productThree);
    console.log(storage.getProducts());
    console.log(storage.capacity);
    console.log(storage.totalCost);
}

solve();