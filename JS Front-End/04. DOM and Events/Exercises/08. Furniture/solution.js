function solve() {
  let buttons = document.querySelectorAll('button');
  let firstButton = buttons[0];
  let secondButton = buttons[1];
  firstButton.addEventListener('click', getJSONData);
  secondButton.addEventListener('click', buyInfo);


  function getJSONData() {
    let textarea = document.querySelector('textarea');
    let JSONData = JSON.parse(textarea.value);

    for (const data of JSONData) {
      let currentTr = document.createElement('tr');
      console.log(data.img);
      for (let index = 1; index <= 5; index++) {
        if (index === 1) {
          let currentTd = document.createElement('td');
          let image = document.createElement('img');
          image.setAttribute('src', data.img);
          currentTd.appendChild(image);
          currentTr.appendChild(currentTd);
        } else if (index === 2) {
          let currentTd = document.createElement('td');
          let paragraph = document.createElement('p');
          paragraph.textContent = data.name;
          currentTd.appendChild(paragraph);
          currentTr.appendChild(currentTd);
        } else if (index === 3) {
          let currentTd = document.createElement('td');
          let paragraph = document.createElement('p');
          paragraph.textContent = data.price;
          currentTd.appendChild(paragraph);
          currentTr.appendChild(currentTd);
        } else if (index === 4) {
          let currentTd = document.createElement('td');
          let paragraph = document.createElement('p');
          paragraph.textContent = data.decFactor;
          currentTd.appendChild(paragraph);
          currentTr.appendChild(currentTd);
        } else {
          let currentTd = document.createElement('td');
          let input = document.createElement('input');
          input.setAttribute('type', 'checkbox')
          currentTd.appendChild(input);
          currentTr.appendChild(currentTd);
        }
      }

      let table = document.querySelector('table tbody');
      table.appendChild(currentTr);
    }
  }
  
  function buyInfo() {
    let allCheckboxes = Array.from(document.querySelectorAll('table tbody tr td input'));
    let allCheckedCheckBoxes = allCheckboxes.filter((box) => box.checked === true);
    let boughtFurnitures = [];
    let totalPrice = 0;
    let averageDecoration = 0;

    for (const checkedBox of allCheckedCheckBoxes) {
      let boughtFurniture = checkedBox.parentElement.parentElement.children[1].children[0].textContent;
      boughtFurnitures.push(boughtFurniture);
      let furniturePrice = Number(checkedBox.parentElement.parentElement.children[2].children[0].textContent);
      totalPrice += furniturePrice;
      let decorationFactor = Number(checkedBox.parentElement.parentElement.children[3].children[0].textContent);
      console.log(decorationFactor);
      averageDecoration += decorationFactor;
    }

    averageDecoration /= boughtFurnitures.length;

    let textarea = document.getElementsByTagName('textarea')[1];
    textarea.value = `Bought furniture: ${boughtFurnitures.join(', ')}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${averageDecoration}`;
  }
}