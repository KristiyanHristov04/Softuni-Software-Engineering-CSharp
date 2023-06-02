function solve(input){
    let cakeLength = Number(input[0]);
    let cakeWidth = Number(input[1]);
    let cakePieces = cakeLength * cakeWidth;
    let index = 2;

    while(true){
        let action = input[index];
        if(action == 'STOP'){
            console.log(`${cakePieces} pieces are left.`);
            return;
        }
        let tookPieces = Number(action);
        cakePieces -= tookPieces;
        if(cakePieces < 0){
            let notEnoughPieces = Math.abs(cakePieces);
            console.log(`No more cake left! You need ${notEnoughPieces} pieces more.`);
            return;
        }
        index++;
    }
}

// solve(['10','10','20','20','20','20','21']);
solve(['10','2','2','4','6','STOP']);