function solve(text) {
    let wordsOccurences = {};
    let allWords = text.toLowerCase().split(' ');

    for (let index = 0; index < allWords.length; index++) {
        let currentWord = allWords[index];
        if (wordsOccurences.hasOwnProperty(currentWord)) {
            wordsOccurences[currentWord]++;
        } else {
            wordsOccurences[currentWord] = 1;
        }
    }

    let allOddWords = [];

    for (const key in wordsOccurences) {
        if (wordsOccurences[key] % 2 !== 0) {
            allOddWords.push(key);
        }
    }

    console.log(allOddWords.join(' '));
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
solve('Cake IS SWEET is Soft CAKE sweet Food');