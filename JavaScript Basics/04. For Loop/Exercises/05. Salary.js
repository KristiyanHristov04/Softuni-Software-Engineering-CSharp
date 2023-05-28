function solve(input) {
    let openedTabs = Number(input[0]);
    let salary = Number(input[1]);

    for (let i = 0; i < input.length; i++) {
        switch (input[i]) {
            case 'Facebook':
                salary -= 150;
                break;
            case 'Instagram':
                salary -= 100;
                break;
            case 'Reddit':
                salary -= 50;
                break;
        }

        if(salary <= 0){
            console.log('You have lost your salary.');
            return;
        }
    }

    console.log(salary);
}

// solve(['10', '750', 'Facebook', 'Dev.bg', 'Instagram', 'Facebook', 'Reddit', 'Facebook', 'Facebook']);