function solve(input){
    let projectionType = input[0];
    let rowsCount = Number(input[1]);
    let colsCount = Number(input[2]);

    let projectionPrice = 0;
    let income = 0;

    if(projectionType == 'Premiere'){
        projectionPrice = 12.00;
    }
    else if(projectionType == 'Normal'){
        projectionPrice = 7.50;
    }
    else{
        projectionPrice = 5.00;
    }

    income = (rowsCount * colsCount) * projectionPrice;

    console.log(`${income.toFixed(2)}`);
}

// solve(['Normal', '21', '13']);
