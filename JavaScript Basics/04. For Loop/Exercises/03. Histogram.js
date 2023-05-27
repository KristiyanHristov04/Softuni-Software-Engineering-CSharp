function solve(input){
    let numbersCount = Number(input[0]);
    let p1Count = 0;
    let p2Count = 0;
    let p3Count = 0;
    let p4Count = 0;
    let p5Count = 0;

    for(let i = 1; i < input.length; i++){
        let currentNumber = Number(input[i]);
        if(currentNumber < 200){
            p1Count++;
        }
        else if(currentNumber >= 200 && currentNumber < 400){
            p2Count++;
        }
        else if(currentNumber >= 400 && currentNumber < 600){
            p3Count++;
        }
        else if(currentNumber >= 600 && currentNumber < 800){
            p4Count++;
        }
        else{
            p5Count++;
        }
    }

    let p1 = p1Count / numbersCount * 100;
    let p2 = p2Count / numbersCount * 100;
    let p3 = p3Count / numbersCount * 100;
    let p4 = p4Count / numbersCount * 100;
    let p5 = p5Count / numbersCount * 100;

    console.log(`${p1.toFixed(2)}%`);
    console.log(`${p2.toFixed(2)}%`);
    console.log(`${p3.toFixed(2)}%`);
    console.log(`${p4.toFixed(2)}%`);
    console.log(`${p5.toFixed(2)}%`);
}

// solve(['3', '1', '2', '999']);