function extractText() {
    let listElements = document.querySelectorAll('ul > li');
    let textarea = document.getElementById('result');
    for (const list of listElements) {
        textarea.textContent += list.textContent + '\n';
    }
}