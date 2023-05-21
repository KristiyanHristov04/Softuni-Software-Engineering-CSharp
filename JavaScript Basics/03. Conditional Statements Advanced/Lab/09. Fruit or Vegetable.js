function solve(input) {
    let product = input[0];

    switch (product) {
        case 'banana':
        case 'apple':
        case 'kiwi':
        case 'cherry':
        case 'lemon':
        case 'grapes':
            console.log('fruit');
            break;
        case 'tomato':
        case 'cucumber':
        case 'kiwi':
        case 'pepper':
        case 'carrot':
            console.log('vegetable');
            break;
        default:
            console.log('unknown');
            break;
    }
}

// solve(['banana']);