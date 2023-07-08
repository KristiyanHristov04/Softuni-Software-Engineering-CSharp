function solve(text){
    let array = text.split(/[\W]+/);
    for (let index = 0; index < array.length; index++) {
        array[index] = array[index].toUpperCase();
    }
    if(array[array.length - 1] == ''){
        array.pop();
    }
    console.log(array.join(', '));
}

solve('Hi, how are you?');
solve('hello');
solve('FUNCTIONS, IN, JS, CAN, BE, NESTED, I, E, HOLD, OTHER, FUNCTIONS');