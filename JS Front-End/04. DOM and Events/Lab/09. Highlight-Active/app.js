function focused() {
    let inputs = document.getElementsByTagName('input');
    for (const input of inputs) {
        input.addEventListener('focus', highlightDiv);
        input.addEventListener('blur', unhighlightDiv);
    }

    function highlightDiv() {
        let parentElement = this.parentElement;
        parentElement.classList.add('focused');
    }

    function unhighlightDiv() {
        let parentElement = this.parentElement;
        parentElement.classList.remove('focused');
    }
}