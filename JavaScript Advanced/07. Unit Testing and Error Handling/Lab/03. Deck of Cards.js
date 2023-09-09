function printDeckOfCards(cards) {
    let allCards = [];
    for (let index = 0; index < cards.length; index++) {
        let currentCard = cards[index];
        let cardFace = currentCard.slice(0, -1);
        let cardSuit = currentCard.slice(-1);
        try {
            let card = createCard(cardFace, cardSuit);
            allCards.push(card);
        } catch (error) {
            console.log(`Invalid card: ${cardFace + cardSuit}`);
            return;
        }
    }

    console.log(allCards.join(' '))

    function createCard(faceInput, suitInput) {
        let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let validSuits = ['S', 'H', 'D', 'C'];
        if (!validFaces.includes(faceInput)) {
            throw new Error();
        }

        if (!validSuits.includes(suitInput)) {
            throw new Error();
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
}

//printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5X', '3D', 'QD', '1C']);
