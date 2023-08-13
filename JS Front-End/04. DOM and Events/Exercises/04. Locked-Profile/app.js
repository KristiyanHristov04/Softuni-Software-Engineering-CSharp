function lockedProfile() {
    let buttons = document.getElementsByTagName('button');
    for (const button of buttons) {
        button.addEventListener('click', showMoreButton);
    }

    function showMoreButton(e) {
        this.removeEventListener('click', showMoreButton);
        this.addEventListener('click', hideItButton);
        let element = e.currentTarget;
        let parent = element.parentElement;
        let hiddenDivId = parent.children[9].id;
        if (hiddenDivId === 'user1HiddenFields') {
            let user1LockedOrUnlocked = document.querySelector('input[name="user1Locked"]').checked;
            if (user1LockedOrUnlocked === false) {
                document.getElementById(hiddenDivId).style.display = 'block';
                element.textContent = 'Hide it';
            }
        } else if (hiddenDivId === 'user2HiddenFields') {
            let user2LockedOrUnlocked = document.querySelector('input[name="user2Locked"]').checked;
            if (user2LockedOrUnlocked === false) {
                document.getElementById(hiddenDivId).style.display = 'block';
                element.textContent = 'Hide it';
            }
        } else {
            let user3LockedOrUnlocked = document.querySelector('input[name="user3Locked"]').checked;
            if (user3LockedOrUnlocked === false) {
                document.getElementById(hiddenDivId).style.display = 'block';
                element.textContent = 'Hide it';
            }
        }
    }

    function hideItButton(e) {
        this.removeEventListener('click', hideItButton);
        this.addEventListener('click', showMoreButton);
        let element = e.currentTarget;
        let parent = element.parentElement;
        let hiddenDivId = parent.children[9].id;
        if (hiddenDivId === 'user1HiddenFields') {
            let user1LockedOrUnlocked = document.querySelector('input[name="user1Locked"]').checked;
            if (user1LockedOrUnlocked === false && element.textContent === 'Hide it') {
                document.getElementById(hiddenDivId).style.display = 'none';
                element.textContent = 'Show more';
            }
        } else if (hiddenDivId === 'user2HiddenFields') {
            let user2LockedOrUnlocked = document.querySelector('input[name="user2Locked"]').checked;
            if (user2LockedOrUnlocked === false && element.textContent === 'Hide it') {
                document.getElementById(hiddenDivId).style.display = 'none';
                element.textContent = 'Show more';
            }
        } else {
            let user3LockedOrUnlocked = document.querySelector('input[name="user3Locked"]').checked;
            if (user3LockedOrUnlocked === false && element.textContent === 'Hide it') {
                document.getElementById(hiddenDivId).style.display = 'none';
                element.textContent = 'Show more';
            }
        }
    }
}