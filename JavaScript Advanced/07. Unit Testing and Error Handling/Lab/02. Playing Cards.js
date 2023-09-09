function solve(faceInput, suitInput) {
    let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    if (!validFaces.includes(faceInput)) {
        throw new Error('Error');
    }

    let suitSymbol = '';
    if (suitInput === 'S') {
        suitSymbol = '\u2660';
    } else if (suitInput === 'H') {
        suitSymbol = '\u2665';
    } else if (suitInput === 'D') {
        suitSymbol = '\u2666';
    } else {
        suitSymbol = '\u2663';
    }

    let card = {
        face: faceInput,
        suit: suitSymbol,
        toString() {
            return this.face + this.suit;
        }
    };

    return card.toString();
}

console.log(solve('A', 'S'));
console.log(solve('10', 'H'));
console.log(solve('1', 'S'));