function addItem() {
    let textToAdd = document.getElementById('newItemText').value;
    let newLi = document.createElement('li');
    newLi.textContent = textToAdd;
    let ul = document.getElementById('items');
    ul.appendChild(newLi);
    document.getElementById('newItemText').value = '';
}