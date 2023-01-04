function solve(word01, word02, word03 ){
    let wordsSum = word01.length + word02.length + word03.length;
    console.log(wordsSum);
    let averageSum = Math.floor(wordsSum / 3);
    console.log(averageSum);
}
solve('pasta', '5', '22.3');