window.addEventListener("load", solve);

function solve() {
  const firstNameInput = document.getElementById('first-name');
  const lastNameInput = document.getElementById('last-name');
  const ageInput = document.getElementById('age');
  const storyTitleInput = document.getElementById('story-title');
  const genreSelectMenu = document.getElementById('genre');
  const storyTextarea = document.getElementById('story');
  const formButton = document.getElementById('form-btn');
  const previewList = document.getElementById('preview-list');
  const mainDiv = document.getElementById('main');

  formButton.addEventListener('click', addToPreviewHandler);

  function addToPreviewHandler() {
    if (checkIfAllInputsAreValid(firstNameInput, lastNameInput, ageInput, genreSelectMenu, storyTitleInput, storyTextarea)) {
      let li = document.createElement('li');
      li.classList.add('story-info');
      let article = document.createElement('article');
      let h4 = document.createElement('h4');
      h4.textContent = `Name: ${firstNameInput.value} ${lastNameInput.value}`;
      let p01 = document.createElement('p');
      p01.textContent = `Age: ${ageInput.value}`;
      let p02 = document.createElement('p');
      p02.textContent = `Title: ${storyTitleInput.value}`;
      let p03 = document.createElement('p');
      p03.textContent = `Genre: ${genreSelectMenu.value}`;
      let p04 = document.createElement('p');
      p04.textContent = `${storyTextarea.value}`;
      article.appendChild(h4);
      article.appendChild(p01);
      article.appendChild(p02);
      article.appendChild(p03);
      article.appendChild(p04);
      li.appendChild(article);
      let saveButton = document.createElement('button');
      saveButton.classList.add('save-btn');
      saveButton.textContent = 'Save Story';
      saveButton.addEventListener('click', saveHandler);
      let editButton = document.createElement('button');
      editButton.classList.add('edit-btn');
      editButton.textContent = 'Edit Story';
      editButton.addEventListener('click', editHandler);
      let deleteButton = document.createElement('button');
      deleteButton.classList.add('delete-btn');
      deleteButton.textContent = 'Delete Story';
      deleteButton.addEventListener('click', deleteHandler);
      li.appendChild(saveButton);
      li.appendChild(editButton);
      li.appendChild(deleteButton);
      previewList.appendChild(li);
      firstNameInput.value = '';
      lastNameInput.value = '';
      ageInput.value = '';
      storyTitleInput.value = '';
      storyTextarea.value = '';
      formButton.disabled = true;
    }
  }

  function checkIfAllInputsAreValid(...inputs) {
    for (const input of inputs) {
      if (input.value.trim() === '') {
        return false;
      }
    }
    return true;
  }

  function editHandler(event) {
    let mainHoldingElement = event.currentTarget.parentElement;
    let nameInfo = previewList.children[1].children[0].children[0].textContent.split(': ');
    let [firstName, lastName] = nameInfo[1].split(' ');
    let ageInfo = previewList.children[1].children[0].children[1].textContent.split(': ');
    let age = ageInfo[1];
    let titleInfo = previewList.children[1].children[0].children[2].textContent.split(': ');
    let title = titleInfo[1];
    let genreInfo = previewList.children[1].children[0].children[3].textContent.split(': ');
    let genre = genreInfo[1];
    let storyText = previewList.children[1].children[0].children[4].textContent;
    firstNameInput.value = firstName;
    lastNameInput.value = lastName;
    ageInput.value = age;
    storyTitleInput.value = title;
    genreSelectMenu.value = genre;
    storyTextarea.value = storyText;
    previewList.removeChild(mainHoldingElement);
    formButton.disabled = false;
  }

  function saveHandler() {
    mainDiv.textContent = '';
    let h1 = document.createElement('h1');
    h1.textContent = 'Your scary story is saved!';
    mainDiv.appendChild(h1);
  }

  function deleteHandler(event) {
    let mainHoldingElement = event.currentTarget.parentElement;
    previewList.removeChild(mainHoldingElement);
    formButton.disabled = false;
  }
}
