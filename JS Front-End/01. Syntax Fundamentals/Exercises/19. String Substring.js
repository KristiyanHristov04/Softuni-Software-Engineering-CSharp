function solve(word, text){
    let wordLowered = word.toLowerCase();
    let textLowered = text.toLowerCase();    

    let array = textLowered.split(' ');
    for (let index = 0; index < array.length; index++) {
        if(array[index] == wordLowered){
            console.log(word);
            return;
        }
    }
    console.log(`${word} not found!`);
}

solve('cat', 'category is the bestprogramming language');