function solve() {
    let textarea = document.getElementById('input');
    let sentences = textarea.value.split('.').filter((sentence) => sentence.length > 0);
    let output = document.getElementById('output');
    while (sentences.length > 0) {
      if (sentences.length > 3) {
        let paragraph = `${sentences[0]}.${sentences[1]}.${sentences[2]}.`;
        sentences.shift();
        sentences.shift();
        sentences.shift();
        output.innerHTML += `<p>${paragraph.trimStart()}</p>`;
      } else {
        let paragraph = sentences.join('.');
        output.innerHTML += `<p>${paragraph.trimStart()}.</p>`;
        sentences = [];
      }
    }
}