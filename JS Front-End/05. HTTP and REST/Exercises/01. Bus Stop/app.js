function getInfo() {
    let stopIdInput = document.getElementById('stopId');
    let stopName = document.getElementById('stopName');
    let busesList = document.getElementById('buses');
    let URL = `http://localhost:3030/jsonstore/bus/businfo/${stopIdInput.value}`;

    busesList.textContent = '';
    fetch(URL)
        .then(response => {
            if (response.status !== 200) {
                stopName.textContent = 'Error';
            }
            return response.json();
        })
        .then(data => {
            stopName.textContent = data.name;
            for (const busId in data.buses) {
                console.log(busId);
                console.log(data.buses[busId]);
                let liElement = document.createElement('li');
                liElement.textContent = `Bus ${busId} arrives in ${data.buses[busId]} minutes`;
                busesList.appendChild(liElement);
            }
        })
        .catch(() => {
            stopName.textContent = 'Error';
        });
}