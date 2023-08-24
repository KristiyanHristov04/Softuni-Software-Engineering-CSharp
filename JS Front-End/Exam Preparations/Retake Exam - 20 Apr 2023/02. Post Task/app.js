window.addEventListener("load", solve);

function solve() {
    const titleInput = document.getElementById('task-title');
    const categoryInput = document.getElementById('task-category');
    const contentTextarea = document.getElementById('task-content');
    const publishButton = document.getElementById('publish-btn');
    const reviewList = document.getElementById('review-list');
    const publishedList = document.getElementById('published-list');

    publishButton.addEventListener('click', addTaskToReviewHandler);

    function addTaskToReviewHandler() {
        if (checkIfInputsAreValid(titleInput, categoryInput, contentTextarea)) {
            let li = document.createElement('li');
            li.classList.add('rpost');
            let article = document.createElement('article');
            let h4 = document.createElement('h4');
            h4.textContent = titleInput.value;
            let p01 = document.createElement('p');
            p01.textContent = `Category: ${categoryInput.value}`;
            let p02 = document.createElement('p');
            p02.textContent = `Content: ${contentTextarea.value}`;
            let editButton = document.createElement('button');
            editButton.classList.add('action-btn');
            editButton.classList.add('edit');
            editButton.textContent = 'Edit';
            editButton.addEventListener('click', editTaskHandler);
            let postButton = document.createElement('button');
            postButton.classList.add('action-btn');
            postButton.classList.add('post');
            postButton.textContent = 'Post';
            postButton.addEventListener('click', postTaskHandler);
            article.appendChild(h4);
            article.appendChild(p01);
            article.appendChild(p02);
            li.appendChild(article);
            li.appendChild(editButton);
            li.appendChild(postButton);
            reviewList.appendChild(li);
            clearInputs(titleInput, categoryInput, contentTextarea);
        }
    }

    function postTaskHandler(event) {
        let liElement = event.currentTarget.parentElement;
        let liChildren = Array.from(liElement.children);
        let editBtn = liChildren[1];
        let postBtn = liChildren[2];
        liElement.removeChild(editBtn);
        liElement.removeChild(postBtn);
        reviewList.removeChild(liElement);
        publishedList.appendChild(liElement);
    }

    function editTaskHandler(event) {
        let liParent = event.currentTarget.parentElement;
        let articleChild = liParent.children[0];
        let title = articleChild.children[0].textContent;
        let category = articleChild.children[1].textContent.split(': ')[1];
        let content = articleChild.children[2].textContent.split(': ')[1];
        reviewList.removeChild(liParent);
        titleInput.value = title;
        categoryInput.value = category;
        contentTextarea.value = content;
    }

    function checkIfInputsAreValid(...inputs) {
        return inputs.every(input => input.value.trim() !== '');
    }

    function clearInputs(...inputs) {
        inputs.map(input => input.value = '');
    }
}