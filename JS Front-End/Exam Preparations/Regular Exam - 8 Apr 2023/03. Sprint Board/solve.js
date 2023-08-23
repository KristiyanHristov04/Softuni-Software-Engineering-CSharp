// TODO:
function attachEvents() {
    const loadBoardButton = document.getElementById('load-board-btn');
    const titleInput = document.getElementById('title');
    const descriptionTextarea = document.getElementById('description');
    const createTaskButton = document.getElementById('create-task-btn');
    const toDoList = document.querySelector('#todo-section .task-list');
    const inProgressList = document.querySelector('#in-progress-section .task-list');
    const codeReviewList = document.querySelector('#code-review-section .task-list');
    const doneList = document.querySelector('#done-section .task-list');
    const URL = 'http://localhost:3030/jsonstore/tasks';

    createTaskButton.addEventListener('click', addTaskHandler);
    loadBoardButton.addEventListener('click', loadTasksHandler);

    function addTaskHandler() {
        let newTaskObject = {
            title: titleInput.value,
            description: descriptionTextarea.value,
            status: 'ToDo'
        };

        let httpRequest = {
            method: 'POST',
            body: JSON.stringify(newTaskObject)
        };

        fetch(URL, httpRequest)
            .then(() => loadTasksHandler())
            .catch(error => console.error(error));

        clearInputs(titleInput, descriptionTextarea);
    }

    function loadTasksHandler() {
        toDoList.textContent = '';
        inProgressList.textContent = '';
        codeReviewList.textContent = '';
        doneList.textContent = '';
        fetch(URL)
            .then(response => response.json())
            .then(data => {
                let tasksInfo = Object.values(data);
                for (let index = 0; index < tasksInfo.length; index++) {
                    let title = tasksInfo[index].title;
                    let description = tasksInfo[index].description;
                    let status = tasksInfo[index].status;
                    let id = tasksInfo[index]._id;
                    let liElement = document.createElement('li');
                    liElement.classList.add('task');
                    liElement.id = id;

                    if (status === 'ToDo') {
                        let h3 = document.createElement('h3');
                        h3.textContent = title;
                        let p = document.createElement('p');
                        p.textContent = description;
                        let button = document.createElement('button');
                        button.textContent = 'Move to In Progress';
                        button.addEventListener('click', moveToInProgressHandler);
                        liElement.appendChild(h3);
                        liElement.appendChild(p);
                        liElement.appendChild(button);
                        toDoList.appendChild(liElement);
                    } else if (status === 'In Progress') {
                        let h3 = document.createElement('h3');
                        h3.textContent = title;
                        let p = document.createElement('p');
                        p.textContent = description;
                        let button = document.createElement('button');
                        button.textContent = 'Move to Code Review';
                        button.addEventListener('click', moveToCodeReviewHandler);
                        liElement.appendChild(h3);
                        liElement.appendChild(p);
                        liElement.appendChild(button);
                        inProgressList.appendChild(liElement);
                    } else if (status === 'Code Review') {
                        let h3 = document.createElement('h3');
                        h3.textContent = title;
                        let p = document.createElement('p');
                        p.textContent = description;
                        let button = document.createElement('button');
                        button.textContent = 'Move to Done';
                        button.addEventListener('click', moveToDoneHandler);
                        liElement.appendChild(h3);
                        liElement.appendChild(p);
                        liElement.appendChild(button);
                        codeReviewList.appendChild(liElement);
                    } else {
                        let h3 = document.createElement('h3');
                        h3.textContent = title;
                        let p = document.createElement('p');
                        p.textContent = description;
                        let button = document.createElement('button');
                        button.textContent = 'Close';
                        button.addEventListener('click', deleteTaskHandler);
                        liElement.appendChild(h3);
                        liElement.appendChild(p);
                        liElement.appendChild(button);
                        doneList.appendChild(liElement);
                    }
                }
            })
            .catch(error => console.error(error));
    }

    function moveToInProgressHandler(event) {
        let liParent = event.currentTarget.parentElement;
        let idToMove = liParent.id;

        let changeStatusObject = {
            status: 'In Progress'
        };

        let URLPATCH = `${URL}/${idToMove}`;
        let httpRequest = {
            method: 'PATCH',
            body: JSON.stringify(changeStatusObject)
        };

        fetch(URLPATCH, httpRequest)
            .then(() => loadTasksHandler())
            .catch(error => console.error(error));
    }

    function moveToCodeReviewHandler(event) {
        let liParent = event.currentTarget.parentElement;
        let idToMove = liParent.id;

        let changeStatusObject = {
            status: 'Code Review'
        };

        let URLPATCH = `${URL}/${idToMove}`;
        let httpRequest = {
            method: 'PATCH',
            body: JSON.stringify(changeStatusObject)
        };

        fetch(URLPATCH, httpRequest)
            .then(() => loadTasksHandler())
            .catch(error => console.error(error));
    }

    function moveToDoneHandler(event) {
        let liParent = event.currentTarget.parentElement;
        let idToMove = liParent.id;

        let changeStatusObject = {
            status: 'Done'
        };

        let URLPATCH = `${URL}/${idToMove}`;
        let httpRequest = {
            method: 'PATCH',
            body: JSON.stringify(changeStatusObject)
        };

        fetch(URLPATCH, httpRequest)
            .then(() => loadTasksHandler())
            .catch(error => console.error(error));
    }

    function deleteTaskHandler(event) {
        let liParent = event.currentTarget.parentElement;
        let idToDelete = liParent.id;

        let URLDELETE = `${URL}/${idToDelete}`;
        let httpRequest = {
            method: 'DELETE'
        };

        fetch(URLDELETE, httpRequest)
            .then(() => loadTasksHandler())
            .catch(error => console.error(error));
    }

    function clearInputs(...inputs) {
        inputs.map(input => input.value = '');
    }
}


attachEvents();