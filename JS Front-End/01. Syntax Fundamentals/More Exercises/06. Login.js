function solve(input){
    let username = input.shift();
    let correctPassword = '';
    for (let index = username.length - 1; index >= 0; index--) {
        correctPassword += username[index];
    }
    let totalTries = 0;
    for (let index = 0; index < input.length; index++) {
        let passwordTry = input[index];
        if(correctPassword !== passwordTry){
            totalTries++;
            if(totalTries == 4){
                console.log(`User ${username} blocked!`);
                return;
            }
            console.log('Incorrect password. Try again.');
        } else {
            console.log(`User ${username} logged in.`);
            return;
        }
    }
}

solve(['Acer','login','go','let me in','recA']);
solve(['momo','omom']);
solve(['sunny','rainy','cloudy','sunny','not sunny']);