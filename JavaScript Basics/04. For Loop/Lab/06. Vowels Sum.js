function solve(input) {
    let word = input[0];
    let vowelsSum = 0;
    for (let i = 0; i < word.length; i++) {
        switch (word[i]) {
            case 'a':
                vowelsSum += 1;
                break;
            case 'e':
                vowelsSum += 2;
                break;
            case 'i':
                vowelsSum += 3;
                break;
            case 'o':
                vowelsSum += 4;
                break;
            case 'u':
                vowelsSum += 5;
                break;
        }
    }
    console.log(vowelsSum);
}

// solve(['hello']);