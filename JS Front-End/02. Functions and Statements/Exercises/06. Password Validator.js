function passwordValidator(password){
    let isPasswordValid = true;
    checkPasswordLength();
    checkForForbiddenSymbols();
    checkForDigitsCount();

    if(isPasswordValid){
        console.log('Password is valid');
    }

    function checkPasswordLength(){
        if(!(password.length >= 6 && password.length <= 10)){
            isPasswordValid = false;
            console.log('Password must be between 6 and 10 characters');
        }
    }

    function checkForForbiddenSymbols(){
        let regex = /\W+/g;
        if(regex.test(password)){
            isPasswordValid = false;
            console.log('Password must consist only of letters and digits');
        }
    }

    function checkForDigitsCount(){
        let digitsCount = 0;

        for (let i = 0; i < password.length; i++) {
            let currentSymbol = password[i];
            if (currentSymbol.charCodeAt(0) >= 48 && currentSymbol.charCodeAt(0) <= 57) {
                digitsCount++;
            }
        }

        if(digitsCount < 2){
            isPasswordValid = false;
            console.log('Password must have at least 2 digits');
        }
    }
}

passwordValidator('logIn');
passwordValidator('MyPass123');
passwordValidator('Pa$s$s');