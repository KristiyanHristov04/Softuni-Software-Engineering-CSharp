function charactersInRange(char01, char02) {
    let firstCharAsNumber = char01.charCodeAt(0);
    let secondCharAsNumber = char02.charCodeAt(0);
    let allNumbersBetween = [];
    let allSymbolsBetween = [];

    if (secondCharAsNumber < firstCharAsNumber) {
        let temp = firstCharAsNumber;
        firstCharAsNumber = secondCharAsNumber;
        secondCharAsNumber = temp;
    }

    for (let i = firstCharAsNumber + 1; i < secondCharAsNumber; i++) {
        allNumbersBetween.push(i);
    }


    for (let i = 0; i < allNumbersBetween.length; i++) {
        let currentSymbol = String.fromCharCode(allNumbersBetween[i]);
        allSymbolsBetween.push(currentSymbol);
    }

    console.log(allSymbolsBetween.join(' '));
}

charactersInRange('C', '#');