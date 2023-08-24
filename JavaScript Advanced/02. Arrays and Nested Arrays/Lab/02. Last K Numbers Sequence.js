function solve(n, k) {
    let numbers = [1];
    for (let i = 1; i < n; i++) {
        let newSum = 0;
        for (let j = numbers.length - 1; j >= numbers.length - k; j--) {
            newSum += numbers[j];
            if (j === 0) {
                break;
            }
        }
        numbers.push(newSum);
    }
    return numbers;
}

solve(4, 2);