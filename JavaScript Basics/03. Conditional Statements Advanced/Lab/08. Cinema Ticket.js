function solve(input) {
    let dayOfWeek = input[0];

    switch (dayOfWeek) {
        case 'Monday':
        case 'Tuesday':
        case 'Friday':
            console.log(12);
            break;
        case 'Wednesday':
        case 'Thursday':
            console.log(14);
            break;
        case 'Saturday':
        case 'Sunday':
            console.log(16);
            break;
    }
}

// solve(['Monday']);