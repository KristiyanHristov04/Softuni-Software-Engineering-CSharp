function attachEvents() {
  const loadAllBooksButton = document.getElementById('loadBooks');
  const submitButton = document.querySelector('#form button');
  const titleInput = document.querySelector('#form input[name="title"]');
  const authorInput = document.querySelector('#form input[name="author"]');
  const tbody = document.querySelector('tbody');
  const h3Form = document.querySelector('#form h3');
  const BASE_URL = `http://localhost:3030/jsonstore/collections/books`;
  let UPDATE_URL = '';
  loadAllBooksButton.addEventListener('click', loadBooksHandler);
  submitButton.addEventListener('click', createBookHandler);
  loadBooksHandler();
  function createBookHandler() {
    if (validateInputs(titleInput, authorInput)) {
      let newBookObject = {
        author: authorInput.value,
        title: titleInput.value
      };

      let httpRequest = {
        method: 'POST',
        body: JSON.stringify(newBookObject)
      }

      fetch(BASE_URL, httpRequest)
        .then(() => loadBooksHandler())
        .catch(error => console.error(error));

        titleInput.value = '';
        authorInput.value = '';
    }
  }

  function validateInputs(...inputs) {
    for (const input of inputs) {
      if (input.value === '') {
        return false;
      }
    }
    return true;
  }

  function loadBooksHandler() {
    tbody.textContent = '';
    fetch(BASE_URL)
      .then(response => response.json())
      .then(data => {
        let booksKeys = Object.keys(data);
        let booksData = Object.values(data);
        for (let index = 0; index < booksData.length; index++) {
          let bookTitle = booksData[index].title;
          let bookAuthor = booksData[index].author;
          let tr = document.createElement('tr');
          let td01 = document.createElement('td');
          let td02 = document.createElement('td');
          let td03 = document.createElement('td');
          td01.textContent = bookTitle;
          td02.textContent = bookAuthor;
          let editButton = document.createElement('button');
          let deleteButton = document.createElement('button');
          editButton.textContent = 'Edit';
          editButton.setAttribute('id', booksKeys[index]);
          editButton.addEventListener('click', editBookHandler);
          deleteButton.textContent = 'Delete';
          deleteButton.setAttribute('id', booksKeys[index]);
          deleteButton.addEventListener('click', deleteBookHandler);
          td03.appendChild(editButton);
          td03.appendChild(deleteButton);
          tr.appendChild(td01);
          tr.appendChild(td02);
          tr.appendChild(td03);
          tbody.appendChild(tr);
        }
      })
      .catch(error => console.error(error));
  }

  function editBookHandler(event) {
    let currentEditId = event.currentTarget.id;
    UPDATE_URL = `http://localhost:3030/jsonstore/collections/books/${currentEditId}`;
    h3Form.textContent = 'Edit FORM';
    submitButton.textContent = 'Save';
    let parent = event.currentTarget.parentElement.parentElement;
    let parentChildren = Array.from(parent.children);
    let bookTitle = parentChildren[0].textContent;
    let bookAuthor = parentChildren[1].textContent;
    titleInput.value = bookTitle;
    authorInput.value = bookAuthor;
    submitButton.removeEventListener('click', createBookHandler);
    submitButton.addEventListener('click', saveChangesHandler);
  }

  function saveChangesHandler() {
    let updateBookObject = {
      author: authorInput.value,
      title: titleInput.value
    }

    let httpRequest = {
      method: 'PUT',
      body: JSON.stringify(updateBookObject)
    }

    fetch(UPDATE_URL, httpRequest)
      .then(() => {
        loadBooksHandler();
        h3Form.textContent = 'FORM';
        titleInput.value = '';
        authorInput.value = '';
        submitButton.removeEventListener('click', saveChangesHandler);
        submitButton.addEventListener('click', createBookHandler);
        submitButton.textContent = 'Submit';
      })
      .catch(error => console.error(error));
  }

  function deleteBookHandler (event) {
    let idToRemove = event.currentTarget.id;
    const DELETE_URL = `http://localhost:3030/jsonstore/collections/books/${idToRemove}`;
    let httpRequest = {
      method: 'DELETE'
    }

    fetch(DELETE_URL, httpRequest)
      .then(() => loadBooksHandler())
      .catch(error => console.error(error));
  }
}

attachEvents();