const Url = 'http://localhost:3030/jsonstore/tasks/';
const loadHistoryButton = document.getElementById('load-history');
const addWeatherButton = document.getElementById('add-weather');
const editWeatherButton = document.getElementById('edit-weather');
const deleteButton = document.getElementById('delete-btn');
const [locationInput, temperatureInput, dateInput] = document.querySelectorAll('input');
const list = document.getElementById('list');

loadHistoryButton.addEventListener('click', loadHistory);
addWeatherButton.addEventListener('click', addWeather);
editWeatherButton.addEventListener('click', updateWeather);

let currentId = '';

function deleteWeather(e) {
    currentId = e.currentTarget.id;
    fetch(`${Url}${currentId}`, {
        method: 'DELETE'
    })
        .then(loadHistory)
        .catch(error => console.log(error));
}

function updateWeather(e) {
    fetch(`${Url}${currentId}`, {
        method: 'PUT',
        body: JSON.stringify({
            location: locationInput.value,
            temperature: temperatureInput.value,
            date: dateInput.value,
            _id: currentId
        })
    })
        .then(clearInputs)
        .then(loadHistory)
        .then(() => {
            e.currentTarget.disabled = true,
                addWeatherButton.disabled = false
        })
        .catch(error => console.log(error));
}

function addWeather() {
    fetch(Url, {
        method: 'POST',
        body: JSON.stringify({
            location: locationInput.value,
            temperature: temperatureInput.value,
            date: dateInput.value
        })
    })
        .then(loadHistory)
        .then(clearInputs)
        .catch(error => console.log(error));
}

function loadHistory() {
    list.innerHTML = '';
    console.log('before');
    fetch(Url)
        .then(response => response.json())
        .then(data => {
            let tasks = Object.values(data);
            console.log('after');
            for (const task of tasks) {
                let location = task.location;
                let temperature = task.temperature;
                let date = task.date;
                let id = task._id;
                createHistoryElement(location, temperature, date, id);
            }
        })
        .catch(error => console.log(error));
}

function createHistoryElement(location, temperature, date, id) {
    let container = document.createElement('div');
    container.classList.add('container');

    let elementLocation = document.createElement('h2');
    elementLocation.textContent = location;

    let elementDate = document.createElement('h3');
    elementDate.textContent = date;

    let elementTemperature = document.createElement('h3');
    elementTemperature.textContent = temperature;
    elementTemperature.id = 'celsius';

    let buttonsContainer = document.createElement('div');
    buttonsContainer.classList.add('buttons-container');

    let changeButton = document.createElement('button');
    changeButton.textContent = 'Change';
    changeButton.classList.add('change-btn');
    changeButton.id = id;
    changeButton.addEventListener('click', (e) => {
        let containerParentElement = e.currentTarget.parentElement.parentElement;
        locationInput.value = containerParentElement.children[0].textContent;
        dateInput.value = containerParentElement.children[1].textContent;
        temperatureInput.value = Number(containerParentElement.children[2].textContent);
        editWeatherButton.disabled = false;
        addWeatherButton.disabled = true;
        currentId = e.currentTarget.id;
        containerParentElement.remove();
    });

    let deleteButton = document.createElement('button');
    deleteButton.textContent = 'Delete';
    deleteButton.classList.add('delete-btn');
    deleteButton.id = id;
    deleteButton.addEventListener('click', deleteWeather);

    buttonsContainer.appendChild(changeButton);
    buttonsContainer.appendChild(deleteButton);

    container.appendChild(elementLocation);
    container.appendChild(elementDate);
    container.appendChild(elementTemperature);
    container.appendChild(buttonsContainer);

    list.appendChild(container);
}

function clearInputs() {
    locationInput.value = '';
    temperatureInput.value = '';
    dateInput.value = '';
}