function solve(input){
    let hour = Number(input[0]);
    let minutes = Number(input[1]);

    if(minutes + 15 >= 60){
        hour++;
        let newMinutes = (minutes + 15) - 60;
        minutes = newMinutes;
    }
    else{
        minutes += 15;
    }

    if(hour == 24){
        hour = 0;
    }

    if(minutes < 10){
        console.log(`${hour}:0${minutes}`);
    }
    else{
        console.log(`${hour}:${minutes}`);
    }

}

// solve(['1', '46']);
// solve(['0', '01']);
// solve(['23', '59']);
// solve(['11', '08']);
// solve(['12', '49']);