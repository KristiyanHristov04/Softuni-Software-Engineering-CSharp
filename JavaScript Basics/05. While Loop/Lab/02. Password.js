function solve(input){
    let username = input[0];
    let password = input[1];
    let index = 0;

    while(true){
        let guessPassword = input[index];
        if(guessPassword == password){
            console.log(`Welcome ${username}!`);
            break;
        }
        index++;
    }
}

// solve(['Nakov','1234','Pass','1324','1234']);