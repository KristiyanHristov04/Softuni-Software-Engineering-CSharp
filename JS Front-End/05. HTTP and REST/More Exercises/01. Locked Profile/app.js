function lockedProfile() {
    const main = document.getElementById('main');
    const profile = document.getElementsByClassName('profile')[0];
    main.textContent = '';
    const URL = `http://localhost:3030/jsonstore/advanced/profiles`;
    fetch(URL)
        .then(response => response.json())
        .then(data => {
            let peopleData = Object.values(data);
            for (let index = 0; index < peopleData.length; index++) {
                let username = peopleData[index].username;
                let email = peopleData[index].email;
                let age = peopleData[index].age;
                let newProfile = profile.cloneNode(true);
                let profileInfo = Array.from(newProfile.children);
                let radioInput01 = profileInfo[2];
                let radioInput02 = profileInfo[4];
                radioInput01.name = `user${index + 1}Locked`;
                radioInput02.name = `user${index + 1}Locked`;
                let usernameInput = profileInfo[8];
                usernameInput.name = `user${index + 1}Username`;
                usernameInput.value = username;
                let divHiddenInfo = profileInfo[9];
                divHiddenInfo.classList.remove('user1Username');
                divHiddenInfo.classList.add(`user${index + 1}Username`);
                let hiddenDivChildren = divHiddenInfo.children;
                let emailInput = hiddenDivChildren[2];
                emailInput.name = `user${index + 1}Email`;
                emailInput.value = email;
                let ageInput = hiddenDivChildren[4];
                ageInput.name = `user${index + 1}Age`;
                ageInput.value = age;
                divHiddenInfo.style.display = 'none';
                let showMoreButton = profileInfo[10];
                showMoreButton.addEventListener('click', showMoreHideButtonHandler);
                main.appendChild(newProfile);
            }
        })
        .catch(error => console.error(error));

        function showMoreHideButtonHandler(event) {
            let parent = event.currentTarget.parentElement;
            let isProfileLocked = parent.children[2].checked;
            let buttonText = event.currentTarget.textContent;
            if (!isProfileLocked && buttonText === 'Show more') {
                parent.children[9].style.display = 'block';
                event.currentTarget.textContent = 'Hide it';
                console.log(parent.children[8].value);
                console.log(parent.children[9].children[2].value);
                console.log(parent.children[9].children[4].value);
            } else if (!isProfileLocked && buttonText === 'Hide it') {
                parent.children[9].style.display = 'none';
                event.currentTarget.textContent = 'Show more';
            }
        }
}