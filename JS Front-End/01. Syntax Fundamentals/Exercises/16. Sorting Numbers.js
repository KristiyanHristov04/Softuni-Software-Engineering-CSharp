function solve(array){
    let newArray = [];
    let shouldInsertSmall = true;
    while(array.length > 0){
        if(shouldInsertSmall){
            let smallestNumber = Math.min(...array);
            let smallestNumberIndex = array.indexOf(smallestNumber);
            array.splice(smallestNumberIndex, 1);
            newArray.push(smallestNumber);
            shouldInsertSmall = false;
        } else {
            let biggestNumber = Math.max(...array);
            let biggestNumberIndex = array.indexOf(biggestNumber);
            array.splice(biggestNumberIndex, 1);
            newArray.push(biggestNumber);
            shouldInsertSmall = true;
        }
    }
    return newArray;
}

solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);