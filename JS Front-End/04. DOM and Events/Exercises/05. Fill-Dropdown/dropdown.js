function addItem() {
    let newText = document.getElementById('newItemText').value;
    let newValue = document.getElementById('newItemValue').value;
    let newOption = document.createElement('option');
    let menu = document.getElementById('menu');
    newOption.textContent = newText;
    newOption.setAttribute('value', newValue);
    menu.appendChild(newOption);
    document.getElementById('newItemText').value = '';
    document.getElementById('newItemValue').value = '';
}