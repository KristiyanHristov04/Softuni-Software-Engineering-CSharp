function solve(input){
    const correctPassword = 's3cr3t!P@ssw0rd';
    let password = input[0];
    if (correctPassword == password) {
        console.log('Welcome');
    } else {
        console.log('Wrong password!');
    }
}

// solve(['s3cr3t!P@ssw0rd']);