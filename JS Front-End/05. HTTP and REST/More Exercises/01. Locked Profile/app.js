function lockedProfile() {
    const URL = 'http://localhost:3030/jsonstore/advanced/profiles';
    const main = document.getElementById('main');
    
    loadUsers();

    function loadUsers() {
        fetch(URL)
            .then(response => response.json())
            .then(data => {
                let users = Object.values(data);
                let currentUser = 1;
                for (const user of users) {
                    let username = user.username;
                    let email = user.email;
                    let age = user.age;
                    let id = user._id;
                    loadProfile(username, email, age, id, currentUser);
                    currentUser++;
                }
                main.children[0].remove();
            })
            .catch(error => console.log(error));
    }

    function loadProfile(username, email, age, id, currentUser) {
        let profile = document.getElementsByClassName('profile')[0].cloneNode(true);

        let profileChildren = profile.children;

        profileChildren[2].name = `user${currentUser}Locked`;
        profileChildren[4].name = `user${currentUser}Locked`;
        profileChildren[8].name = `user${currentUser}Username`;
        profileChildren[8].value = username;
        profileChildren[9].setAttribute('class', `user${currentUser}Username`);
        let button = profileChildren[10];

        button.addEventListener('click', (e) => {
            let parentElement = e.currentTarget.parentElement;
            let radioButton = parentElement.children[2];

            if (!radioButton.checked && e.currentTarget.textContent === 'Show more') {
                parentElement.children[9].style.display = 'block';
                e.currentTarget.textContent = 'Hide it';
            } else if (!radioButton.checked && e.currentTarget.textContent === 'Hide it') {
                parentElement.children[9].style.display = 'none';
                e.currentTarget.textContent = 'Show more';
            }
        });
        
        let divChildren = profileChildren[9].children;

        divChildren[2].name = `user${currentUser}Email`;
        divChildren[2].value = email;

        divChildren[4].type = 'email';

        divChildren[4].value = age;

        profileChildren[9].style.display = 'none';

        profile.id = id;
        main.appendChild(profile);
    }
}