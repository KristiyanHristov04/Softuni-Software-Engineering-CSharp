function solve(input){
    let hour = Number(input[0]);
    let dayOfWeek = input[1];

    if(hour >= 10 && hour <= 18 && dayOfWeek != 'Sunday'){
        console.log('open');
    }
    else{
        console.log('closed');
    }
}

// solve(['19', 'Friday']);
