function solve(input) {
    let pieces = {};
    let initialPieces = Number(input.shift());
    for (let index = 0; index < initialPieces; index++) {
        let pieceInformation = input[index].split('|');
        let pieceName = pieceInformation[0];
        let pieceAuthor = pieceInformation[1];
        let pieceKey = pieceInformation[2];
        pieces[pieceName] = { author: pieceAuthor, key: pieceKey };
    }
    
    while (initialPieces > 0) {
        input.shift();
        initialPieces--;
    }

    while (true) {
        let operation = input.shift();
        operation = operation.split('|');
        if (operation[0] === 'Stop') {
            for (const key in pieces) {
                console.log(`${key} -> Composer: ${pieces[key].author}, Key: ${pieces[key].key}`);
            }
            break;
        } else if (operation[0] === 'Add') {
            let operationPiece = operation[1];
            let operationComposer = operation[2];
            let operationKey = operation[3];
            if (!pieces.hasOwnProperty(operationPiece)) {
                pieces[operationPiece] = {author: operationComposer, key: operationKey};
                console.log(`${operationPiece} by ${operationComposer} in ${operationKey} added to the collection!`);
            } else {
                console.log(`${operationPiece} is already in the collection!`);
            }
        } else if (operation[0] === 'Remove') {
            let pieceToRemove = operation[1];
            if (pieces.hasOwnProperty(pieceToRemove)) {
                delete pieces[pieceToRemove];
                console.log(`Successfully removed ${pieceToRemove}!`);
            } else {
                console.log(`Invalid operation! ${pieceToRemove} does not exist in the collection.`);
            }
        } else if (operation[0] === 'ChangeKey') {
            let pieceToChangeKey = operation[1];
            let newKey = operation[2];
            if (pieces.hasOwnProperty(pieceToChangeKey)) {
                pieces[pieceToChangeKey].key = newKey;
                console.log(`Changed the key of ${pieceToChangeKey} to ${newKey}!`);
            } else {
                console.log(`Invalid operation! ${pieceToChangeKey} does not exist in the collection.`)
            }
        }
    }
}

solve([
    '3',
    'Fur Elise|Beethoven|A Minor',
    'Moonlight Sonata|Beethoven|C# Minor',
    'Clair de Lune|Debussy|C# Minor',
    'Add|Sonata No.2|Chopin|B Minor',
    'Add|Hungarian Rhapsody No.2|Liszt|C# Minor',
    'Add|Fur Elise|Beethoven|C# Minor',
    'Remove|Clair de Lune',
    'ChangeKey|Moonlight Sonata|C# Major',
    'Stop'
]
);