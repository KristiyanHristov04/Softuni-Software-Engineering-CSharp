const BaseUrl = 'http://localhost:3030/jsonstore/tasks/';
const loadMealsButton = document.getElementById('load-meals');
const addMealButton = document.getElementById('add-meal');
const editMealButton = document.getElementById('edit-meal');
const [foodInput, timeInput, caloriesInput] = document.querySelectorAll('input');
const list = document.getElementById('list');

loadMealsButton.addEventListener('click', loadMeals);
addMealButton.addEventListener('click', addMeal);
editMealButton.addEventListener('click', editMeal);

let currentId = '';

function editMeal() {
    fetch(`${BaseUrl}${currentId}`, {
        method: 'PUT',
        body: JSON.stringify({
            food: foodInput.value,
            calories: caloriesInput.value,
            time: timeInput.value,
            _id: currentId
        })
    })
    .then(loadMeals)
    .then(clearInputs)
    .then(() => {
        editMealButton.disabled = true;
        addMealButton.disabled = false;
    })
    .catch(error => console.log(error));
}

function addMeal() {
    fetch(BaseUrl, {
        method: 'POST',
        body: JSON.stringify({
            food: foodInput.value,
            calories: caloriesInput.value,
            time: timeInput.value
        })
    })
    .then(loadMeals)
    .then(clearInputs)
    .catch(error => console.log(error));
}

function loadMeals() {
    list.innerHTML = '';
    fetch(BaseUrl)
        .then(response => response.json())
        .then(data => {
            let meals = Object.values(data);
            for (const meal of meals) {
                let food = meal.food;
                let calories = meal.calories;
                let time = meal.time;
                let id = meal._id;
                loadMeal(food, calories, time, id);
            }
        })
        .catch(error => console.log(error));
}

function loadMeal(food, calories, time, id) {
    let div = document.createElement('div');
    div.classList.add('meal');

    let foodh2 = document.createElement('h2');
    foodh2.textContent = food;

    let timeh3 = document.createElement('h3');
    timeh3.textContent = time;

    let caloriesh3 = document.createElement('h3');
    caloriesh3.textContent = calories;

    let divButtons = document.createElement('div');
    divButtons.id = 'meal-buttons';

    let changeButton = document.createElement('button');
    changeButton.classList.add('change-meal');
    changeButton.textContent = 'Change';
    changeButton.id = id;
    changeButton.addEventListener('click', (e) => {
        currentId = e.currentTarget.id;

        let mainDiv = e.currentTarget.parentElement.parentElement;
        foodInput.value = mainDiv.children[0].textContent;
        timeInput.value = mainDiv.children[1].textContent;
        caloriesInput.value = mainDiv.children[2].textContent;

        mainDiv.remove();
        addMealButton.disabled = true;
        editMealButton.disabled = false;
    });

    let deleteButton = document.createElement('button');
    deleteButton.classList.add('delete-meal');
    deleteButton.textContent = 'Delete';
    deleteButton.id = id;
    deleteButton.addEventListener('click', (e) => {
        currentId = e.currentTarget.id;
        fetch(`${BaseUrl}${currentId}`, {
            method: 'DELETE'
        })
        .then(loadMeals)
        .catch(error => console.log(error));
    });

    divButtons.appendChild(changeButton);
    divButtons.appendChild(deleteButton);

    div.appendChild(foodh2);
    div.appendChild(timeh3);
    div.appendChild(caloriesh3);
    div.appendChild(divButtons);

    list.appendChild(div);

}

function clearInputs() {
    foodInput.value = '';
    timeInput.value = '';
    caloriesInput.value = '';
}