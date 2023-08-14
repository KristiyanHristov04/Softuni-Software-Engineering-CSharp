function validate() {
    let email = document.getElementById('email');
    let pattern = /[a-z]+\@[a-z]+\.[a-z]+/g;
    email.addEventListener('change', checkEmail);

    function checkEmail(e) {
        let emailText = email.value;
        let isEmailValid = pattern.test(emailText);
        if (isEmailValid) {
            email.classList.remove('error');
        } else {
            email.classList.add('error');
        }
    }
}