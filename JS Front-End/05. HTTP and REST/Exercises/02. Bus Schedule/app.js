function solve() {
    const departButton = document.getElementById('depart');
    const arriveButton = document.getElementById('arrive');
    const nextStopInfo = document.getElementsByClassName('info')[0];
    let id = 'depot';
    function depart() {
        let URL = `http://localhost:3030/jsonstore/bus/schedule/${id}`;
        fetch(URL)
            .then(response => {
                if (response.status !== 200) {
                    departButton.disabled = true;
                    arriveButton.disabled = true;
                    nextStopInfo.textContent = 'Error';
                }
                return response.json();
            })
            .then(data => {
                id = data.next;
                nextStopInfo.textContent = `Next stop ${data.name}`;
            })
            .catch(() => {
                departButton.disabled = true;
                arriveButton.disabled = true;
                nextStopInfo.textContent = 'Error';
            });
        departButton.disabled = true;
        arriveButton.disabled = false;
    }

    async function arrive() {
        departButton.disabled = false;
        arriveButton.disabled = true;
        let URL = `http://localhost:3030/jsonstore/bus/schedule/${id}`;
        try {
            let response = await fetch(URL);
            let data = await response.json();
            id = data.next;
            nextStopInfo.textContent = `Arriving at ${data.name}`;
        } catch (error) {
            console.error(error);
        }

        //Using Fetch API with then/catch insead of await/async
        // fetch(URL)
        //     .then(response => response.json())
        //     .then(data => {
        //         id = data.next;
        //         nextStopInfo.textContent = `Arriving at ${data.name}`;
        //     })
        //     .catch(error => console.error(error));
    }

    return {
        depart,
        arrive
    };
}

let result = solve();