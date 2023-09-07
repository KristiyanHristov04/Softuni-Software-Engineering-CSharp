function solution(num01) {
    return (num02) => {
        return num01 + num02;
    }
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));