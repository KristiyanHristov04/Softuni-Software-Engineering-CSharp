function attachEventsListeners() {
    const inputButtons = document.querySelectorAll('input[type="button"]');
    const daysInput = document.getElementById('days');
    const hoursInput = document.getElementById('hours');
    const minutesInput = document.getElementById('minutes');
    const secondsInput = document.getElementById('seconds');
    for (const inputButton of inputButtons) {
        inputButton.addEventListener('click', measureUnits);
    }

    function measureUnits(event){
        let currentButtonId = event.currentTarget.id;
        let currentButtonParent = event.currentTarget.parentElement;
        let number = Number(currentButtonParent.children[1].value);
        if (currentButtonId === 'daysBtn') {
            let hours = number * 24;
            let minutes = hours * 60;
            let seconds = minutes * 60;
            hoursInput.value = hours;
            minutesInput.value = minutes;
            secondsInput.value = seconds;
        } else if (currentButtonId === 'hoursBtn') {
            let days = number / 24;
            let minutes = number * 60;
            let seconds = minutes * 60;
            daysInput.value = days;
            minutesInput.value = minutes;
            secondsInput.value = seconds;
        } else if (currentButtonId === 'minutesBtn') {
            let days = number / 1440;
            let hours = number / 60;
            let seconds = number * 60;
            daysInput.value = days;
            hoursInput.value = hours;
            secondsInput.value = seconds;
        } else {
            let days = number / 86400;
            let hours = number / 3600;
            let minutes = number / 60;
            daysInput.value = days;
            hoursInput.value = hours;
            minutesInput.value = minutes;
        }
    }
}