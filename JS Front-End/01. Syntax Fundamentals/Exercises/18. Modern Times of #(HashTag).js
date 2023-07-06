function solve(text) {
    let array = text.split(' ');
    for (let i = 0; i < array.length; i++) {
        let currentWord = array[i];
        let isValid = true;
        if(currentWord.startsWith('#') && currentWord.length > 1){
            for (let j = 1; j < currentWord.length; j++) {
                if((currentWord[j].charCodeAt(0) >= 65 && currentWord[j].charCodeAt(0) <= 90)
                    || (currentWord[j].charCodeAt(0) >= 97 && currentWord[j].charCodeAt(0) <= 122)){
                        isValid = true;
                    } else {
                        isValid = false;
                        break;
                    }
            }
            if(isValid){
                let newWord = currentWord.substr(1, currentWord.length);
                console.log(newWord);
            }
        }
    }
}

solve('Nowadays everyone uses # to tag a #special word in #socialMedia');