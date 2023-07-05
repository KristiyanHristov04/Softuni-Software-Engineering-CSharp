function solve(array, step){
    let newArray = [];
    for (let index = 0; index < array.length; index += step) {
        newArray.push(array[index]);
    }
    return newArray;
}

solve(['5','20','31','4','20'], 2);