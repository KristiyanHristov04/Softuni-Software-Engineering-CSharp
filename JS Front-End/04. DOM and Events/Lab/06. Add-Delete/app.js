function addItem() {
    let textToAdd = document.getElementById('newItemText').value;
    let newLi = document.createElement('li');
    let anchor = document.createElement('a');
    newLi.textContent = textToAdd;
    anchor.setAttribute('href', '#');
    anchor.textContent = '[Delete]';
    anchor.addEventListener('click', click);
    newLi.appendChild(anchor);
    let ul = document.getElementById('items');
    ul.appendChild(newLi);
    document.getElementById('newItemText').value = '';

    function click(e) {
        let parentElement = e.currentTarget.parentElement;
        parentElement.remove();
    }
}