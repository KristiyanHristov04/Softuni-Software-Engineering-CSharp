window.addEventListener('load', solve);

function solve() {
    const titleInput = document.getElementById('title');
    const descriptionTextarea = document.getElementById('description');
    const labelMenu = document.getElementById('label');
    const estimatedPointsInput = document.getElementById('points');
    const asigneeInput = document.getElementById('assignee');
    const createTaskButton = document.getElementById('create-task-btn');
    const deleteTaskButton = document.getElementById('delete-task-btn');
    const tasksSection = document.getElementById('tasks-section');
    const totalSprintPoints = document.getElementById('total-sprint-points');
    const hiddenInput = document.querySelector('#form-section #create-task-form input[type="hidden"]');
    let taskIdCounter = 0;
    let totalPoints = 0;

    createTaskButton.addEventListener('click', createTaskHandler);
    deleteTaskButton.addEventListener('click', deleteTaskHandler);

    function deleteTaskHandler() {
        let taskToDeleteId = hiddenInput.id;
        let tasksSectionChildren = tasksSection.children;
        for (let index = 0; index < tasksSectionChildren.length; index++) {
            if (tasksSectionChildren[index].id === taskToDeleteId) {
                let pointsToDecreaseInfo = tasksSectionChildren[index].children[3].textContent.split(' ');
                totalPoints -= Number(pointsToDecreaseInfo[2]);
                totalSprintPoints.textContent = `Total Points ${totalPoints}pts`;
                tasksSection.removeChild(tasksSectionChildren[index]);
                clearInputs(titleInput, descriptionTextarea, labelMenu, estimatedPointsInput, asigneeInput);
                enableInputs(titleInput, descriptionTextarea, labelMenu, estimatedPointsInput, asigneeInput);
                createTaskButton.disabled = false;
                deleteTaskButton.disabled = true;
                break;
            }
        }
    }

    function createTaskHandler() {
        if (checkIfInputsAreValid(titleInput, descriptionTextarea, labelMenu, estimatedPointsInput, asigneeInput)) {
            let article = document.createElement('article');
            article.id = `task-${++taskIdCounter}`;
            article.classList.add('task-card');
            let divLabel = document.createElement('div');
            divLabel.classList.add('task-card-label');
            if (labelMenu.value === 'Feature') {
                divLabel.classList.add('feature');
                divLabel.innerHTML = `${labelMenu.value} &#8865;`;
            } else if(labelMenu.value === 'Low Priority Bug') {
                divLabel.classList.add('low-priority');
                divLabel.innerHTML = `${labelMenu.value} &#9737;`;
            } else {
                divLabel.classList.add('high-priority');
                divLabel.innerHTML = `${labelMenu.value} &#9888;`;
            }
            let h3 = document.createElement('h3');
            h3.classList.add('task-card-title');
            h3.textContent = `${titleInput.value}`;

            let p = document.createElement('p');
            p.classList.add('task-card-description');
            p.textContent = `${descriptionTextarea.value}`;

            let divPoints = document.createElement('points');
            divPoints.classList.add('task-card-points');
            divPoints.textContent = `Estimated at ${estimatedPointsInput.value} pts`;

            totalPoints += Number(estimatedPointsInput.value);
            totalSprintPoints.textContent = `Total Points ${totalPoints}pts`;

            let divAssignee = document.createElement('div');
            divAssignee.classList.add('task-card-assignee');
            divAssignee.textContent = `Assigned to: ${asigneeInput.value}`;

            let divActions = document.createElement('div');
            divActions.classList.add('task-card-actions');

            let deleteButton = document.createElement('button');
            deleteButton.textContent = 'Delete';
            deleteButton.addEventListener('click', confirmDeleteHandler); 

            divActions.appendChild(deleteButton);
            article.appendChild(divLabel);
            article.appendChild(h3);
            article.appendChild(p);
            article.appendChild(divPoints);
            article.appendChild(divAssignee);
            article.appendChild(divActions);
            tasksSection.appendChild(article);
            clearInputs(titleInput, descriptionTextarea, labelMenu, estimatedPointsInput, asigneeInput);
        }
    }

    function confirmDeleteHandler(event) {
        let articleParent = event.currentTarget.parentElement.parentElement;
        let articleChildren = Array.from(articleParent.children);

        //Label
        let labelInfo = articleChildren[0].textContent.split(' ');
        labelInfo.pop();
        let label = labelInfo.join(' ');
        labelMenu.value = label;

        //Title
        let title = articleChildren[1].textContent;
        titleInput.value = title;

        //Description
        let description = articleChildren[2].textContent;
        descriptionTextarea.value = description;

        //Points 
        let pointsInfo = articleChildren[3].textContent.split(' ');
        let points = pointsInfo[2];
        estimatedPointsInput.value = points;

        //Assignee
        let assigneeInfo = articleChildren[4].textContent.split(': ');
        let assignee = assigneeInfo[1];
        asigneeInput.value = assignee;

        deleteTaskButton.disabled = false;
        createTaskButton.disabled = true;
        disableInputs(titleInput, descriptionTextarea, labelMenu, estimatedPointsInput, asigneeInput);
        hiddenInput.id = articleParent.id;
    }

    function checkIfInputsAreValid(...inputs) {
        return inputs.every(input => input.value.trim() !== '');
    }

    function clearInputs(...inputs) {
        inputs.map(input => input.value = '');
    }

    function disableInputs(...inputs) {
        inputs.map(input => input.disabled = true);
    }

    function enableInputs(...inputs) {
        inputs.map(input => input.disabled = false);
    }
}