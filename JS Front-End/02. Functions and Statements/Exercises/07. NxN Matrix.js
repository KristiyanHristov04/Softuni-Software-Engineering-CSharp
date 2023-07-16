function matrix(n){
    for (let i = 1; i <= n; i++) {
        let print = n.toString() + ' ';
        console.log(print.repeat(n));
    }
}

matrix(7);
matrix(3);