function solve(input) {
    let wordsCount = {};
    let wordToCheck = input.shift().split(' ');

    for (let index = 0; index < wordToCheck.length; index++) {
        let currentWord = wordToCheck[index];
        wordsCount[currentWord] = 0;
    }

    for (let index = 0; index < input.length; index++) {
        let currentWord = input[index];
        if (wordsCount.hasOwnProperty(currentWord)) {
            wordsCount[currentWord]++;
        }
    }

    let entries = Object.entries(wordsCount);
    entries = entries.sort((a, b) => b[1] - a[1]);

    for (let index = 0; index < entries.length; index++) {
        console.log(`${entries[index][0]} - ${entries[index][1]}`);
    }
}

// solve([
//     'this sentence',
//     'In', 'this', 'sentence', 'you', 'have',
//     'to', 'count', 'the', 'occurrences', 'of',
//     'the', 'words', 'this', 'and', 'sentence',
//     'because', 'this', 'is', 'your', 'task'
//     ]);

solve([
    'is the',
    'first', 'sentence', 'Here', 'is',
    'another', 'the', 'And', 'finally', 'the',
    'the', 'sentence']
    );