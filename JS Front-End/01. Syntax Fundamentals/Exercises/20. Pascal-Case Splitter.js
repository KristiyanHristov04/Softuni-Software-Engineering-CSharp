function solve(text){
    let array = [];
    let currentWord = '';
    let isFirstTime = true;
    for (let index = 0; index < text.length; index++) {
        let currentLetter = text[index];
        if(isFirstTime){
            currentWord += currentLetter;
            isFirstTime = false;
        }
        else {
            if(currentLetter.charCodeAt(0) >= 65 && currentLetter.charCodeAt(0) <= 90){
                array.push(currentWord);
                currentWord = currentLetter;
            }
            else{
                currentWord += currentLetter;
            }
        }
    }
    array.push(currentWord);
    console.log(array.join(', '));
}

solve('ThisIsSoAnnoyingToDo');