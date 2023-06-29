function solve(text, word){
    let textToArray = text.split(' ');
    let wordMetCount = 0;
    for (let index = 0; index < textToArray.length; index++) {
        if(textToArray[index] == word){
            wordMetCount++;
        }
    }
    console.log(wordMetCount);
}

solve('This is me and this is you', 'is');