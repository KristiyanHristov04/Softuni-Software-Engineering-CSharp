function extractText() {
    let listElements = document.querySelectorAll('#items > li');
    console.log(listElements);
    let textarea = document.getElementById('result');
    for (const list of listElements) {
        textarea.textContent += list.textContent + '\n';
    }
}