function solve() {
    class Figure {
        constructor() {
            this.units = 'cm';
        }

        get area() {
            
        }

        changeUnits(value) {
            this.units = value;
        }

        toString() {
            return `Figures units: ${this.units}`;
        }
    }

    class Circle extends Figure {
        constructor(radius, units) {
            super(units);
            this.radius = radius;
        }

        get area() {
            if (this.units === 'cm') {
                return Math.PI * this.radius * this.radius;
            } else if (this.units == 'mm') {
                return Math.PI * (this.radius * 10) * (this.radius * 10);
            } else {
                return Math.PI * (this.radius / 10) * (this.radius / 10);
            }
            
        }

        toString() {
            if (this.units === 'cm') {
                return super.toString() + ` Area: ${this.area} - radius: ${this.radius}`;
            } else if (this.units === 'mm') {
                return super.toString() + ` Area: ${this.area} - radius: ${this.radius * 10}`;
            } else {
                return super.toString() + ` Area: ${this.area} - radius: ${this.radius / 10}`;
            }

        }
    }

    class Rectangle extends Figure {
        constructor(width, height, units) {
            super(units);
            this.units = units;
            this.width = width;
            this.height = height;
        }

        get area() {
            if (this.units === 'cm') {
                return this.width * this.height;
            } else if (this.units == 'mm') {
                return (this.width * 10) * (this.height * 10);
            } else {
                return (this.width / 10) * (this.height / 10);
            }

        }

        toString() {
            if (this.units === 'cm') {
                return super.toString() + ` Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
            } else if (this.units === 'mm') {
                return super.toString() + ` Area: ${this.area} - width: ${this.width * 10}, height: ${this.height * 10}`;
            } else {
                return super.toString() + ` Area: ${this.area} - width: ${this.width / 10}, height: ${this.height / 10}`;
            }
            
        }
    }

    return {
        Figure,
        Circle,
        Rectangle
    }
}

// let Circle = solve().Circle;
// let c = new Circle(5);
// console.log(c.area); // 78.53981633974483
// console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5
let Rectangle = solve().Rectangle;
let r = new Rectangle(3, 4, 'm');
console.log(r.area); // 1200
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40
r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4
// c.changeUnits('mm');
// console.log(c.area); // 7853.981633974483
// console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50