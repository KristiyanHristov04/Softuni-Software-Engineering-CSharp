function solve(input){
    let number = Number(input);
    let rectangle = '';
    for (let row = 1; row <= number; row++) {
        for (let col = 0; col < number; col++) {
            rectangle += '* ';
        }
        rectangle += '\n';
    }
    console.log(rectangle);
}

solve(2);
solve(3);