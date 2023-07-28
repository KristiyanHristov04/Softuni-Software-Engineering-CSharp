function sequences(input) {
    input = input.map(el => JSON.parse(el));
    input.forEach(el => el.sort((a, b) => b - a));
    let outputArr = [];
    for (let i = 0; i < input.length; i++) {
        let currentArray = input[i];
        let isUnique = true;
        for (let j = 0; j < outputArr.length; j++) {
            let nextArray = outputArr[j];
            if (nextArray.toString() === currentArray.toString()) {
                isUnique = false;
                break;
            }
        }
        if (isUnique) {
            outputArr.push(currentArray);
        }
    }
    outputArr.sort((a, b) => a.length - b.length);
    outputArr.forEach(el => console.log(`[${el.join(', ')}]`));
}

sequences(["[7.14, 7.180, 7.339, 80.099]",
"[7.339, 80.0990, 7.140000, 7.18]",
"[7.339, 7.180, 7.14, 80.099]"]
);