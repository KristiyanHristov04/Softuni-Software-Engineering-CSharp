function solve(base, increment){
    let stoneRequired = 0;
    let marbleRequired = 0;
    let lapisRequired = 0;
    let goldRequired = 0;
    let currentFloor = 0    ;

    for (let i = base; i >= 1; i -= 2) {
        if(i - 2 < 1){
            goldRequired = (i * i) * increment;
            currentFloor++;
            currentFloor *= increment;
            break;
        }
        currentFloor++;
        if(currentFloor % 5 == 0){
            stoneRequired += ((i - 2) * (i - 2)) * increment;
            lapisRequired += ((i - 1) * 4) * increment;
        } else {
            stoneRequired += ((i - 2) * (i - 2)) * increment;
            marbleRequired += ((i - 1) * 4) * increment;
        }
    }

    console.log(`Stone required: ${Math.ceil(stoneRequired)}`);
    console.log(`Marble required: ${Math.ceil(marbleRequired)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapisRequired)}`);
    console.log(`Gold required: ${Math.ceil(goldRequired)}`);
    console.log(`Final pyramid height: ${Math.floor(currentFloor)}`);
}

// solve(11, 1);
solve(12, 1);
// solve(11, 0.75);
// solve(23, 0.5);