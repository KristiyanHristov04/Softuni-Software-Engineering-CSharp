function solve(words, text){
    let possibleWordsToPlace = words.split(', ');
    let textInArray = text.split(' ');
    for (let i = 0; i < textInArray.length; i++) {
        let currentWord = textInArray[i];
        if(currentWord.includes('*')){
            for (let j = 0; j < possibleWordsToPlace.length; j++) {
                let currentWordToPlace = possibleWordsToPlace[j];
                if(currentWordToPlace.length == currentWord.length){
                    textInArray[i] = currentWordToPlace;
                    break;
                } 
            }
        }
    }
    console.log(textInArray.join(' '));
}

solve('great, learning', 'softuni is ***** place for ******** new programming languages');