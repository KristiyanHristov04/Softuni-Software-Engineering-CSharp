function create(words) {
   let mainDiv = document.getElementById('content');
   for (const word of words) {
      let newDiv = document.createElement('div');
      let newParagraph = document.createElement('p');
      newParagraph.textContent = word;
      newParagraph.style.display = 'none';
      newDiv.appendChild(newParagraph);
      newDiv.addEventListener('click', displayHiddenParagraph);
      mainDiv.appendChild(newDiv);
   }


   function displayHiddenParagraph() {
      let children = this.children;
      children[0].style.display = 'block';
   }
}