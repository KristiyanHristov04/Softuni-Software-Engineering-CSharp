function solve(array) {
    let sortedNames = array.sort((a, b) => a.localeCompare(b));
    let number = 1;
    for (const iterator of sortedNames) {
        console.log(`${number}.${iterator}`);
        number++;
    }
}


solve(["John", "Bob", "Christina", "Ema"]);