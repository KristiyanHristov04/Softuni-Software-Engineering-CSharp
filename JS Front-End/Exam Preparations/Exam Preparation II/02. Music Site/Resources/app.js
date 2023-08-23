window.addEventListener('load', solve);

function solve() {
    const genreInput = document.getElementById('genre');
    const nameInput = document.getElementById('name');
    const authorInput = document.getElementById('author');
    const dateInput = document.getElementById('date');
    const addButton = document.getElementById('add-btn');
    const allHitsContainer = document.getElementsByClassName('all-hits-container')[0];
    const savedContainer = document.getElementsByClassName('saved-container')[0];
    const totalLikesParagraph = document.getElementsByClassName('likes')[0].children[0];
    let totalLikes = 0;

    addButton.addEventListener('click', addSongHandler);

    function addSongHandler(event) {
        event.preventDefault();
        if (checkInputsIfValid(genreInput, nameInput, authorInput, dateInput)) {
            let divElement = document.createElement('div');
            divElement.classList.add('hits-info');
            let imgElement = document.createElement('img');
            imgElement.setAttribute('src', './static/img/img.png');
            let h2Genre = document.createElement('h2');
            h2Genre.textContent = `Genre: ${genreInput.value}`;
            let h2Name = document.createElement('h2');
            h2Name.textContent = `Name: ${nameInput.value}`;
            let h2Author = document.createElement('h2');
            h2Author.textContent = `Author: ${authorInput.value}`;
            let h3Date = document.createElement('h3');
            h3Date.textContent = `Date: ${dateInput.value}`;
            let saveButton = document.createElement('button');
            saveButton.classList.add('save-btn');
            saveButton.textContent = 'Save song';
            saveButton.addEventListener('click', saveSongHandler);
            let likeButton = document.createElement('button');
            likeButton.classList.add('like-btn');
            likeButton.textContent = 'Like song';
            likeButton.addEventListener('click', likeSongHandler);
            let deleteButton = document.createElement('button');
            deleteButton.classList.add('delete-btn');
            deleteButton.textContent = 'Delete';
            deleteButton.addEventListener('click', deleteSongHandler);
            divElement.appendChild(imgElement);
            divElement.appendChild(h2Genre);
            divElement.appendChild(h2Name);
            divElement.appendChild(h2Author);
            divElement.appendChild(h3Date);
            divElement.appendChild(saveButton);
            divElement.appendChild(likeButton);
            divElement.appendChild(deleteButton);
            allHitsContainer.appendChild(divElement);
            clearInputs(genreInput, nameInput, authorInput, dateInput);
        }
    }

    function deleteSongHandler(event) {
        let parentToBeRemoved = event.currentTarget.parentElement;
        let mainParent = parentToBeRemoved.parentElement;
        mainParent.removeChild(parentToBeRemoved);
    }

    function saveSongHandler(event) {
        let parent = event.currentTarget.parentElement;
        let parentChildren = parent.children;
        let saveBtn = parentChildren[5];
        let likeBtn = parentChildren[6];
        parent.removeChild(saveBtn);
        parent.removeChild(likeBtn);
        allHitsContainer.removeChild(parent);
        savedContainer.appendChild(parent);
    }

    function likeSongHandler(event) {
        totalLikes++;
        totalLikesParagraph.textContent = `Total Likes: ${totalLikes}`;
        event.currentTarget.disabled = 'true';
    }

    function checkInputsIfValid(...inputs) {
        return inputs.every(input => input.value.trim() !== '');
    }

    function clearInputs(...inputs) {
        inputs.map(input => input.value = '');
    }
}