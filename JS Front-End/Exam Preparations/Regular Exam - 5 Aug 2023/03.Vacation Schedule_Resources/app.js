const Url = `http://localhost:3030/jsonstore/tasks/`;
const loadVacationsButton = document.getElementById('load-vacations');
const addVacationButton = document.getElementById('add-vacation');
const editVacationButton = document.getElementById('edit-vacation');
const [nameInput, daysInput, dateInput] = document.querySelectorAll('input');
const list = document.getElementById('list');

loadVacationsButton.addEventListener('click', loadVacations);
addVacationButton.addEventListener('click', addVacation);
editVacationButton.addEventListener('click', editVacation);

let currentId = '';

function editVacation(e) {
    e.preventDefault();
    fetch(`${Url}${currentId}`, {
        method: 'PUT',
        body: JSON.stringify({
            name: nameInput.value,
            days: daysInput.value,
            date: dateInput.value,
            _id: currentId
        })
    })
    .then(loadVacations)
    .then(clearInputs)
    .then(() => {
        addVacationButton.disabled = false;
        editVacationButton.disabled = true;
    })
    .catch(error => console.log(error));
}

function addVacation(e) {
    e.preventDefault();
    fetch(Url, {
        method: 'POST',
        body: JSON.stringify({
            name: nameInput.value,
            days: daysInput.value,
            date: dateInput.value
        })
    })
    .then(loadVacations)
    .then(clearInputs)
    .catch(error => console.log(error));
}

function loadVacations() {
    list.innerHTML = '';
    fetch(Url)
        .then(response => response.json())
        .then(data => {
            let vacations = Object.values(data);
            for (const vacation of vacations) {
                let date = vacation.date;
                let days = vacation.days;
                let name = vacation.name;
                let id = vacation._id;
                loadVacation(date, days, name, id);
            }
        })
        .catch(error => console.log(error));
}

function loadVacation(date, days, name, id) {
    let containerDiv = document.createElement('div');
    containerDiv.classList.add('container');

    let nameh2 = document.createElement('h2');
    nameh2.textContent = name;

    let dateh3 = document.createElement('h3');
    dateh3.textContent = date;

    let daysh3 = document.createElement('h3');
    daysh3.textContent = days;

    let changeButton = document.createElement('button');
    changeButton.classList.add('change-btn');
    changeButton.textContent = 'Change';
    changeButton.id = id;
    changeButton.addEventListener('click', (e) => {
        let container = e.currentTarget.parentElement;
        nameInput.value = container.children[0].textContent;
        dateInput.value = container.children[1].textContent;
        daysInput.value = container.children[2].textContent;

        addVacationButton.disabled = true;
        editVacationButton.disabled = false;

        currentId = e.currentTarget.id;

        container.remove();
    });

    let doneButton = document.createElement('button');
    doneButton.classList.add('done-btn');
    doneButton.textContent = 'Done';
    doneButton.id = id;
    doneButton.addEventListener('click', (e) => {
        currentId = e.currentTarget.id;
        fetch(`${Url}${currentId}`, {
            method: 'DELETE'
        })
        .then(loadVacations)
        .catch(error => console.log(error));
    });

    containerDiv.appendChild(nameh2);
    containerDiv.appendChild(dateh3);
    containerDiv.appendChild(daysh3);
    containerDiv.appendChild(changeButton);
    containerDiv.appendChild(doneButton);

    list.appendChild(containerDiv);
}

function clearInputs() {
    nameInput.value = '';
    daysInput.value = '';
    dateInput.value = '';
}