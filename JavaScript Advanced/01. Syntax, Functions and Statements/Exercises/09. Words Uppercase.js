function solve(text){
    let result = text.toUpperCase()
    .match(/\w+/g) //regex
    .join(', ');

    console.log(result);
}

solve('Hi, how are you?');