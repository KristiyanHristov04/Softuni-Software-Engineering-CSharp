function solve(char1, char2, char3){
    let string = char1 + char2 + char3;
    let reversedString = '';
    for (let index = string.length - 1; index >= 0; index--) {
        reversedString += string[index] + ' ';
    }
    console.log(reversedString);
}

solve('A', 'B', 'C');