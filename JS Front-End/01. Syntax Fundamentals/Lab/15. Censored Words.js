function solve(text, wordToReplace){
    while(text.includes(wordToReplace)){
        text = text.replace(wordToReplace, '*'.repeat(wordToReplace.length));
    }
    console.log(text);
}

solve('A small sentence with some words small', 'small');