function attachEvents() {
    const phonebook = document.getElementById('phonebook');
    const loadButton = document.getElementById('btnLoad');
    const createButton = document.getElementById('btnCreate');
    const personInput = document.getElementById('person');
    const phoneInput = document.getElementById('phone');
    const URL = `http://localhost:3030/jsonstore/phonebook`;

    loadButton.addEventListener('click', getAllPhonebookEntriesHandler);
    createButton.addEventListener('click', addPersonToPhonebookHandler)

    function addPersonToPhonebookHandler() {
        let newPersonObj = {
            person: personInput.value,
            phone: phoneInput.value
        };

        let httpHeaders = {
            method: 'POST',
            body: JSON.stringify(newPersonObj)
        }

        fetch(URL, httpHeaders)
            .catch(error => console.error(error));

        personInput.value = ''
        phoneInput.value = '';

        getAllPhonebookEntriesHandler();
    }

    function getAllPhonebookEntriesHandler() {
        phonebook.textContent = '';
        fetch(URL)
            .then(response => response.json())
            .then(data => {
                let people = Object.values(data);
                console.log(people);
                for (let index = 0; index < people.length; index++) {
                    let person = people[index].person;
                    let phone = people[index].phone;
                    let id = people[index]._id;
                    let li = document.createElement('li');
                    let button = document.createElement('button');
                    button.textContent = 'Delete';
                    button.id = id;
                    button.addEventListener('click', (event) => {
                        let httpHeaders = {
                            method: 'DELETE'
                        }

                        fetch(`http://localhost:3030/jsonstore/phonebook/${event.currentTarget.id}`, httpHeaders)
                            .then(() => getAllPhonebookEntriesHandler())
                            .catch(error => console.error(error));

                    });
                    li.innerHTML = `${person}: ${phone}`;
                    li.appendChild(button);
                    phonebook.appendChild(li);
                }
            })
            .catch(error => console.error(error));
    }
}

attachEvents();