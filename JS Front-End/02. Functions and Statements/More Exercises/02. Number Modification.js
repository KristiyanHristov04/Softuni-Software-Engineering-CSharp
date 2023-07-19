function modificateNumber(number) {
    let num = number.toString();
    let sum = 0;

    const append = (n) => (num += n);

    while (sum / num.length <= 5) {

        for (let i = 0; i < num.length; i++) {
            let n = Number(num[i]);
            sum += n;
        }

        if (sum / num.length <= 5) {
            append(9);
            sum = 0;
        }
    }

    console.log(num);
}

modificateNumber(101);