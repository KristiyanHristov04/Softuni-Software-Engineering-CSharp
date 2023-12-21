function attachEvents() {
    const URL = 'http://localhost:3030/jsonstore/phonebook';
    const phonebook = document.getElementById('phonebook'); 
    const loadButton = document.getElementById('btnLoad');
    const createButton = document.getElementById('btnCreate');
    const [personInput, phoneInput] = document.querySelectorAll('input[type=text]');

    loadButton.addEventListener('click', loadPhonebook);

    createButton.addEventListener('click', (e) => {
        fetch(URL, {
            method: 'POST',
            body: JSON.stringify({
                person: personInput.value,
                phone: phoneInput.value
            })
        })
        .then(personInput.value = '', phoneInput.value = '')
        .then(loadPhonebook)
        .catch(error => console.log(error));
    });

    function loadPhonebook() {
        phonebook.innerHTML = '';
        fetch(URL)
            .then(response => response.json())
            .then(data => {
                let contacts = Object.values(data);
                console.log(contacts);
                for (const contact of contacts) {
                    let person = contact.person;
                    let phone = contact.phone;
                    let id = contact._id;
                    loadContact(person, phone, id);
                }
            })
            .catch(error => console.log(error));
    }

    function loadContact(person, phone, id) {
        let li = document.createElement('li');
        li.textContent = `${person}: ${phone}`;
        let button = document.createElement('button');
        button.textContent = 'Delete';
        button.id = id;
        button.addEventListener('click', (e) => {
            let currentButtonId = e.currentTarget.id;
            fetch(`${URL}/${currentButtonId}`, {
                method: 'DELETE'
            })
            .catch(error => console.log(error));
        });
        li.appendChild(button);
        phonebook.appendChild(li);
    }
}

attachEvents();