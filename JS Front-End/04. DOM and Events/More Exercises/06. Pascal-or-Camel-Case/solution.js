function solve() {
  let text = document.getElementById('text').value;
  let namingConvention = document.getElementById('naming-convention').value;
  let result = document.getElementById('result');

  if (namingConvention === 'Camel Case') {
    result.textContent = convertToCamelCase(text);
  } else if (namingConvention === 'Pascal Case') {
    result.textContent = convertToPascalCase(text);
  } else {
    result.textContent = 'Error!';
  }

  function convertToCamelCase(text) {
    let result = '';
    let allWords = text.split(' ').map((element) => element.toLowerCase());
    result += allWords.shift();
    for (let i = 0; i < allWords.length; i++) {
        let currentWord = allWords[i];
        let finalWord = '';
        for (let j = 0; j < currentWord.length; j++) {
          if (j === 0) {
            let currentChar = currentWord[j].toUpperCase();
            finalWord += currentChar;
          } else {
            finalWord += currentWord[j];
          }
        }
        result += finalWord;
    }
    return result;
  }

  function convertToPascalCase(text) {
    let result = '';
    let allWords = text.split(' ').map((element) => element.toLowerCase());
    for (let i = 0; i < allWords.length; i++) {
        let currentWord = allWords[i];
        let finalWord = '';
        for (let j = 0; j < currentWord.length; j++) {
          if (j === 0) {
            let currentChar = currentWord[j].toUpperCase();
            finalWord += currentChar;
          } else {
            finalWord += currentWord[j];
          }
        }
        result += finalWord;
    }
    return result;
  }
}