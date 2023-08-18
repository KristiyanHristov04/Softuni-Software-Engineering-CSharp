function attachEvents() {
    let locationInput = document.getElementById('location');
    let submitButton = document.getElementById('submit');
    let forecast = document.getElementById('forecast');
    let currentConditions = document.querySelector('#forecast #current');
    let upcomingConditions = document.querySelector('#forecast #upcoming');
    submitButton.addEventListener('click', getWeatherHandler);

    function getWeatherHandler() {
        forecast.style.display = 'none';
        let currConditionsChildren = Array.from(currentConditions.children);
        if (currConditionsChildren.length > 1) {
            currentConditions.removeChild(currConditionsChildren[1]);
        }
        let upcomConditionsChildren = Array.from(upcomingConditions.children);
        if (upcomConditionsChildren.length > 1) {
            upcomingConditions.removeChild(upcomConditionsChildren[1]);
        }
        let cityNameInput = locationInput.value;
        let allCitiesURL = `http://localhost:3030/jsonstore/forecaster/locations`;
        fetch(allCitiesURL)
            .then(response => {
                if (response.status !== 200) {
                    forecast.style.display = 'block';
                    upcomingConditions.style.display = 'none';
                    document.getElementsByClassName('label')[0].textContent = 'Error';
                    throw new Error('We`ve encountered an Error!');
                }
                return response.json()
            })
            .then(data => {
                let allCitiesArray = data;
                for (const cityInfo of allCitiesArray) {
                    let cityCode = cityInfo.code;
                    let cityName = cityInfo.name;
                    if (cityNameInput == cityName) {
                        let currentConditionURL = `http://localhost:3030/jsonstore/forecaster/today/${cityCode}`;
                        fetch(currentConditionURL)
                            .then(response => {
                                if (response.status !== 200) {
                                    forecast.style.display = 'block';
                                    upcomingConditions.style.display = 'none';
                                    document.getElementsByClassName('label')[0].textContent = 'Error';
                                    throw new Error('We`ve encountered an Error!');
                                }
                                return response.json()
                            })
                            .then(data => {
                                let name = data.name;
                                let condition = data.forecast.condition;
                                let high = data.forecast.high;
                                let low = data.forecast.low;
                                forecast.style.display = 'block';
                                let newDiv = document.createElement('div');
                                newDiv.classList.add('forecasts');
                                let newSpan = document.createElement('span');
                                newSpan.classList.add('condition');
                                newSpan.classList.add('symbol');
                                newSpan.innerHTML = assignCondition(condition);
                                newDiv.appendChild(newSpan);
                                let mainSpan = document.createElement('span');
                                mainSpan.classList.add('condition');
                                let spanChild01 = document.createElement('span');
                                spanChild01.classList.add('forecast-data');
                                spanChild01.textContent = `${name}`;
                                let spanChild02 = document.createElement('span');
                                spanChild02.classList.add('forecast-data');
                                spanChild02.innerHTML = `${low}&#176/${high}&#176`;
                                let spanChild03 = document.createElement('span');
                                spanChild03.classList.add('forecast-data');
                                spanChild03.innerHTML = `${condition}`;
                                mainSpan.appendChild(spanChild01);
                                mainSpan.appendChild(spanChild02);
                                mainSpan.appendChild(spanChild03);
                                newDiv.appendChild(mainSpan);
                                currentConditions.appendChild(newDiv);
                            })
                            .catch(error => console.error({ error }));
                        let upcomigConditionsURL = `http://localhost:3030/jsonstore/forecaster/upcoming/${cityCode}`;
                        fetch(upcomigConditionsURL)
                            .then(response => {
                                if (response.status !== 200) {
                                    forecast.style.display = 'block';
                                    upcomingConditions.style.display = 'none';
                                    document.getElementsByClassName('label')[0].textContent = 'Error';
                                    throw new Error('We`ve encountered an Error!');
                                }
                                return response.json()
                            })
                            .then(data => {
                                let threeDayWeatherInfo = data.forecast;
                                let newDiv = document.createElement('div');
                                newDiv.classList.add('forecast-info');
                                for (let index = 0; index < threeDayWeatherInfo.length; index++) {
                                    let mainSpan = document.createElement('span');
                                    mainSpan.classList.add('upcoming');
                                    let condition = threeDayWeatherInfo[index].condition;
                                    let high = threeDayWeatherInfo[index].high;
                                    let low = threeDayWeatherInfo[index].low;
                                    let spanChild01 = document.createElement('span');
                                    spanChild01.classList.add('symbol');
                                    spanChild01.innerHTML = assignCondition(condition);
                                    let spanChild02 = document.createElement('span');
                                    spanChild02.classList.add('forecast-data');
                                    spanChild02.innerHTML = `${low}&#176/${high}&#176`;
                                    let spanChild03 = document.createElement('span');
                                    spanChild03.classList.add('forecast-data');
                                    spanChild03.textContent = `${condition}`;
                                    mainSpan.appendChild(spanChild01);
                                    mainSpan.appendChild(spanChild02);
                                    mainSpan.appendChild(spanChild03);
                                    newDiv.appendChild(mainSpan);
                                    upcomingConditions.appendChild(newDiv);
                                }
                            })
                            .catch(error => console.error(error));
                    }
                }
            })
            .catch(error => console.error(error));
        locationInput.value = '';
    }

    function assignCondition(condition) {
        if (condition === 'Sunny') {
            return '&#x2600';
        } else if (condition === 'Partly sunny') {
            return '&#x26C5';
        } else if (condition === 'Overcast') {
            return '&#x2601';
        }
        return '&#x2614';
    }
}

attachEvents();