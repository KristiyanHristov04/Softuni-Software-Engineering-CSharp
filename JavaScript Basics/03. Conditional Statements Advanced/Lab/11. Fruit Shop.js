function solve(input) {
    let fruit = input[0];
    let dayOfWeek = input[1];
    let quantity = Number(input[2]);
    let price = 0;

    switch (dayOfWeek) {
        case 'Monday':
        case 'Tuesday':
        case 'Wednesday':
        case 'Thursday':
        case 'Friday':
            if (fruit == 'banana') {
                price = quantity * 2.50;
                console.log(`${price.toFixed(2)}`);
            }
            else if (fruit == 'apple') {
                price = quantity * 1.20;
                console.log(`${price.toFixed(2)}`);
            }
            else if (fruit == 'orange') {
                price = quantity * 0.85;
                console.log(`${price.toFixed(2)}`);
            }
            else if (fruit == 'grapefruit') {
                price = quantity * 1.45;
                console.log(`${price.toFixed(2)}`);
            }
            else if (fruit == 'kiwi') {
                price = quantity * 2.70;
                console.log(`${price.toFixed(2)}`);
            }   
            else if (fruit == 'pineapple') {
                price = quantity * 5.50;
                console.log(`${price.toFixed(2)}`);
            }
            else if (fruit == 'grapes') {
                price = quantity * 3.85;
                console.log(`${price.toFixed(2)}`);
            }
            else {
                console.log('error');
            }
            break;
        case 'Saturday':
        case 'Sunday':
            if (fruit == 'banana') {
                price = quantity * 2.70;
                console.log(`${price.toFixed(2)}`);
            }
            else if (fruit == 'apple') {
                price = quantity * 1.25;
                console.log(`${price.toFixed(2)}`);
            }
            else if (fruit == 'orange') {
                price = quantity * 0.90;
                console.log(`${price.toFixed(2)}`);
            }
            else if (fruit == 'grapefruit') {
                price = quantity * 1.60;
                console.log(`${price.toFixed(2)}`);
            }
            else if (fruit == 'kiwi') {
                price = quantity * 3.00;
                console.log(`${price.toFixed(2)}`);
            }   
            else if (fruit == 'pineapple') {
                price = quantity * 5.60;
                console.log(`${price.toFixed(2)}`);
            }
            else if (fruit == 'grapes') {
                price = quantity * 4.20;
                console.log(`${price.toFixed(2)}`);
            }
            else {
                console.log('error');
            }
            break;
        default:
            console.log('error');
            break;
    }
}

// solve(['grapefruit', 'Saturday', '1.25']);