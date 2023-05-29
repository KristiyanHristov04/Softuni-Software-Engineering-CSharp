function solve(input){
    let counter = 0;
    while (true) {
        let currentWord = input[counter];

        if(currentWord == "Stop"){
            break;
        }

        console.log(currentWord);
        counter++;
    }
}

// solve(['Nakov','SoftUni','Sofia','Bulgaria','SomeText','Stop','AfterStop','Europe','HelloWorld']);