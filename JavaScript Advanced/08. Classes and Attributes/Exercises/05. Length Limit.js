class Stringer {
    constructor(string, length) {
        this.innerString = string;
        this.innerLength = length;
    }

    increase(value) {
        this.innerLength += value;
    }

    decrease(value) {
        if (this.innerLength - value < 0) {
            this.innerLength = this.innerLength = 0;
        } else {
            this.innerLength = this.innerLength - value;
        }
    }

    toString() {
        if (this.innerString.length > this.innerLength && this.innerLength !== 0) {
            let symbolsToTruncate = this.innerString.length - this.innerLength;
            return this.innerString.slice(0, symbolsToTruncate) + '...';
        } else if (this.innerLength === 0) {
            return '...';
        }
        else {
            return this.innerString;
        }
    }
}

let stringer = new Stringer('Kristiyan', 2);
console.log(stringer.toString()); // Test
stringer.decrease(3);
console.log(stringer.toString()); // Te...
stringer.decrease(5);
console.log(stringer.toString()); // ...
stringer.increase(4);
console.log(stringer.toString()); // Test
