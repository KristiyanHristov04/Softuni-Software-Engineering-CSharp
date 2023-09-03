function extract(content) {
    let paragraph = document.getElementById(content);
    let paragraphText = paragraph.textContent;
    let pattern = /\([\w\s]+\)/g;
    let allMatchesArray = Array.from(paragraphText.matchAll(pattern));
    let allWords = [];
    for (let index = 0; index < allMatchesArray.length; index++) {
        let currentWord = allMatchesArray[index][0];
        let currentWordNoParenthesis = '';
        for (let j = 1; j < currentWord.length - 1; j++) {
            currentWordNoParenthesis += currentWord[j];
        }
        allWords.push(currentWordNoParenthesis);
    }
    let result = allWords.join('; ');
    return result;
}