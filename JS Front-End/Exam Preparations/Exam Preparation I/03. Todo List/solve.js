function attachEvents() {
    const title = document.getElementById('title');
    const addButton = document.getElementById('add-button');
    const loadButton = document.getElementById('load-button');
    const toDoList = document.getElementById('todo-list');
    const URL = `http://localhost:3030/jsonstore/tasks`;


    addButton.addEventListener('click', addNewTaskHandler);
    loadButton.addEventListener('click', loadAllTasksHandler);

    function addNewTaskHandler(event) {
        event.preventDefault();
        let httpRequest = {
            method: 'POST',
            body: JSON.stringify({ name: title.value })
        }

        fetch(URL, httpRequest)
            .then(() => {
                fetch(URL)
                    .then(response => response.json())
                    .then(data => {
                        refreshTasks(data);
                    })
                    .catch(error => console.error(error));
            })
            .catch(error => console.error(error));

        title.value = '';
    }

    function loadAllTasksHandler(event) {
        toDoList.textContent = '';
        event.preventDefault();
        fetch(URL)
            .then(response => response.json())
            .then(data => {
                refreshTasks(data);
            })
            .catch(error => console.error(error));
    }

    function refreshTasks(data) {
        toDoList.textContent = '';
        let taskInfo = Object.values(data);
        for (let index = 0; index < taskInfo.length; index++) {
            let name = taskInfo[index].name;
            let id = taskInfo[index]._id;
            let li = document.createElement('li');
            li.setAttribute('id', id);
            let span = document.createElement('span');
            span.textContent = name;
            let removeButton = document.createElement('button');
            let editButton = document.createElement('button');
            removeButton.textContent = 'Remove';
            removeButton.addEventListener('click', deleteTaskHandler);
            editButton.textContent = 'Edit';
            editButton.addEventListener('click', editTaskHandler)
            li.appendChild(span);
            li.appendChild(removeButton);
            li.appendChild(editButton);
            toDoList.appendChild(li);
        }
    }

    function editTaskHandler(event) {
        let parent = event.currentTarget.parentElement;
        let patchId = parent.id;
        let parentChildren = Array.from(parent.children);
        let input = document.createElement('input');
        input.value = parentChildren[0].textContent;
        let removeButton = parentChildren[1];
        let submitButton = parentChildren[2];
        submitButton.textContent = 'Submit';
        submitButton.removeEventListener('click', editTaskHandler);
        submitButton.addEventListener('click', () => {
            let httpRequest = {
                method: 'PATCH',
                body: JSON.stringify({name: input.value})
            };

            fetch(`${URL}/${patchId}`, httpRequest)
                .then(() => {
                    fetch(URL)
                        .then(response => response.json())
                        .then(data => refreshTasks(data))
                        .catch(error => console.error());
                })
                .catch(error => console.error(error));
        });
        parent.textContent = '';
        parent.appendChild(input);
        parent.appendChild(removeButton);
        parent.appendChild(submitButton);
    }

    function deleteTaskHandler(event) {
        let taskIdToRemove = event.currentTarget.parentElement.id;
        let httpRequest = {
            method: 'DELETE'
        };

        fetch(`${URL}/${taskIdToRemove}`, httpRequest)
            .then(() => {
                fetch(URL)
                    .then(response => response.json())
                    .then(data => refreshTasks(data))
                    .catch(error => console.error());
            })
            .catch(error => console.error());
    }
}

attachEvents();
