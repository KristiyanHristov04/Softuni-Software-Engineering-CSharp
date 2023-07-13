function smallestNumber(...numbers){
    let sortedNumbers = numbers.sort(compareFunction);
    let smallestNumber = sortedNumbers[0];
    console.log(smallestNumber);

    function compareFunction(a, b){
        return a - b;
    }
}

smallestNumber(2, 5, 1);